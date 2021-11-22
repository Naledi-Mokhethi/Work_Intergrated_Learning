using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Data
{
    public class WilDbContext : IdentityDbContext<AppUser>
    {
        public WilDbContext(DbContextOptions<WilDbContext> options):base(options)
        {

        }
      
        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Jobs> Jobs { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Page> Pages { get; set; }

    }
}
