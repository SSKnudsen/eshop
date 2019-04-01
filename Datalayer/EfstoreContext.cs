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
        public DbSet<Products> Products { get; set; }
        public DbSet<Shopbasket> shopbaskets { get; set; }
        public DbSet<Userinformation> userinformtation { get; set; }

        public EfstoreContext()
        { }

        public EfstoreContext(DbContextOptions<EfstoreContext> options)
            : base(options)
        { }


        /// <summary>
        /// Kun TIL TEST!
        /// </summary>
        /// <param name="modelBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BloggingDb; Trusted_Connection = True;");
        //    }
        //}

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
            //Products
            //   modelBuilder.Entity<Products>().HasData(new { ClothingID = 1, name = "Adiddas A1 Running", Description = "Running Shoe with special Gel", price = 300, status = "Instock" });
            //modelBuilder.Entity<Products>().HasData(new { ClothingID = 2, name = "Ecco Leather Shoe", Description = "Leather shoe with antistatic know ", price = 800, status = "Instock" });
            //modelBuilder.Entity<Products>().HasData(new { ClothingID = 3, name = "Adiddas A2 Running", Description = "Running Shoe with special Gel and antiShock Absorber", price = 1000, status = "NotInstock" });
            //modelBuilder.Entity<Products>().HasData(new { ClothingID = 4, name = "Asics - new Sensation", Description = "Running Shoe with special Gel", price = 2000, status = "Instock" });

            //productinfo
            modelBuilder.Entity<Userinformation>().HasData(new
            {

                id = 1,
                fullname = "peter petersen",
                dateofbirth = DateTime.Now,
                Address = "petersvej 1",
                city = "petersborg",
                email = "Peter@gmail.com",
                CountryCode = 7600,
                paymentO = "MasterCard"

            });

            modelBuilder.Entity<Userinformation>().HasData(new
            {
                id = 2,
                fullname = "Anders Andersen",
                dateofbirth = DateTime.Now,
                Address = "AndersVej  1",
                city = "Andersborg",
                CountryCode = 7600,
                email = "anders@gmail.com",
                paymentO = "MasterCard"

            });

            modelBuilder.Entity<Userinformation>().HasData(new
            {
                id = 3,
                fullname = "Kathrine Kristiansen",
                dateofbirth = DateTime.Now,
                Address = "kathrinevej  1",
                city = "kathrinebjerg",
                CountryCode = 7600,
                email = "Kathrine@gmail.com",
                paymentO = "MasterCard"

            });


            //modelBuilder.Entity<Productinfo>().HasData(new { productinfoID = 1, Brand =" Adiddas", Color = "Black", size = "10" });
            //modelBuilder.Entity<Productinfo>().HasData(new { productinfoID = 2, Brand = "Adiddas", Color = "White", size = "11" });
            //modelBuilder.Entity<Productinfo>().HasData(new { productinfoID = 3, Brand = "Ecco", Color = "Brown", size = "12" });
            //modelBuilder.Entity<Productinfo>().HasData(new { productinfoID = 4, Brand = "Adiddas", Color = "Black", size = "10" });





        }



    }
}
    
