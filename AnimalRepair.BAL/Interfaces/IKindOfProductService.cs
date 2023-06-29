using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IKindOfProductService
    {
        Task AddKindOfProduct(KindOfProductDTO kindOfProductDto);
        Task<IEnumerable<KindOfProductDTO>> GetAllKindOfProductsAsync();
        Task<KindOfProductDTO> GetKindOfProductById(int kindOfProductId);
        Task UpdateKindOfProduct(KindOfProductDTO kindOfProduct);
        Task RemoveKindOfProduct(int id);
    }
}
