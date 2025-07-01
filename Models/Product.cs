using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eCommerceProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name can't be Less than 3 characters")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }     
       
        public string Description { get; set; }
        [Range(0,10000)]
        public decimal price { get; set; }
        [Range(0,500)]
        public int Quantity { get; set; }
        [Range(0,5)]
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public string? Image { get; set; }  

        public int CategoryId { get; set; }

        [ValidateNever]
        public List<Category> Category { get; set; }

        public int CompanyId { get; set; }

        [ValidateNever]
        public Company Company { get; set; }
    }
}
