using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CompanyProject2
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Move_Of_Products> Move_Of_Products { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<permission_product> permission_product { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<product_Measuringunit> product_Measuringunit { get; set; }
        public virtual DbSet<store> stores { get; set; }
        public virtual DbSet<store_Product> store_Product { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<permission>()
                .HasMany(e => e.permission_product)
                .WithOptional(e => e.permission)
                .HasForeignKey(e => e.permission_id_FK);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Move_Of_Products)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.permission_product)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.Product_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.product_Measuringunit)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.store_Product)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<store>()
                .HasMany(e => e.Move_Of_Products)
                .WithRequired(e => e.store)
                .HasForeignKey(e => e.from_store_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<store>()
                .HasMany(e => e.Move_Of_Products1)
                .WithRequired(e => e.store1)
                .HasForeignKey(e => e.to_store_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<store>()
                .HasMany(e => e.permissions)
                .WithOptional(e => e.store)
                .HasForeignKey(e => e.store_id_FK);

            modelBuilder.Entity<store>()
                .HasMany(e => e.store_Product)
                .WithRequired(e => e.store)
                .HasForeignKey(e => e.store_id_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.Move_Of_Products)
                .WithRequired(e => e.supplier)
                .HasForeignKey(e => e.supplier_id_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<supplier>()
                .HasMany(e => e.permissions)
                .WithOptional(e => e.supplier)
                .HasForeignKey(e => e.Supp_id_FK);
        }
    }
}
