using eCommerceProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Customer
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            ViewBag.categories = context.Categories.ToList();
            ViewBag.products = context.Products.ToList();
            return View();
        }
    }
}
