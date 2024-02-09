using AutoMapper;
using WeightCORE.DTO;
using WeightCORE.Response;
using WeightModel.model;

namespace Weight.Config
{
    public class WeightProfile : Profile
    {
        public WeightProfile()
        {
            CreateMap<CardDTO, Card>().ReverseMap();
            CreateMap<Subscriber, SubscriberDTO>().ForMember(d => d.Height, o => o.Ignore()).ReverseMap();
            CreateMap<BaseResponseGeneral<Card>, BaseResponseGeneral<CardDTO>>();
        }
    }
}
