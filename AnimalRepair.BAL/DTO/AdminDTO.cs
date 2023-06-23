using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }

        public int IdRole { get; set; }

        public int IdLogin { get; set; }

        public string Name { get; set; } = null!;
    }
}
