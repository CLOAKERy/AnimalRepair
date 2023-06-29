using AnimalRepair.BLL.DTO;

namespace Animal_Repair.Models
{
    public class AnimalIndexModel
    {
        public IEnumerable<KindOfGenderDTO> KindOfGenders { get; set; }
        public IEnumerable<KindOfAnimalDTO> KindOfAnimals { get; set; }
        public IEnumerable<AnimalDTO> Animals { get; set; }
    }
}
