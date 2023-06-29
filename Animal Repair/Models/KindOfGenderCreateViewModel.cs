using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Models
{
    public class KindOfGenderCreateViewModel : Controller
    {
        public int Id { get; set; }

        public string Gender { get; set; } = null!;
    }
}
