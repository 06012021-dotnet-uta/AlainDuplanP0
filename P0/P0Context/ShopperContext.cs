using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace P0Context
{
    public partial class ShopperContext : DbContext
    {
        public ShopperContext()
        {
        }

        public ShopperContext(DbContextOptions<ShopperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderInventory> OrderInventories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreInventory> StoreInventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Shopper;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CustomerFName")
                    .HasDefaultValueSql("('Unamed')");

                entity.Property(e => e.CustomerLname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CustomerLName")
                    .HasDefaultValueSql("('Unamed')");

                entity.HasOne(d => d.CustomerTopNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTop)
                    .HasConstraintName("FK__Customer__Custom__4222D4EF");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No Item Data Available')");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrdersId)
                    .HasName("PK__Orders__630B9976B64061D3");

                entity.Property(e => e.OrdersDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__45F365D3");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StoreId__44FF419A");
            });

            modelBuilder.Entity<OrderInventory>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.OrdersId })
                    .HasName("PK__OrderInv__044E3A1CDDC23B46");

                entity.ToTable("OrderInventory");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderInventories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderInve__ItemI__49C3F6B7");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderInventories)
                    .HasForeignKey(d => d.OrdersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderInve__Order__4AB81AF0");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No Location Data Available')");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StoreInventory>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.StoreId })
                    .HasName("PK__StoreInv__71C6AC9B508BA0BB");

                entity.ToTable("StoreInventory");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__ItemI__3C69FB99");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreInventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StoreInve__Store__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
