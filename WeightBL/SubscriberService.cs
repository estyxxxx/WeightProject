using AutoMapper;
using WeightDAL;
using WeightCORE.DTO;
using WeightModel.model;
using WeightCORE.Response;
using System.Text.RegularExpressions;

namespace WeightBL
{
    public class SubscriberService : ISubscriberService
    {
        readonly ISubscriberRepository _subscriberRepository;
        readonly IMapper _mapper;
        public SubscriberService(ISubscriberRepository repository, IMapper mapper)
        {
            _subscriberRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponseGeneral<bool>> Register(SubscriberDTO subscriberDTO)
        {
            BaseResponseGeneral<bool> response = await _subscriberRepository.Register(_mapper.Map<Subscriber>(subscriberDTO), subscriberDTO.Height);
            if (!await _subscriberRepository.IsEmailExist(subscriberDTO.Email))
            {
                response.Succeed = false;
                response.Status = "The email already exists";
            }
            return response;
        }
        public async Task<BaseResponseGeneral<CardDTO>> Login(string email, string password)
        {
            BaseResponseGeneral<Card> response = await _subscriberRepository.Login(email, password);
            if(!IsValidEmail(email) || !IsValidPassword(password))
            {
                response.Response = null;
                response.Succeed = false;
                response.Status = "Invalid email or password";
            }
            return _mapper.Map<BaseResponseGeneral<CardDTO>>(response);
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }
    }
}