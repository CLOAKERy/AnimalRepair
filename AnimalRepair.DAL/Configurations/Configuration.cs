using Animal_Repair;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace AnimalRepair.DAL.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> entity)
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
        }
    }
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> entity)
        {
            entity.ToTable("Animal");

            entity.Property(e => e.Id).HasColumnName("ID");


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
        }
    }
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
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
        }
    }
    public class KindOfAnimalConfiguration : IEntityTypeConfiguration<KindOfAnimal>
    {
        public void Configure(EntityTypeBuilder<KindOfAnimal> entity)
        {
            entity.ToTable("KindOfAnimal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        }
    }
    public class KindOfGenderConfiguration : IEntityTypeConfiguration<KindOfGender>
    {
        public void Configure(EntityTypeBuilder<KindOfGender> entity)
        {
            entity.ToTable("KindOfGender");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Gender)
                .HasMaxLength(25)
                .IsFixedLength();
        }
    }
    public class KindOfProductConfiguration : IEntityTypeConfiguration<KindOfProduct>
    {
        public void Configure(EntityTypeBuilder<KindOfProduct> entity)
        {
            entity.ToTable("KindOfProduct");

            entity.Property(e => e.Id).HasColumnName("ID");


            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsFixedLength();
        }
    }
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> entity)
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
        }
    }
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        }
    }
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> entity)
        {
            entity
                    
                    .ToTable("Order_Product");
            entity.Property(e => e.Id).HasColumnName("ID");
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
        }
    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");


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
        }
    }
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entity)
        {
            entity.ToTable("User_Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsFixedLength();
        }
    }
}
