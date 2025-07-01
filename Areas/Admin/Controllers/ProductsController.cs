using System.Threading.Tasks;
using eCommerceProject.Data;
using eCommerceProject.Models;
using eCommerceProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        
        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                ImageService image_service = new ImageService();
                image_service.Delete(product.Image);
                context.Products.Remove(product);
                context.SaveChanges();
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.Categories = context.Categories.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product request,IFormFile? image)
        {
            
           var existingProduct = context.Products.AsNoTracking().FirstOrDefault(p => p.Id == request.Id);
            if (image is not null)
            {
                var imageService = new ImageService();
                string fileName = imageService.UploadImage(image);
                request.Image = fileName;
                imageService.Delete(existingProduct.Image);

            }
            else {
                request.Image= existingProduct.Image;

            }
            context.Products.Update(request);
            context.SaveChanges();
            TempData["success"] = "Product Edit successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create() {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Companies = context.Companies.ToList();
            return View();
        }


        [HttpPost]
        public  IActionResult Create(Product request,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
          
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Companies = context.Companies.ToList();
                return View(request);
            }

            ImageService image_service = new ImageService();
            string fileName = image_service.UploadImage(image);
            request.Image = fileName;
            context.Add(request);
            context.SaveChanges();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
           
        }
    }
}
