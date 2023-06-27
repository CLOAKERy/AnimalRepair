using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;

        IAnimalService animalService;
        public AnimalController(IAnimalService serv, ILogger<AnimalController> logger)
        {
            animalService = serv;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<AnimalDTO> AnimalDtos = await animalService.GetAllAnimalsAsync();
            return View(AnimalDtos);
        }
    }
}
