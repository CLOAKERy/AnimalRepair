﻿using Animal_Repair.Models;
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
        public async Task<ActionResult> Index(int kindOfAnimalId)
        {
            AnimalIndexModel model = new()
            {
                
                KindOfAnimals = await kindOfAnimalService.GetAllKindOfAnimalsAsync(),
                KindOfGenders = await kindOfGenderService.GetAllKindOfGendersAsync()
            };

            if (kindOfAnimalId == 0)
            {

                model.Animals = await animalService.GetAllAnimalsAsync();
                return View(model);
            }
            else
            {
                model.Animals = await animalService.GetAnimalsByCategory(kindOfAnimalId);
                return View(model);
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            AnimalCreateViewModel animalCreate = new()
            {
                KindOfAnimals = await kindOfAnimalService.GetAllKindOfAnimalsAsync(),
                KindOfGenders = await kindOfGenderService.GetAllKindOfGendersAsync()
            };
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

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            AnimalDTO animal = await animalService.GetAnimalById(id);
            AnimalCreateViewModel animalCreate = new()
            {
                IdKindOfAnimal = animal.IdKindOfAnimal,
                IdGender = animal.IdGender,
                DateOfBirth = animal.DateOfBirth,
                Description = animal.Description,
                Picture = animal.Picture,
                KindOfAnimals = await kindOfAnimalService.GetAllKindOfAnimalsAsync(),
                KindOfGenders = await kindOfGenderService.GetAllKindOfGendersAsync()
            };
            return View(animalCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnimalCreateViewModel model, IFormFile imageFile)
        {
            WorkingWithImg img = new();
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string imagePath = await img.ProcessImage(imageFile, uploadFolder);
            AnimalDTO animalEdit = new()
            {
                Id = model.Id,
                IdKindOfAnimal = model.IdKindOfAnimal,
                IdGender = model.IdGender,
                DateOfBirth = model.DateOfBirth,
                Description = model.Description,
                Picture = imagePath
            };
            await animalService.UpdateAnimal(animalEdit);
            return RedirectToAction("Index", "Animal");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(AnimalCreateViewModel model)
        {
            WorkingWithImg img = new();
            string uploadFolder = _hostingEnvironment.WebRootPath + model.Picture;
            img.DeleteImg(uploadFolder);
            await animalService.RemoveAnimal(model.Id);
            return RedirectToAction("Index", "Animal");
        }

        [HttpGet]
        public async Task<ActionResult> Details(AnimalCreateViewModel model)
        {
            AnimalDTO animal = await animalService.GetAnimalById(model.Id);
            AnimalCreateViewModel animalDetails = new()
            {
                Id = animal.Id,
                GenderName = model.GenderName, 
                KindOfAnimalName = model.KindOfAnimalName, 
                IdKindOfAnimal = animal.IdKindOfAnimal,
                IdGender = animal.IdGender,
                DateOfBirth = animal.DateOfBirth,
                Description = animal.Description,
                Picture = animal.Picture,
            };
            return View(animalDetails);
        }
    }


    
}
