using AutoMapper;
using ECommerce.db.Base.Payments;
using ECommerce.lib.Base;
using ECommerce.lib.DTos.Payments;

namespace ECommerce.Servecies.Payments
{
    public class PaymentMethodSrvc(IPaymentMethodRepo repo,IMapper mapper) : IPaymentMethodSrvc
    {
        public async Task<IEnumerable<PaymentsMethodDto>> GetPaymentMethod()
        {
            var method = await repo.GetAllPaymentMethods();

            if(!method.Any()) {
                return [];
            }

            return mapper.Map<IEnumerable<PaymentsMethodDto>>(method);
        }
    }
}
