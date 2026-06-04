using ECommerce.Base;
using ECommerce.db.Entities;
using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Carts;
using Stripe.Checkout;

namespace ECommerce.Servecies.Payments
{
    public class PaymentSrvccs : IPaymentsSrvccs
    {
        public async Task<ResponseDto> Paymoney(decimal totalmount, IEnumerable<Product> products, IEnumerable<CartsDto> carts)
        {
            try
            {
                var lines = new List<SessionLineItemOptions>();
                foreach (var item in products)
                {
                    var proQ = carts.FirstOrDefault(p => p.ProductId == item.Id);
                    lines.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Name,
                                Description = item.Description,
                            },
                            UnitAmount = (long)(item.Price * 100)
                        },
                        Quantity = proQ!.Quantity
                    });
                }
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = { "usd" },
                    LineItems = lines,
                    Mode = "payment",
                    SuccessUrl = "https://localhost:7287/paymentsuccess",
                    CancelUrl = "https://localhost:7287/paymentcancel",
                };
                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return new ResponseDto { success = true, message = session.Url };
            }
            catch (Exception ex) {
                return new ResponseDto { success = false, message = ex.Message }; 
            }     
        }
    }
}
