

using GlobalTicket.TicketManagement.Api.Middleware;

namespace GlobalTicket.TicketManagement.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //
            var app = builder.ConfigureServices();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalTicket Ticket Management API");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCustomExceptionHandler();

            app.UseCors("open");

            app.MapControllers();

            await app.ResetDatabaseAsync();   

            app.Run();
        }
    }
}
