using AnimalRepair.BLL.DTO;

namespace Animal_Repair.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int IdKindOfProduct { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string? Picture { get; set; }

    }
}
