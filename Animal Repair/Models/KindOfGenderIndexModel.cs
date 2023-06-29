using AnimalRepair.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Models
{
    public class KindOfGenderIndexModel : Controller
    {
        public IEnumerable<KindOfGenderDTO> kindOfGenders { get; set; }
    }
}
