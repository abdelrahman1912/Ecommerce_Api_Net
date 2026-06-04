using ECommerce.Base;
using ECommerce.lib.Base;
using ECommerce.lib.Servecies;
using ECommerce.Servecies;
using ECommerce.Servecies.Authorization;
using ECommerce.Servecies.Payments;
using ECommerce.Validations.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Security.Principal;

namespace ECommerce.Classes
{
    public static class SrvContainer
    {
        public static IServiceCollection AddInjectionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mappingconfig));
            services.AddScoped<IProductServiecies, ProductServeices>();
            services.AddScoped<ICategoryServicies, CategoryServiecies>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
            services.AddScoped<IValidateSrvc, ValidateSrvc>();
            services.AddScoped<IAuthintcationSrvc, AuthintcationSrvc>();
            services.AddScoped<IPaymentsSrvccs, PaymentSrvccs>();
            return services;
        }

    }
}
