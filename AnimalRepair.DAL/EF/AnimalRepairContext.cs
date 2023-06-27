using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Animal_Repair;

public partial class AnimalRepairContext : DbContext
{
    public AnimalRepairContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public AnimalRepairContext(DbContextOptions<AnimalRepairContext> options)
        : base(options)
    {
    }

    public string ConnectionString { get; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<KindOfAnimal> KindOfAnimals { get; set; }

    public virtual DbSet<KindOfGender> KindOfGenders { get; set; }

    public virtual DbSet<KindOfProduct> KindOfProducts { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Admin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdLogin).HasColumnName("id_Login");
            entity.Property(e => e.IdRole).HasColumnName("id_Role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.IdLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_Login");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admins_User_Role");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.ToTable("Animal");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.IdGender).HasColumnName("Id_Gender");
            entity.Property(e => e.IdKindOfAnimal).HasColumnName("Id_KindOfAnimal");
            entity.Property(e => e.IdOrder).HasColumnName("Id_Order");
            entity.Property(e => e.Picture)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_KindOfGender");

            entity.HasOne(d => d.IdKindOfAnimalNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdKindOfAnimal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_KindOfAnimal");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_Animal_Order");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdLogin).HasColumnName("id_Login");
            entity.Property(e => e.IdRole).HasColumnName("id_Role");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsFixedLength();

            entity.HasOne(d => d.IdLoginNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Login");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Customers)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_User_Role");
        });

        modelBuilder.Entity<KindOfAnimal>(entity =>
        {
            entity.ToTable("KindOfAnimal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        modelBuilder.Entity<KindOfGender>(entity =>
        {
            entity.ToTable("KindOfGender");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Gender)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        modelBuilder.Entity<KindOfProduct>(entity =>
        {
            entity.ToTable("KindOfProduct");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Login");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Login1)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order_Product");

            entity.Property(e => e.IdOrder).HasColumnName("id_Order");
            entity.Property(e => e.IdProduct).HasColumnName("id_Product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany()
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Product_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.IdKindOfProduct).HasColumnName("Id_KindOfProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.Picture)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdKindOfProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdKindOfProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_KindOfProduct");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("User_Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
