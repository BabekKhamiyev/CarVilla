using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarVilla.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarVilla.DAL.Contexts.AppDbContext;

public class AppDbContext:DbContext
{
    private readonly string _connextionString = "Server=DESKTOP-IVCMPDF;Database=CarDb;Trusted_Connection=True;TrustServerCertificate=True;";
   
    public DbSet<Car> cars { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connextionString);
        base.OnConfiguring(optionsBuilder);
    }
}
