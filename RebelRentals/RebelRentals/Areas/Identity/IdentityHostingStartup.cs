using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebelRentals.Areas.Identity.Data;
using RebelRentals.Data;

[assembly: HostingStartup(typeof(RebelRentals.Areas.Identity.IdentityHostingStartup))]
namespace RebelRentals.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RebelRentalsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RebelRentalsContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<RebelRentalsContext>();
            });
        }
    }
}