using AnimalRepair.BLL.DTO;

namespace Animal_Repair.Models
{
    public class AnimalCreateViewModel
    {
        public int Id { get; set; }

        public int IdKindOfAnimal { get; set; }
        public string KindOfAnimalName { get; set; } = null!;

        public int? IdOrder { get; set; }

        public int IdGender { get; set; }
        public string GenderName { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Picture { get; set; }
        public IEnumerable<KindOfGenderDTO> KindOfGenders { get; set; }
        public IEnumerable<KindOfAnimalDTO> KindOfAnimals { get; set; }
    }
}
