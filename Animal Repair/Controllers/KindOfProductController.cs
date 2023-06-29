using Animal_Repair.Models;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using AnimalRepair.BLL.BusinessModel;
using SixLabors.ImageSharp.Processing;
namespace Animal_Repair.Controllers;

public class KindOfProductController : Controller
{
private readonly ILogger<KindOfProductController> _logger;
private readonly IWebHostEnvironment _hostingEnvironment;

IKindOfProductService kindOfProductService;
public KindOfProductController(IKindOfProductService kindOfProductserv,
     ILogger<KindOfProductController> logger, IWebHostEnvironment hostingEnvironment)
{
    kindOfProductService = kindOfProductserv;
    _logger = logger;
    _hostingEnvironment = hostingEnvironment;
}

[HttpGet]
[HttpPost]
public async Task<IActionResult> Create(KindOfProductCreateViewModel model)
{
    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
    KindOfProductDTO kindOfProductCreate = new()
    {
        Name = model.Name,
    };
    await kindOfProductService.AddKindOfProduct(kindOfProductCreate);
    return RedirectToAction("Index", "KindOfProduct");
}
[HttpGet]
public async Task<ActionResult> Edit(int id)
{
    KindOfProductDTO kindOfProduct = await kindOfProductService.GetKindOfProductById(id);
    KindOfProductCreateViewModel kindOfProductCreate = new()
    {
        Id = kindOfProduct.Id,
        Name = kindOfProduct.Name,
    };
    return View(kindOfProductCreate);
}

[HttpPost]
public async Task<IActionResult> Edit(KindOfProductCreateViewModel model)
{
    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
    KindOfProductDTO kindOfProductEdit = new()
    {
        Id = model.Id,
        Name = model.Name,
    };
    await kindOfProductService.UpdateKindOfProduct(kindOfProductEdit);
    return RedirectToAction("Index", "KindOfProduct");
}
[HttpGet]
public async Task<IActionResult> Delete(KindOfProductCreateViewModel model)
{
    await kindOfProductService.RemoveKindOfProduct(model.Id);
    return RedirectToAction("Index", "KindOfProduct");
}

[HttpGet]
public async Task<ActionResult> Details(KindOfProductCreateViewModel model)
{
    KindOfProductDTO kindOfProduct = await kindOfProductService.GetKindOfProductById(model.Id);
    KindOfProductCreateViewModel kindOfProductDetails = new()
    {
        Id = kindOfProduct.Id,
        Name = kindOfProduct.Name,
    };
    return View(kindOfProductDetails);
}
}

