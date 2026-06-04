using ECommerce.db.Base;
using ECommerce.db.Base.Authintcation;
using ECommerce.db.Context;
using ECommerce.db.Entities;
using ECommerce.db.Entities.Identity;
using ECommerce.db.Repos;
using ECommerce.db.Repos.Authintcation;
using ECommerce.lib.Base;
using FluentValidation;
using FluentValidation.AspNetCore;
using ECommerce.lib.Exeptions;
using ECommerce.lib.Serviceis;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.db.Entities.Payments;
using ECommerce.db.Base.Payments;

namespace ECommerce.db.Servicies
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddInjectionsDB(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MyConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);

                    sqlOptions.EnableRetryOnFailure();
                }).UseExceptionProcessor(),
                ServiceLifetime.Scoped);

            services.AddScoped<Igenralrepo<Category>, GenralRepo<Category>>();
            services.AddScoped<Igenralrepo<Product>, GenralRepo<Product>>();

            services.AddScoped(typeof(IAppLoger<>), typeof(SerilogAdaptor<>));

            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                options.SignIn.RequireConfirmedAccount = true;

                options.Tokens.EmailConfirmationTokenProvider =
                    TokenOptions.DefaultEmailProvider;

            }).AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<AppDbContext>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;

                options.DefaultScheme =
                    JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;

                options.TokenValidationParameters =
                    new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],

                        IssuerSigningKey =
                            new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                                System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                            )
                    };
            });
            services.AddScoped<IUserMang, UserMang>();
            services.AddScoped<IRoleMang, RoleMang>();
            services.AddScoped<ITokenMang, TokenMang>();
            services.AddScoped<IPaymentMethodRepo, PaymentMethodRepo>();
            return services;
        }

        public static IApplicationBuilder AddMiddlewareDB(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExiptionHandleMiddle>();

            return app;
        }
    }
}