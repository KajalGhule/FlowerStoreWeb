using System.Diagnostics;
using Catalog;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Models;

namespace StoreWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    List<Product> allProducts = Catalog.ProductManager.GetAllProducts();
        //    this.ViewData["products"] = allProducts;
        //    return View();
        //}
       
        public async Task<IActionResult> Index()
        {
            List<Product> allProducts = await Catalog.ProductManager.GetAllProducts();
            this.ViewData["products"] = allProducts;
            return View();
        }

        //public ActionResult Details(int id)
        //{
        //    Product Product = Catalog.ProductManager.Get(id);
        //    this.ViewData["product"] = Product;
        //    return View();
        //}

        public async Task<IActionResult> Details(int id)
        {
            Product product = await Catalog.ProductManager.Get(id); // Ensure Get() is async
            this.ViewData["product"] = product;
            return View();
        }

    }
}
