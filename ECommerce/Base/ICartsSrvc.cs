using ECommerce.db.Entities;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Carts;

namespace ECommerce.Base
{
    public interface ICartsSrvc
    {
        public  Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistoryDto> checkouts);
            
        Task<ResponseDto> Dbcheckout(CheckoutDto checkout, string userId);
    }
}
