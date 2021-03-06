﻿using System.Text;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Features.Cats;
using Catstagram.Server.Features.Follows;
using Catstagram.Server.Features.Identity;
using Catstagram.Server.Features.Profiles;
using Catstagram.Server.Features.Search;
using Catstagram.Server.Infrastructure.Filters;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Catstagram.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddDbContext<CatstagramDbContext>(options => options
                    .UseSqlServer(config.GetDefaultConnection()));
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;

                })
                .AddEntityFrameworkStores<CatstagramDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, ApplicationSettings appSettings)
        {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<ICatService, CatService>()
                .AddTransient<IFollowsService, FollowsService>()
                .AddTransient<ISearchService, SearchService>();
        }

        public static ApplicationSettings GetAppSettings(this IServiceCollection services, IConfiguration config)
        {
            var appSettingsConfig = config.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSettingsConfig);

            return appSettingsConfig.Get<ApplicationSettings>();
        }

        public static IMvcBuilder AddNewtonsoftJsonService(this IMvcBuilder services)
        {
            return services.AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Catstagram Api",
                    Version = "v1"
                });
            });
        }

        public static IMvcBuilder AddApiControllers(this IServiceCollection services)
        {
            return services
                .AddControllers(
                    options => options.Filters.Add<ModelOrNotFoundActionFilter>());
        }
    }
}
