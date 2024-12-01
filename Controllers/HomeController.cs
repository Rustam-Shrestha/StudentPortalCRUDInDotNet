using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using System.Diagnostics;

namespace StudentPortal.Controllers
{
//home controller for corntrolling requests that comes from home page
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //viewing maing part of page
        public IActionResult Index()
        {
            return View();
        }

        //view privacy and footer part of pagbe
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
// end

