using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.db.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 100 characters.")]
        
        public string? Name { get; set; }
        public string? PName { get; set; }

        [MaxLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string ? Description { get; set; }
        [Column(TypeName = "decimal(16,4)")]
         public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
