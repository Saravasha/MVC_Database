using Microsoft.EntityFrameworkCore;
using MVC_Data.Models;

namespace MVC_Database.Data
{
    public class MVC_DbContext : DbContext
    {
        public MVC_DbContext(DbContextOptions<MVC_DbContext> options)
            : base(options)
        {

        }

        public DbSet<Person> Person { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);


            modelbuilder.Entity<Person>().HasData(new Person { Id = 1, Name = "Siavash Gosheh", PhoneNumber = "xxxx-xxx666", City = "Gothenburg" });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 2, Name = "Maxwell T Bird", PhoneNumber = "Mr. Max Tv @ Youtube", City = "Central Pennsylvania" });
            modelbuilder.Entity<Person>().HasData(new Person { Id = 3, Name = "Nergal", PhoneNumber = "666", City = "Gdansk" });
        }
    }
}

