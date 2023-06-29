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
        Task AddKindOfGender(KindOfGenderDTO kindOfGenderDto);
        Task UpdateKindOfGender(KindOfGenderDTO kindOfGenderDto);
        Task RemoveKindOfGender(int kindOfGenddrId);
        Task<KindOfGenderDTO> GetKindOfGenderById(int kindOfGenderId);
        Task<IEnumerable<KindOfGenderDTO>> GetAllKindOfGendersAsync();


    }
}
