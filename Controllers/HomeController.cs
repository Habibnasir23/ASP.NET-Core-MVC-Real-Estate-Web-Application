using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var twoBedProperties = _context.RealEstate.Where(p => p.roomsAvailable == 2).ToList();
            var oneBedProperties = _context.RealEstate.Where(p => p.roomsAvailable == 1).ToList();
            var threeBedProperties = _context.RealEstate.Where(p => p.roomsAvailable == 3).ToList();
            return View(new Tuple<List<RealEstate>, List<RealEstate>, List<RealEstate>>(twoBedProperties, oneBedProperties, threeBedProperties));
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