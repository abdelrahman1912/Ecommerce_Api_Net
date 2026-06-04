using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.lib.DTos
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }


    }
    public class UpdateCategoryDto: CategoryDto
    {
        public Guid Id { get; set; }

    }
    public class GetCategoryDto: CategoryDto
    {
        public Guid Id { get; set; }
        public ICollection<GetProductDto> products { get; set; }
    }
}
