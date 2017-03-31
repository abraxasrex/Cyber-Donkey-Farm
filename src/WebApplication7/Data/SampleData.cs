using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class SampleData
    {
        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();
            await db.Database.EnsureCreatedAsync();

            if (!db.Donkeys.Any())
            {
                db.Donkeys.AddRange(
                    new Donkey { name = "Cargoo", color = "red" },
                    new Donkey { name = "Billard", Director = "green" });
                db.SaveChanges();
            }
        }

    }
}
