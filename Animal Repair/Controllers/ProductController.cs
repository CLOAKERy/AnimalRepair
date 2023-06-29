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
        public async Task<ActionResult> Index(int kindOfProductId)
        {
            ProductIndexModel model = new()
            {
                KindOfProducts = await kindOfProductService.GetAllKindOfProductsAsync(),
            };

            if (kindOfProductId == 0)
            {

                model.Products = await productService.GetAllProductsAsync();
                return View(model);
            }
            else
            {
                model.Products = await productService.GetProductsByCategoryAsync(kindOfProductId);
                return View(model);
            }
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
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ProductDTO animal = await productService.GetProductById(id);
            ProductCreateViewModel productCreate = new()
            {
                Id = animal.Id,
                IdKindOfProduct = animal.IdKindOfProduct,
                Name = animal.Name,
                Price = animal.Price,
                Description = animal.Description,
                Picture = animal.Picture,
                KindOfProducts = await kindOfProductService.GetAllKindOfProductsAsync()
            };
            return View(productCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductCreateViewModel model, IFormFile imageFile)
        {
            WorkingWithImg img = new();
            string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            string imagePath = await img.ProcessImage(imageFile, uploadFolder);
            ProductDTO productEdit = new()
            {
                Id = model.Id,
                IdKindOfProduct = model.IdKindOfProduct,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Picture = imagePath
            };
            await productService.UpdateProduct(productEdit);
            return RedirectToAction("Index", "Product");
        }
    }



}
