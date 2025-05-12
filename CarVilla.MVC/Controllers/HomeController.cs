
using CarVilla.DAL.Contexts.AppDbContext;
using CarVilla.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarVilla.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index()
        {
            List<Car> cars=_context.cars.ToList();
            return View(cars);
        }
    }
}
