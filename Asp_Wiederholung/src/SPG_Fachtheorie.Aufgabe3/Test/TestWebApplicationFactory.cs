using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    internal class TestWebApplicationFactory
    {
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SPG_Fachtheorie.Infrastructure;
using System;
using System.Linq;

namespace SPG_Fachtheorie.Aufgabe3.Test
{
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<SchoolContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<SchoolContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<SchoolContext>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    try
                    {
                        // Hier kannst du Testdaten hinzufügen, falls nötig
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ein Fehler beim Seeden der Testdatenbank ist aufgetreten: {ex.Message}");
                    }
                }
            });
        }
    }
}
