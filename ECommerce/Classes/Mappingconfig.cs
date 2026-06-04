using AutoMapper;
using ECommerce.db.Entities;
using ECommerce.db.Entities.Identity;
using ECommerce.db.Entities.Payments;
using ECommerce.lib.DTos;
using ECommerce.lib.DTos.Carts;
using ECommerce.lib.DTos.Identity;
using ECommerce.lib.DTos.Payments;

namespace ECommerce.Classes
{
    public class Mappingconfig: Profile
    {
        public Mappingconfig()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, GetProductDto>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateUser,AppUser>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName)); ;
            CreateMap<LoginUser, AppUser>();
            CreateMap<PaymentsMethodDto,PaymentMethod>();
            CreateMap<ProductHistoryDto,ProductHistory>(); 

        }
    }
}
