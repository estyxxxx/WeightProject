using Microsoft.EntityFrameworkCore;
using WeightCORE.Response;
using WeightModel;
using WeightModel.model;

namespace WeightDAL
{
    public class SubscriberRepository : ISubscriberRepository
    {
        readonly WeightContext _weightContext;
        public SubscriberRepository(WeightContext weightContext)
        {
            _weightContext = weightContext;
        }
        public async Task<BaseResponseGeneral<bool>> Register(Subscriber subscriber, double height)
        {
            try
            {
                BaseResponseGeneral<bool> response = new BaseResponseGeneral<bool>();
                var newSubscriber = await _weightContext.Subscribers.AddAsync(subscriber);
                await _weightContext.SaveChangesAsync();
                var defaultCard = new Card
                {
                    SubscriberID = newSubscriber.Entity.ID,
                    Height = height,
                    BMI = 0,
                };
                _weightContext.Cards.AddAsync(defaultCard);
                await _weightContext.SaveChangesAsync();
                response.Succeed = true;
                response.Status = "Succeed";
                response.Response = true;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed");
            }
        }
        public async Task<bool> IsEmailExist(string email)
        {
            return await _weightContext.Subscribers.AnyAsync(s => s.Email == email);
        }
        public async Task<BaseResponseGeneral<Card>> Login(string email, string password)
        {
            try
            {
                Subscriber loginSubscriber = _weightContext.Subscribers.Where(s => s.Email == email && s.Password == password).FirstOrDefault();
;               BaseResponseGeneral<Card> response = new BaseResponseGeneral<Card>();
                if(loginSubscriber != null)
                {
                    response.Response = _weightContext.Cards.Where(s => s.ID == loginSubscriber.ID).FirstOrDefault();
                    response.Succeed = true;
                    response.Status = "Succeed";
                }
                else
                {
                    response.Response = null;
                    response.Succeed = false;
                    response.Status = "This email and password are incorrect";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new("Login failed");
            }
        }
    }
}