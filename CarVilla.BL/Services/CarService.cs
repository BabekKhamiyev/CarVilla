using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarVilla.BL.Exceptions;
using CarVilla.DAL.Contexts.AppDbContext;
using CarVilla.DAL.Models;
using CarVilla.DAL.ViewModels;

namespace CarVilla.BL.Services;

public class CarService
{
    private readonly AppDbContext _context;
    public CarService()
    {
        _context = new AppDbContext();
    }


    #region Create
    public void Create(CarCreateVM carVM)
    {
        Car car = new Car();
        car.SuretlerQutusu = carVM.SuretlerQutusu;
        car.Yurus = carVM.Yurus;
        car.AtGucu = carVM.AtGucu;
        car.Brand = carVM.Brand;
        car.BuraxilisIli = carVM.BuraxilisIli;
        car.Description = carVM.Description;
        car.Model = carVM.Model;
        car.Price = carVM.Price;


        string fileName = Path.GetFileNameWithoutExtension(carVM.ImgFile.FileName);
        string extension = Path.GetExtension(carVM.ImgFile.FileName);
        string resultName=fileName+Guid.NewGuid().ToString()+extension;

        string uploadedPath = $"C:\\Users\\User\\source\\repos\\CarVilla\\CarVilla.MVC\\wwwroot\\assets\\UploadedImages";
        
        uploadedPath=Path.Combine(uploadedPath,resultName);
        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
        carVM.ImgFile.CopyTo(stream);
        car.ImgUrl= resultName;







        _context.Add(car);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public List<Car> GetAllCar()
    {
        List<Car> cars =_context.cars.ToList();
        return cars;
    }



    public Car GetCarById(int id)
    {
        Car? car = _context.cars.Find(id);
        if (car is null)
        {
            throw new CarException($"database {id} idli masin yoxdu");
        }
        return car;
    }
    #endregion

    #region Update
    public void Update(int id, Car car)
    {
        if (car.Id != id)
        {
            throw new CarException("idler ust uste dusmur");
        }
        Car? basecar= _context.cars.Find(id);
        if (basecar is null)
        {
            throw new CarException($"database {id} idli masin yoxdu");
        }
        basecar.SuretlerQutusu=car.SuretlerQutusu;
        basecar.Yurus=car.Yurus;
        basecar.AtGucu=car.AtGucu;
        basecar.Brand=car.Brand;
        basecar.BuraxilisIli=car.BuraxilisIli;
        basecar.Description=car.Description;
        basecar.Model=car.Model;
        basecar.ImgUrl=car.ImgUrl;
        basecar.Price=car.Price;
        _context.SaveChanges();
    }

    #endregion

    #region Delete

    public void Delete(int id)
    {
        Car car = _context.cars.Find(id);
       
        _context.cars.Remove(car);
        _context.SaveChanges();
    }
    #endregion
}
