using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeightBL;
using WeightCORE.DTO;
using WeightCORE.Response;
using WeightModel.model;

namespace Weight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        readonly ISubscriberService _subscriberService;
        readonly IMapper _mapper;
        public SubscriberController(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<BaseResponseGeneral<bool>>> Register([FromBody] SubscriberDTO subscriberDTO)
        {
            var response = await _subscriberService.Register(subscriberDTO);
            if (!response.Succeed)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<BaseResponseGeneral<bool>>> Login([FromBody] LoginDTO loginDTO)
        {
            var response = await _subscriberService.Login(loginDTO.Email, loginDTO.Password);
            if (!response.Succeed)
                return NotFound(response);
            return Ok(response);
        }
    }
}
