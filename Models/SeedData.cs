using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using MVC_Data.Models;
using MVC_Database;
using MVC_Database.Data;

namespace MVC_Database.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVC_DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MVC_DatabaseContext>>()))
            {
                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                    new Person
                    {
                        Id = 1,
                        Name ="Siavash Gosheh",
                        PhoneNumber = "hail santa",
                        City = "Gothenburg"
                    },

                    new Person
                    {
                        Id = 2,
                        Name = "Maxwell T Bird",
                        PhoneNumber = "hahahahaha",
                        City = "Near Harrisburg, Pennsylvania"
                    },

                    new Person
                    {
                        Id = 3,
                        Name = "Santa",
                        PhoneNumber = "Abstract",
                        City = "Tinkletown"
                    },

                    new Person
                    {
                        Id = 4,
                        Name = "Gerpgork",
                        PhoneNumber = "hey ho",
                        City = "Turkmenistan"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
