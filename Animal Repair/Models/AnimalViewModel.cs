namespace Animal_Repair.Models
{
    public class AnimalViewModel
    {
        public int Id { get; set; }

        public int IdKindOfAnimal { get; set; }

        public int? IdOrder { get; set; }

        public int IdGender { get; set; }

        public string DateOfBirth { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Picture { get; set; }
    }
}
