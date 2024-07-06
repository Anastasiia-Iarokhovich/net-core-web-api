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
        // public DbSet<OrderProduct> OrderProducts { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<OrderProduct>()
            //     .HasKey(op => new { op.OrderId, op.ProductId });

            // modelBuilder.Entity<OrderProduct>()
            //     .HasOne(op => op.Order)
            //     .WithMany(o => o.OrderProducts)
            //     .HasForeignKey(op => op.OrderId);

            // modelBuilder.Entity<OrderProduct>()
            //     .HasOne(op => op.Product)
            //     .WithMany(p => p.OrderProducts)
            //     .HasForeignKey(op => op.ProductId);


                modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(y => y.Orders)
                .UsingEntity(j => j.ToTable("OrderProducts"));
        }

    }
}