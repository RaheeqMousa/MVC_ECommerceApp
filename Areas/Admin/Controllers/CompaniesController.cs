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

        public IActionResult Delete(int id)
        {
            var company = context.Companies.FirstOrDefault(c => c.Id == id);
            if (company != null)
            {
                context.Companies.Remove(company);
                context.SaveChanges();
                TempData["success"] = "Company deleted successfully";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var company = context.Companies.Find(id);

            return View(company);
        }

        [HttpPost]
        public IActionResult Edit(Company request)
        {

            if (ModelState.IsValid)
            {
                context.Companies.Update(request);
                context.SaveChanges();
                TempData["success"] = "Company Edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
