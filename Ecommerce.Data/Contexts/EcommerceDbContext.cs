using Ecommerce.Shared.Contracts;
using Ecommerce.Shared.Models.Daos;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Contexts
{
    public class EcommerceDbContext : DbContext
    {

        private string _connectionString;

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options, ICustomEnvironment environment, ICustomSettings settings) 
            : base(options)
        {
            _connectionString = environment.GetEnvironment() == Shared.Enums.Enviro.Testing ?
                settings.GetSetting("Schad_dev")
                : settings.GetSetting("Schad_prod");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDao>().ToTable("Products", "dbo");
            modelBuilder.Entity<ProductCategoryDao>().ToTable("ProductCategories", "dbo");
            modelBuilder.Entity<CustomerDao>().ToTable("Customers", "dbo");
            modelBuilder.Entity<CustomerTypeDao>().ToTable("CustomerTypes", "dbo");
            modelBuilder.Entity<InvoiceDao>().ToTable("Invoices", "dbo");
            modelBuilder.Entity<InvoiceDetailDao>().ToTable("InvoiceDetails", "dbo");
            modelBuilder.Entity<NcfSequenceDao>().ToTable("NcfSequences", "dbo");


            modelBuilder.Entity<ProductDao>().HasKey(x => x.ProductId);
            modelBuilder.Entity<ProductCategoryDao>().HasKey(x => x.ProductCategoryId);
            modelBuilder.Entity<CustomerDao>().HasKey(x => x.CustomerId);
            modelBuilder.Entity<CustomerTypeDao>().HasKey(x => x.CustomerTypeId);
            modelBuilder.Entity<InvoiceDao>().HasKey(x => x.InvoiceId);
            modelBuilder.Entity<InvoiceDetailDao>().HasKey(x => x.InvoiceDetailId);
            modelBuilder.Entity<NcfSequenceDao>().HasKey(x => x.SequenceId);

            #region Products
            modelBuilder.Entity<ProductDao>().Property(x => x.Name)
                .HasMaxLength(150)
                .HasColumnType("nvarchar(150)");

            modelBuilder.Entity<ProductDao>().Property(x => x.Description)
               .HasMaxLength(600)
               .HasColumnType("nvarchar(600)");

            modelBuilder.Entity<ProductDao>().Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            #endregion

            #region ProductCategory
            modelBuilder.Entity<ProductCategoryDao>().Property(x => x.CategoryName)
               .HasMaxLength(150)
               .HasColumnType("nvarchar(150)");

            modelBuilder.Entity<ProductCategoryDao>().HasData(
                new ProductCategoryDao { ProductCategoryId = 1, CategoryName = "Laptop Computers" },
                new ProductCategoryDao { ProductCategoryId = 2, CategoryName = "Desktop Computers" },
                new ProductCategoryDao { ProductCategoryId = 3, CategoryName = "Cellphones" },
                new ProductCategoryDao { ProductCategoryId = 4, CategoryName = "Home Appliances" });

            #endregion

            #region CustomerType
            modelBuilder.Entity<CustomerTypeDao>().Property(x => x.Description)
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<CustomerTypeDao>().Property(x => x.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<CustomerTypeDao>().HasData(
                new CustomerTypeDao { CustomerTypeId = 1, Description = "Customer Type 1" },
                new CustomerTypeDao { CustomerTypeId = 2, Description = "Customer Type 2" }
            );
            #endregion

            #region Customer
            modelBuilder.Entity<CustomerDao>().Property(x => x.Status)
             .HasColumnType("bit")
             .HasDefaultValue(true);

            modelBuilder.Entity<CustomerDao>().Property(x => x.Address)
           .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<CustomerDao>().Property(x => x.Name)
            .HasMaxLength(250)
            .HasColumnType("nvarchar(250)");

            modelBuilder.Entity<CustomerDao>().Property(x => x.Rnc)
           .HasMaxLength(40)
           .HasColumnType("nvarchar(40)");

            #endregion

            #region NcfSequence
            modelBuilder.Entity<NcfSequenceDao>().Property(x => x.VoucherType)
              .HasMaxLength(25)
              .HasColumnType("nvarchar(25)");

            modelBuilder.Entity<NcfSequenceDao>().Property(x => x.Serie)
             .HasMaxLength(10)
             .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<NcfSequenceDao>().Property(x => x.IsActive)
              .HasDefaultValue(true);

            modelBuilder.Entity<NcfSequenceDao>().Property(x => x.CreateDate)
             .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<NcfSequenceDao>().HasData(
               new NcfSequenceDao
               {
                   Serie = "B",
                   StartSequence = 1,
                   EndSequence = 30000,
                   VoucherType = "01",
                   LastUpdateDate = null,
                   LastUsedSequence = null,
                   IsActive = true,
                   SequenceId = 1
               });

            #endregion

            #region Invoice
            modelBuilder.Entity<InvoiceDao>().Property(x => x.Ncf)
              .HasMaxLength(40)
              .HasColumnType("nvarchar(40)");

            modelBuilder.Entity<InvoiceDao>().Property(x => x.InvoiceDate)
              .HasDefaultValue(DateTime.Now);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductDao> Products { get; set; }
        public DbSet<ProductCategoryDao> ProductCategories { get; set; }
        public DbSet<CustomerTypeDao> CustomerTypes { get; set; }
        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<InvoiceDao> Invoices { get; set; }
        public DbSet<InvoiceDetailDao>  InvoiceDetails { get; set; }
        public DbSet<NcfSequenceDao> NcfSequences { get; set; }
    }
}
