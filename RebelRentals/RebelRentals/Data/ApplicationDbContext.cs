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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _options = options;
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Ship> Ship { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private DbContextOptions<ApplicationDbContext> _options;
    }
}
