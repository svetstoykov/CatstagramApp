using Catstagram.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catstagram.Server.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        public static IApplicationBuilder AddSwaggerUI(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Catstagram API");
                        c.RoutePrefix = string.Empty;
                    });
        }

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<CatstagramDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
