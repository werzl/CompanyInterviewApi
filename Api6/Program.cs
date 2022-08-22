using System.Text.Json;
using Core;
using Core.Commands;
using Core.Storage;

namespace Api6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
        }
    }
}