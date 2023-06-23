using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    internal class AnimalDTO
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
