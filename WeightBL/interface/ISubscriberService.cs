using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightCORE.DTO;
using WeightCORE.Response;
using WeightModel.model;

namespace WeightBL
{
    public interface ISubscriberService
    {
        public Task<BaseResponseGeneral<bool>> Register(SubscriberDTO subscriberDTO);
        public Task<BaseResponseGeneral<CardDTO>> Login(string email, string password);
    }
}
