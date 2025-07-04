using eCommerceProject.Data;
using eCommerceProject.Models;
using eCommerceProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        
        ApplicationDBContext context=new ApplicationDBContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(c=> c.Id==id);
            if (category != null) { 
                context.Categories.Remove(category);
                context.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create(int id) {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();
                TempData["success"]="Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category request)
        {

            if (ModelState.IsValid)
            {
                context.Categories.Update(request);
                context.SaveChanges();
                TempData["success"] = "Category Edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
