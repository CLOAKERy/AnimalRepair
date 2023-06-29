using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Models
{
    public class KindOfProductCreateViewModel : Controller
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
