using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightCORE.Response;
using WeightModel.model;

namespace WeightDAL
{
    public interface ICardRepository
    {
        public Task<BaseResponseGeneral<CardByIdResponse>> CardDetails(int id);
    }
}
