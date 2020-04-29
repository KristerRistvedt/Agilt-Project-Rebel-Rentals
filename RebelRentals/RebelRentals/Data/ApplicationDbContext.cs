using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RebelRentals.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ShipOrder> ShipOrder { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<Order> Order { get; set; }

        //public void SeedShipData()
        //{
        //    Ship.RemoveRange();
        //    this.SaveChanges();
        //    Ship.AddRange(
        //        new Ship
        //        {
        //            Model = "A-Wing",
        //            NumberOfPopulation = 1,
        //            Class = "Interception starfighter",
        //            MaxSpeed = 1300,
        //            Length = 7,
        //            Width = 4,
        //            Height = 2,
        //            Price = 600,
        //            About = "They are the fastest vessels in the Star Wars canon.",
        //        },
        //         new Ship
        //         {
        //             Model = "Death Star",
        //             NumberOfPopulation = 250000,
        //             Class = "Space Battle Station",
        //             MaxSpeed = 1000000,
        //             Length = 120,
        //             Width = 120,
        //             Height = 120,
        //             Price = 5000,
        //             About = "Faster than light speed.",
        //         },
        //          new Ship
        //          {
        //              Model = "Salvation",
        //              NumberOfPopulation = 834,
        //              Class = "Frigate",
        //              MaxSpeed = 800,
        //              Length = 300,
        //              Width = 72,
        //              Height = 166,
        //              Price = 2000,
        //              About = "Generally well-armed for a vessel of that size.",
        //          },
        //           new Ship
        //           {
        //               Model = "Star Destroyer",
        //               NumberOfPopulation = 10000,
        //               Class = "Star Destroyer",
        //               MaxSpeed = 975,
        //               Length = 1600,
        //               Width = 600,
        //               Height = 500,
        //               Price = 3500,
        //               About = "The signature vessel of the fleet.",
        //           },
        //            new Ship
        //            {
        //                Model = "Tie Fighter",
        //                NumberOfPopulation = 1,
        //                Class = "Space superiority fighter",
        //                MaxSpeed = 1200,
        //                Length = 7,
        //                Width = 6,
        //                Height = 9,
        //                Price = 300,
        //                About = "They are fast, agile, yet fragile starfighters.",
        //            },
        //             new Ship
        //             {
        //                 Model = "X-Wing",
        //                 NumberOfPopulation = 1,
        //                 Class = "Space superiority fighter",
        //                 MaxSpeed = 1050,
        //                 Length = 13,
        //                 Width = 11,
        //                 Height = 2,
        //                 Price = 400,
        //                 About = "Named for the distinctive shape made when its wings are in attack position.",
        //             },
        //              new Ship
        //              {
        //                  Model = "Y-Wing",
        //                  NumberOfPopulation = 1,
        //                  Class = "	Assault starfighter/bomber",
        //                  MaxSpeed = 1000,
        //                  Length = 23,
        //                  Width = 8,
        //                  Height = 2,
        //                  Price = 350,
        //                  About = "Prized for its durability and long-range striking capability.",
        //              }
        //        );
        //    SetIdentityOn();
        //    SaveChanges();
        //    SetIdentityOff();
        //}

        public void SetIdentityOn()
        {
            this.Database.OpenConnection();
            this.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ship ON");
            this.SaveChanges();
        }

        public void SetIdentityOff()
        {
            this.Database.OpenConnection();
            this.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ship OFF");
            this.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipOrder>()
                .HasKey(so => new { so.ShipId, so.OrderId });
            modelBuilder.Entity<ShipOrder>()
                .HasOne(so => so.Ship)
                .WithMany(s => s.ShipOrders)
                .HasForeignKey(so => so.ShipId);
            modelBuilder.Entity<ShipOrder>()
                .HasOne(so => so.Order)
                .WithMany(o => o.ShipOrders)
                .HasForeignKey(o => o.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
