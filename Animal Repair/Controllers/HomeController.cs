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
        public HomeController(IAnimalService serv)
        {
            animalService = serv;
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            IEnumerable<AnimalDTO> AnimalDtos = animalService.GetAllAnimals();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnimalDTO, AnimalViewModel>()).CreateMapper();
            var animals = mapper.Map<IEnumerable<AnimalDTO>, List<AnimalViewModel>>(AnimalDtos);
            return View(animals);
        }
    }
}