using GlobalTicket.TicketManagement.Api.Utility;
using GlobalTicket.TicketManagement.Application;
using GlobalTicket.TicketManagement.Infrastructure;
using GlobalTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GlobalTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("open", builder => 
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        } 


        //public static WebApplication ConfigurePipeline(this WebApplication app) 
        //{
        //    app.UseHttpsRedirection();
        //    app.UseRouting();
        //    app.UseCors("open");
        //    app.MapControllers();

        //    return app;
        //}

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "GlobalTicket Ticket Management API"
                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GlobalTicketDbContext>();
                if (context is not null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {

                
            }
        }
    }
}
