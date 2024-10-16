using System;
using Microsoft.EntityFrameworkCore;
using WebAplication.Models;

namespace WebAplication.Data
{
	public class ProductContext : DbContext
	{
		public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductsGroup { get; set; }
        public virtual DbSet<Storage> Storage{ get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlServer("Data Source =. \\SQLEXPRESS; " +
				"Initial Catalog = Products; Trusted_Connection = True; " +
				"TrustServerCertificate=True").UseLazyLoadingProxies().LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<ProductGroup>(entity =>
			{
				entity.HasKey(pg => pg.Id)
				.HasName("product_group_pk");

				entity.ToTable("category");

				entity.Property(pg => pg.Name).HasColumnName("name").HasMaxLength(255);
                entity.Property(pg => pg.Discription).HasColumnName("discription").HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id)
                .HasName("product_pk");

                entity.Property(p => p.Name).HasColumnName("name").HasMaxLength(255);

				entity.HasOne(p => p.ProductGroup).WithMany(p => p.Products)
				.HasForeignKey(p => p.ProductGroupId);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasKey(p => p.Id)
                .HasName("storage_pk");

                entity.HasOne(p => p.Product).WithMany(p => p.Storages)
                .HasForeignKey(p => p.ProductId);
            });

        }

        public ProductContext()
		{
		}
	}
}

