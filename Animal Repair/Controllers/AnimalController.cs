using Animal_Repair.Models;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;

        IAnimalService animalService;
        IKindOfAnimalService kindOfAnimalService;
        IKindOfGenderService kindOfGenderService;
        public AnimalController(IKindOfAnimalService kindOfAnimalserv, IKindOfGenderService kindOfGenderserv,
            IAnimalService animalserv, ILogger<AnimalController> logger)
        {
            kindOfGenderService = kindOfGenderserv;
            kindOfAnimalService = kindOfAnimalserv;
            animalService = animalserv;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<AnimalDTO> AnimalDtos = await animalService.GetAllAnimalsAsync();
            return View(AnimalDtos);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AnimalCreateViewModel animalCreate = new();
            IEnumerable<KindOfAnimalDTO> kindOfAnimalDTO = await kindOfAnimalService.GetAllKindOfAnimalsAsync();
            animalCreate.KindOfAnimals = kindOfAnimalDTO;
            IEnumerable<KindOfGenderDTO> kindOfGenderDTO = await kindOfGenderService.GetAllKindOfGendersAsync();
            animalCreate.KindOfGenders = kindOfGenderDTO;
            return View(animalCreate);
        }
    }

    
}
