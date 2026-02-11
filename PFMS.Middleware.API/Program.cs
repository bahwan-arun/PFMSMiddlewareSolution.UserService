using PFMS.Middleware.API.Middlewares;
using PFMS.Middleware.Application;
using PFMS.Middleware.Application.Mappers;
using PFMS.Middleware.Infrastructure;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

//Dependency Injection
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

//Add Auto Mappers
builder.Services.AddAutoMapper(cfg => { }, typeof(UserRegisterationMappingProfile).Assembly);
//builder.Services.AddAutoMapper(rfp => { }, typeof(RegisteredUserMappingProfile).Assembly);

//Add fluent Auto validation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRequestLoggingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
