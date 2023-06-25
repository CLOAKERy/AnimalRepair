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
            /*var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnimalDTO, AnimalViewModel>()).CreateMapper();
            var animals = mapper.Map<IEnumerable<AnimalDTO>, List<AnimalViewModel>>(AnimalDtos);*/
            return View(AnimalDtos);
        }
        public async Task<ActionResult> Animal()
        {
            IEnumerable<AnimalDTO> AnimalDtos = await animalService.GetAllAnimalsAsync();
            /*var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AnimalDTO, AnimalViewModel>()).CreateMapper();
            var animals = mapper.Map<IEnumerable<AnimalDTO>, List<AnimalViewModel>>(AnimalDtos);*/
            return View(AnimalDtos);
        }
    }
}