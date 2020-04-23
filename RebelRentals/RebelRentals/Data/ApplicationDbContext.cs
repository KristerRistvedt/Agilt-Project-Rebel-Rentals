using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Models;
using System.Security.Claims;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipOrder>()
                .HasKey(so => new { so.ShipId, so.OrderId});
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
