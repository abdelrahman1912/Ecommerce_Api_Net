using AutoMapper;
using ECommerce.Base;
using ECommerce.db.Base;
using ECommerce.db.Entities;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Carts;
using ECommerce.db.Base;
using ECommerce.lib.Base;

namespace ECommerce.Servecies
{
    public class CartSrvc(ICart cart,IMapper mapper,Igenralrepo<Product> igenralrepo ,IPaymentMethodSrvc paymentMethodSrvc,IPaymentsSrvccs paymentsSrvccs) : ICartsSrvc
    {
        public async Task<ResponseDto> Dbcheckout(CheckoutDto checkout, string userId)
        {
            var (products, amount) = await GetCartamount(checkout.Carts);
            var method = await paymentMethodSrvc.GetPaymentMethod();
            if (method != null&&checkout.paymentmethodID==method.FirstOrDefault()!.Id)
            { 
            var result =await paymentsSrvccs.Paymoney(amount, products,checkout.Carts);
            return result;
            }
            return new ResponseDto(false, "Invalid payment method.");
        }

        public async Task<(IEnumerable<Product>,decimal)>GetCartamount(IEnumerable<CartsDto> cartItems) { 
           if(!cartItems.Any())
               return ([], 0);
           var products= await igenralrepo.GetAllAsync();
            if (!products.Any())
                return ([], 0);
            var cartproducts = cartItems.Select(ci => products.FirstOrDefault(p => p.Id == ci.ProductId)).Where(p => p != null).ToList();
            var totalAmount = cartItems.Where(i=>cartproducts.Any(p=>p.Id==i.ProductId)).Sum(i => i.Quantity * cartproducts.First(p => p.Id == i.ProductId).Price);
            return (cartproducts, totalAmount!.Value);
        }

        public async Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistoryDto> checkouts)
        {
            var mapped=mapper.Map<IEnumerable<ProductHistory>>(checkouts);
            var result=await cart.SaveCheckoutHistory(mapped);
            ResponseDto responseDto = new ResponseDto(true, "Checkout history saved successfully.");
            if (result <= 0) 
                { 
                    responseDto=new ResponseDto(false, "Failed to save checkout history.");
                }
            return responseDto;

        }
    }
}
