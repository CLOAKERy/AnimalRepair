using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class AnimalDTO
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
    }
}
