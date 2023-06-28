using Animal_Repair.Models;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using AnimalRepair.BLL.BusinessModel;
using SixLabors.ImageSharp.Processing;

namespace Animal_Repair.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        IAnimalService animalService;
        IKindOfAnimalService kindOfAnimalService;
        IKindOfGenderService kindOfGenderService;
        public AnimalController(IKindOfAnimalService kindOfAnimalserv, IKindOfGenderService kindOfGenderserv,
            IAnimalService animalserv, ILogger<AnimalController> logger, IWebHostEnvironment hostingEnvironment)
        {
            kindOfGenderService = kindOfGenderserv;
            kindOfAnimalService = kindOfAnimalserv;
            animalService = animalserv;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
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
        [HttpPost]
        public async Task<IActionResult> Create(AnimalCreateViewModel model, IFormFile imageFile)
        {
            WorkingWithImg img = new();
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string imagePath = await img.ProcessImage(imageFile, uploadFolder);
            AnimalDTO animalCreate = new()
            {
                IdKindOfAnimal = model.IdKindOfAnimal,
                IdGender = model.IdGender,
                DateOfBirth = model.DateOfBirth,
                Description = model.Description,
                Picture = imagePath
            };
            await animalService.AddAnimal(animalCreate);
            return RedirectToAction("Index", "Animal");

        }
    }


    
}
