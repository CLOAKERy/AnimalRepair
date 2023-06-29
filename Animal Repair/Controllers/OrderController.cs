using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
