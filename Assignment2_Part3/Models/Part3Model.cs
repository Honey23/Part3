using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_Part3.Models
{
    public class Part3Model : DbContext
    {
public Part3Model(DbContextOptions<Part3Model>options) : base(options)
        {

        }

        //reference the item Model for CRUD
        public DbSet<item> items { get; set; }

        public DbSet<store> stores { get; set; }
    }
}
