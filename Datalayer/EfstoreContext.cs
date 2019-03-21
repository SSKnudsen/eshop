using Microsoft.EntityFrameworkCore;
using System;
using WebstoreConsole.Datalayer;
using WebstoreConsole.Entities;

namespace Datalayer
{
    public class EfstoreContext : DbContext
    {

        public DbSet<Orders> Orders { get; set; }
        public DbSet<Productinfo> Prodinfo { get; set; }
        public DbSet<Products> Po { get; set; }
        public DbSet<Shopbasket> shopbaskets { get; set; }
        public DbSet<Userinformation> userinf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebstoreDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PK
            modelBuilder.Entity<Orders>()
                .HasKey(b => b.OrderId)
                .HasName("OrderId");

            modelBuilder.Entity<Productinfo>()
                .HasKey(b => b.productinfoID)
                .HasName("productinfoID");
            
            modelBuilder.Entity<Products>()
                .HasKey(b => b.ClothingID)
                .HasName("ClothingID");

            modelBuilder.Entity<Shopbasket>()
                .HasKey(b => b.Checkout_id)
                .HasName("Checkout_id");

            modelBuilder.Entity<Userinformation>()
                .HasKey(b => b.id)
                .HasName("id");






        }



        }
    }
