using CarVilla.BL.Services;
using CarVilla.DAL.Contexts.AppDbContext;
using CarVilla.DAL.Models;
using CarVilla.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarVilla.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class CarController : Controller
{
   
    
    
    
    CarService carService;
    public CarController()
    {
        carService = new CarService();
    }
    public IActionResult Index()
    {
        List<Car> cars =carService.GetAllCar();
        return View(cars);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CarCreateVM car)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("salam");
        }
        carService.Create(car);
        return Redirect(nameof(Index));
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        carService.Delete(id);
        return RedirectToAction("Index","Car");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Car car = carService.GetCarById(id);
        return View(car);

    }

    [HttpPost]
    public IActionResult Update(int id, Car car)
    {
        carService.Update(id,car);

        return RedirectToAction("Index", "Car");
    }
    [HttpGet]
    public IActionResult Info(int id)
    {
        Car car=carService.GetCarById(id);
        return View(car);
    }
}
