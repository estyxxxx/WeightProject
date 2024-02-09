using Microsoft.EntityFrameworkCore;
using Serilog;
using Weight.Config;
using WeightModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.Configuration();
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddDbContext<WeightContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("WeightConnectionString"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy => {
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
})
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapControllers();
app.UseMiddleware(typeof(Middleware));
app.Run();
