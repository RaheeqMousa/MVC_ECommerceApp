using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace eCommerceProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ValidateNever]
        public List<Product> products { get; set; }
    }
}
