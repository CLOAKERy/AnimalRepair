using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface IAnimalRepository<Animal> : IRepository<Animal> where Animal : class
    {
        Task<IEnumerable<Animal>> GetAllAsync(params Expression<Func<Animal, object>>[] includes);
        Task GetByCategoryAsync(int idkindOfAnimal);
        Task<IEnumerable<Animal>> GetAnimalsByGenderAsync(int idGender);
    }
}
