using System;
using System.Collections.Generic;
using AnimalRepair.DAL.Configurations;
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
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new AnimalConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new KindOfAnimalConfiguration());
        modelBuilder.ApplyConfiguration(new KindOfGenderConfiguration());
        modelBuilder.ApplyConfiguration(new KindOfProductConfiguration());
        modelBuilder.ApplyConfiguration(new LoginConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
