using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IAnimalService : IDisposable
    {
        void AddAnimal(AnimalDTO animalDto);
        Task UpdateAnimal(AnimalDTO animalDto);
        Task RemoveAnimal(int animalId);
        Task<AnimalDTO> GetAnimalById(int animalId);
        IEnumerable<AnimalDTO> GetAnimalsByCategory(string category);
        IEnumerable<AnimalDTO> GetAllAnimals();
    }

}
