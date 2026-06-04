using ECommerce.lib.DTos;
using FluentValidation;

namespace ECommerce.Base
{
    public interface IValidateSrvc
    {
        Task<ResponseDto> ValidateAsync<T>(T model,IValidator<T> validator);
    }
}
