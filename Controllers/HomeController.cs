using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eCommerceProject.Models;
using eCommerceProject.Data;

namespace eCommerceProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    ApplicationDBContext context = new ApplicationDBContext();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.categories=context.Categories.ToList();
        ViewBag.products = context.Products.ToList();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
