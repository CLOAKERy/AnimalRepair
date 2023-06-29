using Animal_Repair.Models;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using AnimalRepair.BLL.BusinessModel;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        IAnimalService animalService;
        IProductService productService;

        public CartController(IProductService productserv,
            IAnimalService animalserv, ILogger<AnimalController> logger)
        {
            animalService = animalserv;
            _logger = logger;
            productService = productserv;
            
        }

       /* public IActionResult AddProductToCart(int productId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Получите товар из базы данных или другого источника данных
            var product = productService.GetProductById(productId);

            if (product != null)
            {
                // Создайте объект CartItem на основе товара
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    // Установите дополнительные свойства товара
                };

                // Добавьте товар в корзину
                cart.Add(cartItem);

                // Сохраните обновленную корзину в сеансе
                HttpContext.Session.SetObject("Cart", cart);
            }

            return RedirectToAction("Cart");
        }*/

        public IActionResult AddAnimalToCart(int animalId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Получите животное из базы данных или другого источника данных
            var animal = animalService.GetAnimalById(animalId);

            if (animal != null)
            {
                // Создайте объект CartItem на основе животного
                var cartItem = new CartItem
                {
                    AnimalId = animal.Id,
                    KindOfAnimal = animal.Ki,
                    AnimalPrice = animal.Price,
                    // Установите дополнительные свойства животного
                };

                // Добавьте животное в корзину
                cart.Add(cartItem);

                // Сохраните обновленную корзину в сеансе
                HttpContext.Session.SetObject("Cart", cart);
            }

            return RedirectToAction("Cart");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
