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
    public class KindOfAnimalController : Controller
    {
        private readonly ILogger<KindOfAnimalController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        IKindOfAnimalService kindOfAnimalService;
        public KindOfAnimalController(IKindOfAnimalService kindOfAnimalserv,
             ILogger<KindOfAnimalController> logger, IWebHostEnvironment hostingEnvironment)
        {
            kindOfAnimalService = kindOfAnimalserv;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Create(KindOfAnimalCreateViewModel model)
        {
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            KindOfAnimalDTO kindOfAnimalCreate = new()
            {
                Name = model.Name,
            };
            await kindOfAnimalService.AddKindOfAnimal(kindOfAnimalCreate);
            return RedirectToAction("Index", "KindOfAnimal");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            KindOfAnimalDTO kindOfAnimal = await kindOfAnimalService.GetKindOfAnimalById(id);
            KindOfAnimalCreateViewModel kindOfAnimalCreate = new()
            {
                Id = kindOfAnimal.Id,
                Name = kindOfAnimal.Name,
            };
            return View(kindOfAnimalCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(KindOfAnimalCreateViewModel model)
        {
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            KindOfAnimalDTO kindOfAnimalEdit = new()
            {
                Id = model.Id,
                Name = model.Name,
            };
            await kindOfAnimalService.UpdateKindOfAnimal(kindOfAnimalEdit);
            return RedirectToAction("Index", "KindOfAnimal");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(KindOfAnimalCreateViewModel model)
        {
            await kindOfAnimalService.RemoveKindOfAnimal(model.Id);
            return RedirectToAction("Index", "KindOfAnimal");
        }

        [HttpGet]
        public async Task<ActionResult> Details(KindOfAnimalCreateViewModel model)
        {
            KindOfAnimalDTO kindOfAnimal = await kindOfAnimalService.GetKindOfAnimalById(model.Id);
            KindOfAnimalCreateViewModel kindOfAnimalDetails = new()
            {
                Id = kindOfAnimal.Id,
                Name = kindOfAnimal.Name,
            };
            return View(kindOfAnimalDetails);
        }
    }



}
