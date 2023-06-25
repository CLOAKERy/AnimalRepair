using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IKindOfAnimalService
    {
        void AddKindOfAnimal(KindOfAnimalDTO kindOfAnimalDto);
        Task UpdateKindOfAnimal(KindOfAnimalDTO kindOfAnimalDto);
        Task RemoveKindOfAnimal(int kindOfAnimalId);
        Task<KindOfAnimalDTO> GetKindOfAnimalById(int kindOfAnimalId);
        Task<IEnumerable<KindOfAnimalDTO>> GetAllKindOfAnimalsAsync();
    }
}
