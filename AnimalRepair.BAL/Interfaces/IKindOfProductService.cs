using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IKindOfProductService
    {
        Task<IEnumerable<KindOfProductDTO>> GetAllKindOfProductAsync();
        Task<KindOfProductDTO> GetGenreByIdAsync(int id);
        Task AddKindOfProductAsync(KindOfProductDTO kindOfProduct);
        Task UpdateKindOfProductAsync(KindOfProductDTO kindOfProduct);
        Task DeleteKindOfProductAsync(int id);
    }
}
