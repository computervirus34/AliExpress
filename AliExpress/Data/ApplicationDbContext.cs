using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace AliExpress
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AliexpressOrder> AliexpressOrders { get; set; }
        public virtual DbSet<AliexpressOrdersProduct> AliexpressOrdersProducts { get; set; }
        public virtual DbSet<AliexpressProduct> AliexpressProducts { get; set; }
        public virtual DbSet<Appuser> Appusers { get; set; }
        public virtual DbSet<TrademeCategory> TrademeCategories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<AliexpressOrder>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("aliexpress_orders");

                entity.Property(e => e.AdjustedPrice)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Adjusted_Price");

                entity.Property(e => e.AliExpressStoreName)
                    .HasMaxLength(500)
                    .HasColumnName("AliExpress_StoreName");

                entity.Property(e => e.CostOfShipping)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Cost_of_Shipping");

                entity.Property(e => e.Currency).HasMaxLength(3);

                entity.Property(e => e.Discount).HasColumnType("float(10,4)");

                entity.Property(e => e.NzSupplyOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("nzSupply_Order_ID");

                entity.Property(e => e.OrderCancelled)
                    .HasMaxLength(10)
                    .HasColumnName("Order_Cancelled");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Date");

                entity.Property(e => e.ReceiptDocument)
                    .HasMaxLength(255)
                    .HasColumnName("Receipt_Document");

                entity.Property(e => e.SuppliersOrderId)
                    .HasMaxLength(20)
                    .HasColumnName("Suppliers_Order_ID");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("TOTAL_Amount");

                entity.Property(e => e.TotalCostOfProducts)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Total_Cost_of_Products");

                entity.Property(e => e.TotalOrderTax)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Total_Order_Tax");

                entity.Property(e => e.TotalUnitsInOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("Total_Units_in_Order");
            });

            modelBuilder.Entity<AliexpressOrdersProduct>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("aliexpress_orders_products");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.Specification1).HasMaxLength(500);

                entity.Property(e => e.SuppliersOrderId)
                    .HasMaxLength(20)
                    .HasColumnName("Suppliers_Order_ID");

                entity.Property(e => e.TotalProductTax)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Total_Product_Tax");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("float(10,4)")
                    .HasColumnName("Unit_Price");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<AliexpressProduct>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("aliexpress_products");

                entity.Property(e => e.Description).HasColumnType("varchar(20000)");

                entity.Property(e => e.Images).HasMaxLength(2000);

                entity.Property(e => e.MainImage)
                    .HasMaxLength(200)
                    .HasColumnName("Main_Image");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(2000)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.Sku)
                    .HasMaxLength(20)
                    .HasColumnName("SKU");

                entity.Property(e => e.SpecInformation)
                    .HasColumnType("varchar(20000)")
                    .HasColumnName("Spec_Information");

                entity.Property(e => e.Specification1).HasMaxLength(500);

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Appuser>(entity =>
            {
                entity.ToTable("appuser");

                entity.HasIndex(e => e.Email, "Email")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone).HasMaxLength(100);
            });

            modelBuilder.Entity<TrademeCategory>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("trademe_categories");

                entity.Property(e => e.CanBeAuctioned)
                    .HasMaxLength(5)
                    .HasColumnName("Can_Be_Auctioned");

                entity.Property(e => e.CanBeClassified)
                    .HasMaxLength(5)
                    .HasColumnName("Can_Be_Classified");

                entity.Property(e => e.CategoryCode)
                    .HasColumnType("int(11)")
                    .HasColumnName("Category_Code");

                entity.Property(e => e.CategoryPath)
                    .HasMaxLength(1000)
                    .HasColumnName("Category_Path");

                entity.Property(e => e.DurationsDays)
                    .HasMaxLength(50)
                    .HasColumnName("Durations_Days");

                entity.Property(e => e.FullCode)
                    .HasMaxLength(100)
                    .HasColumnName("Full_Code");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
