using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DbA9ae8dDbanimalreContext db;
        private AdminRepository adminRepository;
        private AnimalRepository animalRepository;
        private CustomerRepository customerRepository;
        private KindOfAnimalRepository kindOfAnimalRepository;
        private KindOfGenderRepository kindOfGenderRepository;
        private KindOfProductRepository kindOfProductRepository;
        private LoginRepository loginRepository;
        private OrderProductRepository orderProductRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private UserRoleRepository userRoleRepository;
        public EFUnitOfWork(DbA9ae8dDbanimalreContext dbContext)
        {
            db = dbContext;
        }
        public IRepository<Animal> Animals
        {
            get
            {
                if (animalRepository == null)
                    animalRepository = new AnimalRepository(db);
                return animalRepository;
            }
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        public IRepository<OrderProduct> OrderProducts
        {
            get
            {
                if (orderProductRepository == null)
                    orderProductRepository = new OrderProductRepository(db);
                return orderProductRepository;
            }
        }

        public IRepository<KindOfAnimal> KindOfAnimals
        {
            get
            {
                if (kindOfAnimalRepository == null)
                    kindOfAnimalRepository = new KindOfAnimalRepository(db);
                return kindOfAnimalRepository;
            }
        }

        public IRepository<KindOfGender> KindOfGenders
        {
            get
            {
                if (kindOfGenderRepository == null)
                    kindOfGenderRepository = new KindOfGenderRepository(db);
                return kindOfGenderRepository;
            }
        }

        public IRepository<KindOfProduct> KindOfProducts
        {
            get
            {
                if (kindOfProductRepository == null)
                    kindOfProductRepository = new KindOfProductRepository(db);
                return kindOfProductRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }

        public IRepository<Login> Logins
        {
            get
            {
                if (loginRepository == null)
                    loginRepository = new LoginRepository(db);
                return loginRepository;
            }
        }

        public IRepository<UserRole> UserRoles
        {
            get
            {
                if (userRoleRepository == null)
                    userRoleRepository = new UserRoleRepository(db);
                return userRoleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
