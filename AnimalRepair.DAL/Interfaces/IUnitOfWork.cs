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
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderProduct> OrderProducts { get; }
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
