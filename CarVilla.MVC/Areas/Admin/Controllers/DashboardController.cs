using CarVilla.DAL.Contexts.AppDbContext;
using Microsoft.AspNetCore.Mvc;

namespace CarVilla.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _a;
    public DashboardController()
    {
        _a = new AppDbContext();
    }
    public IActionResult Index()
    {

        return View(_a.cars.ToList());
    }
}
