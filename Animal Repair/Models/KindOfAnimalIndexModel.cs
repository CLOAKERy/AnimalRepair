using AnimalRepair.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Models
{
    public class KindOfAnimalIndexModel : Controller
    {
        public IEnumerable<KindOfAnimalDTO> KindOfAnimals { get; set; }
        
    }
}
