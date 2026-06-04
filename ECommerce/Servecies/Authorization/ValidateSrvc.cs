using ECommerce.Base;
using ECommerce.lib.DTos;
using ECommerce.Validations.Identity;
using FluentValidation;
using Microsoft.AspNet.Identity;

namespace ECommerce.Servecies.Authorization
{
    public class ValidateSrvc : IValidateSrvc
    {
        public async Task<ResponseDto> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var _validator = await validator.ValidateAsync(model);
            if (!_validator.IsValid)
            {
                var error=_validator.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join(", ", error);
                return new ResponseDto
                {
                    message = errorMessage
                };
            }
            return new ResponseDto
            {
                success = true,
               
            };
        }
    }
}
