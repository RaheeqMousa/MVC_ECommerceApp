using eCommerceProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin
{
    [Area("Admin")]
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
