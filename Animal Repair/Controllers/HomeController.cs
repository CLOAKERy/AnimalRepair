using Animal_Repair.Models;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Animal_Repair.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IAnimalService animalService;
        public HomeController(IAnimalService serv, ILogger<HomeController> logger)
        {
            animalService = serv;
            _logger = logger;
        }

        public async Task<ActionResult> IndexAsync()
        {
            IEnumerable<AnimalDTO> AnimalDtos = await animalService.GetAllAnimalsAsync();
            return View(AnimalDtos);
        }
        public async Task<ActionResult> Animal()
        {
            IEnumerable<AnimalDTO> AnimalDtos = await animalService.GetAllAnimalsAsync();
            return View(AnimalDtos);
        }
    }
}