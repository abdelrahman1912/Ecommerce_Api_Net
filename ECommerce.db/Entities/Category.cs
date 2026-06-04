using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.db.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
    }
}
