using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
