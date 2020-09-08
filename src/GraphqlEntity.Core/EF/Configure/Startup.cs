using GraphqlEntity.Core.EF.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphqlEntity.Core.EF.Configure
{
    public static class Startup
    {
        public static IServiceCollection ServiceData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<GraphqlEntityContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("GraphqlEntityContext")));

            services.AddScoped<GraphqlEntityContext>();

            return services;
        }
        public static IApplicationBuilder InitializeData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GraphqlEntityContext>();
                    context.Database.Migrate();

                    context
                    .AddUser()
                    .Commit();

            }

            return app;
        }


    }
}
