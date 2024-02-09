using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WeightBL;
using WeightCORE.DTO;
using WeightCORE.Response;
using WeightModel.model;

namespace Weight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        readonly ICardService _cardService;
        readonly IMapper _mapper;
        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseGeneral<CardByIdResponse>>> CardById(int id)
        {
            var response = await _cardService.CardDetails(id);
            if (!response.Succeed)
                return NotFound(response);
            return Ok(response);
        }
    }
}
