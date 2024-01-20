using GlobalTicket.TicketManagement.Application;
using GlobalTicket.TicketManagement.Infrastructure;
using GlobalTicket.TicketManagement.Persistence;

namespace GlobalTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="builder"></param>
        ///// <returns></returns>
        //public static WebApplication ConfigureServices(this WebApplicationBuilder builder) 
        //{
        //    builder.Services.AddPersistenceService(builder.Configuration);
        //    builder.Services.AddApplicationServices();
        //    builder.Services.AddInfrastructureServices(builder.Configuration);

        //    builder.Services.AddCors(option =>
        //    {
        //        option.AddPolicy("open", builder => 
        //        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        //    });

        //    return builder.Build();
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="app"></param>
        ///// <returns></returns>
        //public static WebApplication ConfigurePipeline(this WebApplication app ) 
        //{
        //    app.UseHttpsRedirection();
        //    app.UseRouting();
        //    app.UseCors("open");
        //    app.MapControllers();
        //    return app;
        //}


    }
}
