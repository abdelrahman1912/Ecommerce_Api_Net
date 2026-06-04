using ECommerce.lib.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.lib.Base
{
    public interface IProductServiecies
    {
        Task<IEnumerable<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetById(Guid id);
        Task<ResponseDto> AddAsync(ProductDto entity);
        Task<ResponseDto> UpdateAsync(UpdateProductDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
