using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }


        public string Login1 { get; set; } = null!;


        public string Password { get; set; } = null!;
    }
}
