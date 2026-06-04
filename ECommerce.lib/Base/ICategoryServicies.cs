using ECommerce.lib.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.lib.Base
{
    public interface ICategoryServicies
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetById(Guid id);
        Task<ResponseDto> AddAsync(CategoryDto entity);
        Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
