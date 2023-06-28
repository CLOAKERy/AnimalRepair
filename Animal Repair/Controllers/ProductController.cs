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
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        IProductService productService;
        IKindOfProductService kindOfProductService;
        public ProductController(IKindOfProductService kindOfProductserv,
            IProductService productserv, ILogger<ProductController> logger, IWebHostEnvironment hostingEnvironment)
        {
            kindOfProductService = kindOfProductserv;
            productService = productserv;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<ProductDTO> ProductDtos = await productService.GetAllProductsAsync();
            return View(ProductDtos);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ProductCreateViewModel productCreate = new();
            IEnumerable<KindOfProductDTO> kindOfProductDTO = await kindOfProductService.GetAllKindOfProductsAsync();
            productCreate.KindOfProducts = kindOfProductDTO;
            return View(productCreate);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model, IFormFile imageFile)
        {
            WorkingWithImg img = new();
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string imagePath = await img.ProcessImage(imageFile, uploadFolder);
            ProductDTO productCreate = new()
            {
                IdKindOfProduct = model.IdKindOfProduct,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Picture = imagePath
            };
            await productService.AddProduct(productCreate);
            return RedirectToAction("Index", "Product");

        }
    }



}
