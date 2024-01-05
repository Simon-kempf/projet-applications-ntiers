using API.Business;
using API.DataAccess;
using JeBalance.Domain.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICategorieRepository, CategorieRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDenonciationRepository, DenonciationRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();