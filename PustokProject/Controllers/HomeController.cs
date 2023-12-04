using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokProject.Models;
using PustokProject.Persistance;
using System.Diagnostics;

namespace PustokProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using ApplicationDbContext dbContext = new ApplicationDbContext();
            var sliders = await dbContext.Sliders.ToListAsync();

            return View(sliders);
        }

        public IActionResult Privacy()
        {
            throw new NotImplementedException("s");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}