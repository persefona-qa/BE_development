using NDubko.Api;
using NDubko.Api.Mapping;
using NDubko.Application.Commands.Authors;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.ConfigureOptions(configuration); //Task for #8 Configuration
builder.Services.AddAuth(); //Task for #6 Create Authentication and Authorization method (Bearer token / JWT)

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AuthorProfile).Assembly); //Task for #3
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateAuthorCommandHandler>()); //Task for #5

builder.Services.AddDb(configuration); //Task for #4
builder.Services.AddCustomExceptionHandling();

builder.Services.AddHealthChecks();//Task for #9 Basic HealthCheck

var app = builder.Build();

app.UseExceptionHandler(); //Task for #7 Exceptions Handlings
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health"); //Task for #9 Basic HealthCheck
app.Run();
