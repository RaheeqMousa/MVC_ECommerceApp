using eCommerceProject.Data;
using eCommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var companies = context.Companies.ToList();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company request)
        {
            if (ModelState.IsValid)
            {
                context.Companies.Add(request);
                context.SaveChanges();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
