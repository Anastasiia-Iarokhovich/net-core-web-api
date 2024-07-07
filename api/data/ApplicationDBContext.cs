using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.data
{
    public class ApplicationDBContext : DbContext
    {    
        public DbSet<Order> Orders { get; set;} 
        public DbSet<Product> Products { get; set;}

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(y => y.Orders)
                .UsingEntity(j => j.ToTable("OrderProducts"));
        }

    }
}