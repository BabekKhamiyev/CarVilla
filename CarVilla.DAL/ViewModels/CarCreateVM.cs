using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarVilla.DAL.ViewModels;

public class CarCreateVM
{
    public IFormFile ImgFile { get; set; }
    public int BuraxilisIli { get; set; }
    public int Yurus { get; set; }
    public int AtGucu { get; set; }
    public string SuretlerQutusu { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }


}
