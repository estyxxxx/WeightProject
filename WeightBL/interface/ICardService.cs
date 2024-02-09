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
    public interface ICardService
    {
        public Task<BaseResponseGeneral<CardByIdResponse>> CardDetails(int id);
    }
}
