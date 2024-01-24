using API_Secrete.DataAccess;
using API_Secrete.Business;
using Microsoft.EntityFrameworkCore;
using JeBalance.Infrastructure.SQLServer;
using JeBalance.Infrastructure;
using API_Secrete;
using JeBalance.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("localdb")),
contextLifetime: ServiceLifetime.Scoped,
optionsLifetime: ServiceLifetime.Transient);

builder.Services.AddInfrastructure();
builder.Services.AddAPI_Secrete();
builder.Services.AddDomain();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IVIPListRepository, VIPListRepository>();

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
