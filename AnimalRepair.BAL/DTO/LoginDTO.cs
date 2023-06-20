using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    internal class LoginDTO
    {
        public int Id { get; set; }

        public string Login1 { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
