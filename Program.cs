using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using MotorInsurance.Database;
using MotorInsurance.Helpers;
using MotorInsurance.Repository.Clients;
using MotorInsurance.Repository.Insurances;
using MotorInsurance.Repository.InsuranceTypes;
using MotorInsurance.Repository.Vehicles;
using MotorInsurance.Services.Clients;
using MotorInsurance.Services.Insurances;
using MotorInsurance.Services.InsuranceTypes;
using MotorInsurance.Services.Vehicles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotorInsuranceAPI", Version = "v1" });
    c.AddSecurityDefinition(JWTAuthenticationDefaults.AuthenticationScheme,
    new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = JWTAuthenticationDefaults.HeaderName,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JWTAuthenticationDefaults.AuthenticationScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings")
);

//Database
builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

//Repositories
builder.Services.AddSingleton<IInsuranceTypesRepository, InsuranceTypesRepository>();
builder.Services.AddSingleton<IInsurancesRepository, InsurancesRepository>();
builder.Services.AddSingleton<IClientsRepository, ClientsRepository>();
builder.Services.AddSingleton<IVehiclesRepository, VehiclesRepository>();

//Services
builder.Services.AddSingleton<IInsuranceTypesService, InsuranceTypesService>();
builder.Services.AddSingleton<IInsurancesService, InsurancesService>();
builder.Services.AddSingleton<IClientsService, ClientsService>();
builder.Services.AddSingleton<IVehiclesService, VehiclesService>();

// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(x =>
{
    x.Authority = "https://localhost:7234"; //idp address
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.Configuration = new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration();
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    IdentityModelEventSource.ShowPII = true;

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();