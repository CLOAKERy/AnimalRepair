using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    internal class CustomerDTO
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int IdLogin { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
