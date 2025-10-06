using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);


// add infrastrucre & core services

builder.Services.AddInfrastructure();
builder.Services.AddCore();

// add controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // convert string to enum
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// add only one auto mapper config and all profiles will be registered
builder.Services.AddAutoMapper(cfg => {}, typeof(ApplicationUserMappingProfile).Assembly);


// adding fluent validations
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();

//adding the middleware
app.UseExceptionHandlingMiddleware();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
