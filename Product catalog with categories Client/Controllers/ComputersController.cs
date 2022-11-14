using Microsoft.AspNetCore.Mvc;
using Product_catalog_with_categories_Client.Models;
using System.Diagnostics;

namespace Product_catalog_with_categories_Client.Controllers
{
    public class ComputersController : Controller
    {
        private readonly ILogger<ComputersController> _logger;

        public ComputersController(ILogger<ComputersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
}