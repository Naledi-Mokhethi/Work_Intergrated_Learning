﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Models;

namespace Work_Intergrated_Learning.Data
{
    public class WilDbContext : DbContext
    {
        public WilDbContext(DbContextOptions<WilDbContext> options):base(options)
        {

        }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}