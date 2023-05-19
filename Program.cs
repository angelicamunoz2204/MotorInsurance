using MongoDB.Driver;
using MotorInsurance.Database;
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
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDBSettings")
);

//Database
builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings =  builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
