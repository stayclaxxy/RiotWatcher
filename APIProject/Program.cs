using APIProject.Controllers;
using APIProject.DataAccess.Services;
using APIProject.Processors;
using APIProject.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IRiotDataAccess, RiotAccessor>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["RiotApiUrl"]);
    client.DefaultRequestHeaders.Add("X-Riot-Token", builder.Configuration["RiotApiKey"]);
});
builder.Services.AddScoped<IAccountDetailsProcessor, AccountDetailsProcessor>();

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
