using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VideoGameStore2.Models;

namespace VideoGameStore2.Models
{
    //Server=tcp:Nikhils-p2.database.windows.net,1433;Initial Catalog=retroStoreDB;Persist Security Info=False;User ID=trainer;Password=Password@1234;MultipleActiveResultSets=False;Encryption=True;TrustServerCertificate=False;Connection Timeout=30;
    //PM> Scaffold-DBContext “below connection string” - outputDir Models/EF -Provider Microsoft.EntityFramework.SqlServer
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {
        }
        public virtual DbSet<Order> OrderList { get; set; } = null!;
        public DbSet<Product> ProductList { get; set; } = null!;
        public DbSet<Register> CustomerList { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.productId)
                    .HasName("pk_productId");
                entity.ToTable("tbl_ProductInfo");
                entity.Property(e => e.productId)
                    .ValueGeneratedNever()
                    .HasColumnName("productId");
                entity.Property(e => e.productType)
                    .HasMaxLength(30)
                    .HasColumnName("productName");
                entity.Property(e => e.productType)
                    .HasMaxLength(30)
                    .HasColumnName("productType");
                entity.Property(e => e.productGenre)
                    .HasMaxLength(30)
                    .HasColumnName("productGenre");
                entity.Property(e => e.productPlatform)
                    .HasMaxLength(30)
                    .HasColumnName("productPlatform");
                entity.Property(e => e.productManufacturer)
                    .HasMaxLength(30)
                    .HasColumnName("productManufacturer");
                entity.Property(e => e.productReleaseDate)
                    .HasMaxLength(30)
                    .HasColumnName("productReleaseDate")
                    .HasColumnType("date");
                entity.Property(e => e.productQty)
                    .HasColumnName("productQty");
                entity.Property(e => e.productIsInStock)
                    .HasColumnName("productIsInStock");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.userName)
                    .HasName("pk_userName");
                entity.ToTable("tbl_RegisterInfo");
                entity.Property(e => e.userName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");
                entity.Property(e => e.userPassword) //min length?
                    .HasMaxLength(15)
                    .HasColumnName("userPassword");
                entity.Property(e => e.firstName)
                    .HasMaxLength(30)
                    .HasColumnName("firstName");
                entity.Property(e => e.lastName)
                    .HasMaxLength(30)
                    .HasColumnName("lastName");
                entity.Property(e => e.stAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stAddress");
                entity.Property(e => e.city)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");
                entity.Property(e => e.customerState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("customerState");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.HasKey(e => e.userName)
                    .HasName("pk_userName2");
                entity.ToTable("tbl_ContactInfo");
                entity.Property(e => e.userName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");
                entity.Property(e => e.emailAddress) //min length?
                    .HasMaxLength(15)
                    .HasColumnName("emailAddress");
                entity.Property(e => e.contactNo)  //string?
                    .HasColumnName("contactNo");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.orderNo)
                    .HasName("pk_orderNo");
                entity.ToTable("tbl_OrdersInfo");
                entity.Property(e => e.orderNo)
                    .HasColumnName("orderNo");
                entity.Property(e => e.orderName)
                    .HasColumnName("orderName")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.orderPrice)
                    .HasColumnName("orderPrice")
                    .HasColumnType("money");
                entity.Property(e => e.paymentType)
                    .HasColumnName("paymentType")
                    .HasMaxLength(20);
                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("date");
                entity.Property(e => e.pointsEarned)
                    .HasColumnName("pointsEarned");

            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public DbSet<VideoGameStore2.Models.AuthenticateUser>? AuthenticateUser { get; set; }
    }
}
