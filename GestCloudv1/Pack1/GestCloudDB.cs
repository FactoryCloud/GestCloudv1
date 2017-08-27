using System;
using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;

namespace Pack1.v1
{
    class GestCloudDB
    {
        public class Northwind : DbContext
        {
            // properties that map to the tables in the db
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // for Microsoft SQL Server
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" +
                    "Integrated Security=true;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Example of fluent API instead of attributes
                modelBuilder.Entity<Category>().Property(category => category.CategoryName).IsRequired().HasMaxLength(40);
            }
        }
    }
}
