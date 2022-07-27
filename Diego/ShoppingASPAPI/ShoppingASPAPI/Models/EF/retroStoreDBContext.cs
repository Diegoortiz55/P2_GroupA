using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoppingASPAPI.Models.EF
{
    public partial class retroStoreDBContext : DbContext
    {
        public retroStoreDBContext()
        {
        }

        public retroStoreDBContext(DbContextOptions<retroStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomerContact> TblCustomerContacts { get; set; } = null!;
        public virtual DbSet<TblOrdersInfo> TblOrdersInfos { get; set; } = null!;
        public virtual DbSet<TblProductCostList> TblProductCostLists { get; set; } = null!;
        public virtual DbSet<TblProductInfo> TblProductInfos { get; set; } = null!;
        public virtual DbSet<TblProductRanking> TblProductRankings { get; set; } = null!;
        public virtual DbSet<TblProductsPurchased> TblProductsPurchaseds { get; set; } = null!;
        public virtual DbSet<TblRegisterInfo> TblRegisterInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:Nikhils-p2.database.windows.net,1433;Initial Catalog=retroStoreDB;Persist Security Info=False;User ID=trainer;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomerContact>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("pk_userName2");

                entity.ToTable("tbl_CustomerContact");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.ContactNo).HasColumnName("contactNo");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.HasOne(d => d.EmailAddressNavigation)
                    .WithMany(p => p.TblCustomerContacts)
                    .HasForeignKey(d => d.EmailAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emailAddress");
            });

            modelBuilder.Entity<TblOrdersInfo>(entity =>
            {
                entity.HasKey(e => e.OrderNo)
                    .HasName("pk_orderNo");

                entity.ToTable("tbl_OrdersInfo");

                entity.Property(e => e.OrderNo)
                    .ValueGeneratedNever()
                    .HasColumnName("orderNo");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("orderName");

                entity.Property(e => e.OrderPrice)
                    .HasColumnType("money")
                    .HasColumnName("orderPrice");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("paymentType");

                entity.Property(e => e.PointsEarned).HasColumnName("pointsEarned");

                entity.HasOne(d => d.OrderNameNavigation)
                    .WithMany(p => p.TblOrdersInfos)
                    .HasForeignKey(d => d.OrderName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderName");
            });

            modelBuilder.Entity<TblProductCostList>(entity =>
            {
                entity.HasKey(e => e.ProductName)
                    .HasName("pk_productName");

                entity.ToTable("tbl_ProductCostList");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("money")
                    .HasColumnName("productPrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductCostLists)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_productId");
            });

            modelBuilder.Entity<TblProductInfo>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("pk_productId");

                entity.ToTable("tbl_ProductInfo");

                entity.HasIndex(e => e.ProductName, "unk_productName")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productType");

                entity.Property(e => e.ProductGenre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productGenre");

                entity.Property(e => e.ProductPlatform)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productPlatform");

                entity.Property(e => e.ProductManufacturer)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .HasColumnName("productManufacturer");

                entity.Property(e => e.ProductReleaseDate).HasColumnName("productReleaseDate");

                entity.Property(e => e.ProductCost)
                    .HasColumnType("money")
                    .HasColumnName("productCost");

                entity.Property(e => e.ProductQty).HasColumnName("productQty");

                entity.Property(e => e.ProductIsInStock).HasColumnName("productIsInStock");
 
            });

            modelBuilder.Entity<TblProductRanking>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("pk_productId2");

                entity.ToTable("tbl_ProductRanking");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductRanking).HasColumnName("productRanking");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.TblProductRankings)
                    .HasPrincipalKey(p => p.ProductName)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productName");
            });

            modelBuilder.Entity<TblProductsPurchased>(entity =>
            {
                entity.HasKey(e => new { e.OrderNo, e.ProductName })
                    .HasName("pk_orderName");

                entity.ToTable("tbl_ProductsPurchased");

                entity.Property(e => e.OrderNo).HasColumnName("orderNo");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.OrderQty).HasColumnName("orderQty");

                entity.HasOne(d => d.OrderNoNavigation)
                    .WithMany(p => p.TblProductsPurchaseds)
                    .HasForeignKey(d => d.OrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderNo");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany(p => p.TblProductsPurchaseds)
                    .HasForeignKey(d => d.ProductName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productName2");
            });

            modelBuilder.Entity<TblRegisterInfo>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("pk_userName");

                entity.ToTable("tbl_RegisterInfo");

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CustomerState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("customerState");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.StAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stAddress");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPoints).HasColumnName("userPoints");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
