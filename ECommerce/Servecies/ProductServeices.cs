using AutoMapper;
using ECommerce.db.Base;
using ECommerce.db.Entities;
using ECommerce.db.Repos;
using ECommerce.lib.Base;
using ECommerce.lib.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Servecies
{
    public class ProductServeices(Igenralrepo<Product> product,IMapper mapper) : IProductServiecies
    {
        public  async Task<ResponseDto> AddAsync(ProductDto entity)
        {
            try {
                var mapped = mapper.Map<Product>(entity);
                int result =await product.AddAsync(mapped);
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
            int result = await product.DeleteAsync(id);
            if (result > 0)
            {
                return new ResponseDto(true, "Successfully deleted");
            }
            return new ResponseDto(false, "Failed to delete");
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            try { 
            var data = await product.GetAllAsync();
            if (data == null || !data.Any())
            {
                return [];
            }
            return mapper.Map<IEnumerable<GetProductDto>>(data);
                }
            catch (Exception ex)
            {
                return [];
            }    
        }

        public async Task<GetProductDto> GetById(Guid id)
        {
            try
            {
                var data = await product.GetById(id);
                if (data == null)
                {
                    return new GetProductDto();
                }
                return mapper.Map<GetProductDto>(data);
            }
            catch  { 
            return new GetProductDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateProductDto entity)
        {
            try
            {
                var mapped = mapper.Map<Product>(entity);
                int result = await product.UpdateAsync(mapped);
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
