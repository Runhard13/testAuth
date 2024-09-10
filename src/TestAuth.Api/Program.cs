using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using TestAuth.Api.Controllers.Base;
using TestAuth.Api.Filters;
using TestAuth.Core;
using TestAuth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddMvc(options =>
    {
        options.Conventions.Add(new ControllerNameConvention());
        options.Filters.Add(new ModelValidationFilter());
    });
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);


builder.Services.RegisterCore();
builder.Services.RegisterInfrastructure(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseInfrastructure();
await app.Services.InitializeDatabase();

app.MapControllers();

await app.RunAsync();
