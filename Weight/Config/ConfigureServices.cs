using AutoMapper;
using WeightBL;
using WeightDAL;

namespace Weight.Config
{
    public static class ConfigureServices
    {
        public static void Configuration(this IServiceCollection services)
        {

            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
