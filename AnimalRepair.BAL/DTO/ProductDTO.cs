using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int IdKindOfProduct { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string? Picture { get; set; }
    }
}
