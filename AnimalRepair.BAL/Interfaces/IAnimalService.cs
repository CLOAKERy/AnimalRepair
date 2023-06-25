using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IAnimalService : IDisposable
    {
        Task AddAnimal(AnimalDTO animalDto);
        Task UpdateAnimal(AnimalDTO animalDto);
        Task RemoveAnimal(int animalId);
        Task<AnimalDTO> GetAnimalById(int animalId);
        Task<IEnumerable<AnimalDTO>> GetAnimalsByCategory(string category);
        Task<IEnumerable<AnimalDTO>> GetAllAnimalsAsync();
    }

}
