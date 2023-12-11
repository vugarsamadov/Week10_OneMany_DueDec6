using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokProject.Models;
using PustokProject.Persistance;
using System.Diagnostics;
using PustokProject.CoreModels;
using PustokProject.ViewModels.Books.Non_Admin;

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
        
            var model = new VM_Home();
            model.Sliders = await dbContext.Sliders.Where(b=>!b.IsDeleted).ToListAsync();
            model.Books = await dbContext.Books.Where(b=>!b.IsDeleted).ToListAsync();
            model.BooksAbove20Perc = await dbContext.Books.Where(b=>!b.IsDeleted && b.DiscountPercentage > 20).ToListAsync();
            model.BooksChildren = await dbContext.Books
                .Include(b=>b.Category)
                .Where(b=>!b.IsDeleted && b.Category.Name == "Children")
                .ToListAsync();
            return View(model);
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