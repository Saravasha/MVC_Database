using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_Database.Data
{
    public class MVC_DatabaseContext : DbContext
    {
        public MVC_DatabaseContext (DbContextOptions<MVC_DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; } = default!;
    }
}
