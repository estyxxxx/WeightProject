using WeightCORE.Response;
using WeightModel;
using WeightModel.model;

namespace WeightDAL
{
    public class CardRepository : ICardRepository
    {
        readonly WeightContext _weightContext;
        public CardRepository(WeightContext weightContext)
        {
            _weightContext = weightContext;
        }
        public async Task<BaseResponseGeneral<CardByIdResponse>> CardDetails(int id)
        {
            try
            {
                BaseResponseGeneral<CardByIdResponse> response = new BaseResponseGeneral<CardByIdResponse>();
                Card card = _weightContext.Cards.Where(c => c.ID == id).FirstOrDefault();
                if (card != null)
                {
                    Subscriber subscriber = _weightContext.Subscribers.Where(s => s.ID == card.SubscriberID).FirstOrDefault();
                    if (subscriber != null)
                    {
                        response.Succeed = true;
                        response.Status = "Succeed";
                        response.Response = new CardByIdResponse();
                        response.Response.ID = id;
                        response.Response.FirstName = subscriber.FirstName;
                        response.Response.LastName = subscriber.LastName;
                        response.Response.Height = card.Height;
                        response.Response.Weight = card.Weight;
                        response.Response.BMI = card.BMI;
                    }
                    else
                    {
                        response.Succeed = false;
                        response.Status = "Failed";
                    }
                }
                else
                {
                    response.Succeed = false;
                    response.Status = "Failed";
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception("Get card By ID Failed");
            }
        }
    }
}