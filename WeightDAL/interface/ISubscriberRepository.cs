using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightCORE.Response;
using WeightModel.model;

namespace WeightDAL
{
    public interface ISubscriberRepository
    {
        public Task<BaseResponseGeneral<bool>> Register(Subscriber subscriber, double height);
        public Task<BaseResponseGeneral<Card>> Login(string email, string password);
        public Task<bool> IsEmailExist(string email);
    }
}
