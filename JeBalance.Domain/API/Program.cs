using API.Business;
using API.DataAccess;
using JeBalance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using JeBalance.Infrastructure.SQLServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDenonciationRepository, DenonciationRepository>();

builder.Services.AddDbContext<DatabaseContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("localdb")),
contextLifetime: ServiceLifetime.Scoped,
optionsLifetime: ServiceLifetime.Transient);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();