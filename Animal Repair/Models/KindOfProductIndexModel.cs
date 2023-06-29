using AnimalRepair.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Models
{
    public class KindOfProductIndexModel : Controller
    {
        public IEnumerable<KindOfProductDTO> kindOfProducts { get; set; }
    }
}
