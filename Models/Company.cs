using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eCommerceProject.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name can't be Less than 3 characters")]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public List<Product> products { get; set; }
    }
}
