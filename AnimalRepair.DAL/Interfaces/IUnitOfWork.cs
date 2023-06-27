using Animal_Repair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Animal> Animals { get; }
        IOrderRepository<Order> Orders { get; }
        IOrderProductRepository<OrderProduct> OrderProducts { get; }
        ICustomerRepository<Customer> Customers { get; }
        IRepository<KindOfAnimal> KindOfAnimals { get; }
        IRepository<KindOfGender> KindOfGenders { get; }
        IRepository<KindOfProduct> KindOfProducts { get; }
        IRepository<Product> Products { get; }
        IRepository<Admin> Admins { get; }
        ILoginRepository<Login> Logins { get; }
        IRepository<UserRole> UserRoles { get; }
        void Save();
    }
}
