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
    public class KindOfGenderController : Controller
{
    private readonly ILogger<KindOfGenderController> _logger;
    private readonly IWebHostEnvironment _hostingEnvironment;

    IKindOfGenderService kindOfGenderService;
    public KindOfGenderController(IKindOfGenderService kindOfGenderserv,
         ILogger<KindOfGenderController> logger, IWebHostEnvironment hostingEnvironment)
    {
        kindOfGenderService = kindOfGenderserv;
        _logger = logger;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> Create(KindOfGenderCreateViewModel model)
    {
        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        KindOfGenderDTO kindOfGenderCreate = new()
        {
            Gender = model.Gender,
        };
        await kindOfGenderService.AddKindOfGender(kindOfGenderCreate);
        return RedirectToAction("Index", "KindOfGender");
    }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            KindOfGenderIndexModel model = new();
            model.KindOfGenders = await kindOfGenderService.GetAllKindOfGendersAsync();
            return View(model);
        }
        [HttpPost]
        [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        KindOfGenderDTO kindOfGender = await kindOfGenderService.GetKindOfGenderById(id);
        KindOfGenderCreateViewModel kindOfGenderCreate = new()
        {
            Id = kindOfGender.Id,
            Gender = kindOfGender.Gender,
        };
        return View(kindOfGenderCreate);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(KindOfGenderCreateViewModel model)
    {
        string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        KindOfGenderDTO kindOfGenderEdit = new()
        {
            Id = model.Id,
            Gender = model.Gender,
        };
        await kindOfGenderService.UpdateKindOfGender(kindOfGenderEdit);
        return RedirectToAction("Index", "KindOfGender");
    }
    [HttpGet]
    public async Task<IActionResult> Delete(KindOfGenderCreateViewModel model)
    {
        await kindOfGenderService.RemoveKindOfGender(model.Id);
        return RedirectToAction("Index", "KindOfGender");
    }

    [HttpGet]
    public async Task<ActionResult> Details(KindOfGenderCreateViewModel model)
    {
        KindOfGenderDTO kindOfGender = await kindOfGenderService.GetKindOfGenderById(model.Id);
        KindOfGenderCreateViewModel kindOfGenderDetails = new()
        {
            Id = kindOfGender.Id,
            Gender = kindOfGender.Gender,
        };
        return View(kindOfGenderDetails);
    }
}



}

