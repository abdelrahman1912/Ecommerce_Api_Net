using AutoMapper;
using ECommerce.db.Base;
using ECommerce.db.Entities;
using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.lib.Servecies
{
    public class CategoryServiecies(Igenralrepo<Category> category, IMapper mapper) : ICategoryServicies
    {
        public async Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            try
            {
                var mapped = mapper.Map<Category>(entity);
                int result = await category.AddAsync(mapped);
                if (result > 0)
                {
                    return new ResponseDto(true, "Successfully");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }

            return new ResponseDto(false, "check your server ");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            int result = await category.DeleteAsync(id);
            if (result > 0)
            {
                return new ResponseDto(true, "Successfully deleted");
            }
            return new ResponseDto(false, "Failed to delete");
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            try
            {
                var data = await category.GetAllAsync();
                if (data == null || !data.Any())
                {
                    return [];
                }
                return mapper.Map<IEnumerable<GetCategoryDto>>(data);
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public async Task<GetCategoryDto> GetById(Guid id)
        {
            try
            {
                var data = await category.GetById(id);
                if (data == null)
                {
                    return new GetCategoryDto();
                }
                return mapper.Map<GetCategoryDto>(data);
            }
            catch
            {
                return new GetCategoryDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity)
        {
            try
            {
                var mapped = mapper.Map<Category>(entity);
                int result = await category.UpdateAsync(mapped);
                if (result > 0)
                {
                    return new ResponseDto(true, "Successfully");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }

            return new ResponseDto(false, "check your server ");
        }
    }
}
