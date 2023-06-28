using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IKindOfGenderService
    {
        void AddKindOfGender(KindOfGenderDTO kindOfGenderDto);
        Task UpdateKindOfGender(KindOfGenderDTO kindOfGenderDto);
        Task<IEnumerable<KindOfGenderDTO>> GetAllKindOfGendersAsync();


    }
}
