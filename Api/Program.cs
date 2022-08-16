using System.Text.Json;
using Api;
using Api.Commands;
using Api.Controllers;
using Api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var startingData = JsonSerializer.Deserialize<List<CompanyModel>>(File.ReadAllText("StartingData.json"), new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
});

builder.Services.AddTransient<ICommand<BuyoutRequest>, BuyoutCommand>();
builder.Services.AddSingleton<IStore>(new Store(startingData));

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
