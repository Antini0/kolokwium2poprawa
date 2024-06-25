using kolokwium2poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2poprawa.Data;

public class myContext : DbContext
{
    public myContext()
    {
    }

    public myContext(DbContextOptions<myContext> options) : base(options)
    {
    }
    
    public DbSet<Color> Colors { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Car_Rental> CarRentals { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Client>().HasData(new List<Client>
            {
                new Client {
                    IdClient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Adress = "zzz"
                },
                new Client {
                    IdClient = 2,
                    FirstName = "cc",
                    LastName = "pp",
                    Adress = "fff"
                },
            });
        
        modelBuilder.Entity<Color>().HasData(new List<Color>
        {
            new Color {
                IdColor = 1,
                Name = "zielony",
            },
            new Color {
                IdColor = 2,
                Name = "czerwony",
            },
        });
        
        modelBuilder.Entity<Model>().HasData(new List<Model>
        {
            new Model {
                IdModel = 1,
                Name = "kombi",
            },
            new Model {
                IdModel = 2,
                Name = "cos",
            },
        });
        
        modelBuilder.Entity<Car>().HasData(new List<Car>
        {
            new Car {
                IdCar = 1,
                VIN = "gggg",
                Name = "dacia",
                Seats = 4,
                PricePerDay = 100,
                IdModel = 1,
                IdColor = 1
            },
            new Car {
                IdCar = 2,
                VIN = "vvvv",
                Name = "porche",
                Seats = 6,
                PricePerDay = 300,
                IdModel = 2,
                IdColor = 1
            },
        });
        
        modelBuilder.Entity<Car_Rental>().HasData(new List<Car_Rental>
        {
            new Car_Rental {
                IdCar_Rental = 1,
                IdClient = 1,
                IdCar = 1,
                DateFrom = new DateTime(2024, 11, 01),
                DateTo = new DateTime(2023, 10, 02),
                TotalPrice = 1000,
                Disscount = 15
            },
            new Car_Rental {
                IdCar_Rental = 2,
                IdClient = 2,
                IdCar = 2,
                DateFrom = new DateTime(2022, 11, 01),
                DateTo = new DateTime(2021, 11, 02),
                TotalPrice = 500,
            },
        });

    }
    
}