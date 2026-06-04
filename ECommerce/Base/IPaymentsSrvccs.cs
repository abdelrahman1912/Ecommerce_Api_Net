using Azure;
using ECommerce.db.Entities;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Carts;

namespace ECommerce.Base
{
    public interface IPaymentsSrvccs
    {
        Task<ResponseDto> Paymoney(decimal totalmount, IEnumerable<Product> products ,IEnumerable<CartsDto> carts);
    }
}
