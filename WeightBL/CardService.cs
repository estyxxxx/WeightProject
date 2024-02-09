using AutoMapper;
using WeightDAL;
using WeightCORE.DTO;
using WeightModel.model;
using WeightCORE.Response;

namespace WeightBL
{
    public class CardService : ICardService
    {
        readonly ICardRepository _cardRepository;
        readonly IMapper _mapper;
        public CardService(ICardRepository repository, IMapper mapper)
        {
            _cardRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneral<CardByIdResponse>> CardDetails(int id)
        {
            return await _cardRepository.CardDetails(id);
        }
    }
}