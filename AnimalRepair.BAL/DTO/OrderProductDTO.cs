using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class OrderProductDTO
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }

        public int IdProduct { get; set; }
    }
}
