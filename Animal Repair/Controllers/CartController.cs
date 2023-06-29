using Animal_Repair.Models;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using AnimalRepair.BLL.DTO;
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

        public async Task<IActionResult> AddProductToCart(int productId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Получите товар из базы данных или другого источника данных
            var product =  await productService.GetProductById(productId);

            if (product != null)
            {
                // Создайте объект CartItem на основе товара
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = Convert.ToDecimal(product.Price),
                    ProductPicture = product.Picture,
                    IsProduct = true
                    // Установите дополнительные свойства товара
                };

                // Добавьте товар в корзину
                cart.Add(cartItem);

                // Сохраните обновленную корзину в сеансе
                HttpContext.Session.SetObject("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddAnimalToCart(int animalId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Получите животное из базы данных или другого источника данных
            var animal = await animalService.GetAnimalById(animalId);

            if (animal != null)
            {
                
                // Создайте объект CartItem на основе животного
                var cartItem = new CartItem
                {
                    AnimalId = animal.Id,
                    KindOfAnimal = animal.KindOfAnimalName,
                    KindOfGendr = animal.GenderName,
                    AnimalPicture = animal.Picture,
                    IsProduct = false
                    // Установите дополнительные свойства животного
                };

                if (cart.Exists(x => x.AnimalId == cartItem.AnimalId))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Добавьте животное в корзину
                    cart.Add(cartItem);

                    // Сохраните обновленную корзину в сеансе
                    HttpContext.Session.SetObject("Cart", cart);
                }
                
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProductFromCart(int productId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Найдите товар в корзине по его идентификатору
            var cartItem = cart.FirstOrDefault(item => item.ProductId == productId);

            if (cartItem != null)
            {
                // Удалите товар из корзины
                cart.Remove(cartItem);

                // Сохраните обновленную корзину в сеансе
                HttpContext.Session.SetObject("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveAnimalFromCart(int animalId)
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Найдите животное в корзине по его идентификатору
            var cartItem = cart.FirstOrDefault(item => item.AnimalId == animalId);

            if (cartItem != null)
            {
                // Удалите животное из корзины
                cart.Remove(cartItem);

                // Сохраните обновленную корзину в сеансе
                HttpContext.Session.SetObject("Cart", cart);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            // Получите текущую корзину из сеанса
            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Создайте экземпляр модели представления и заполните его данными
            var model = new CartViewModel
            {
                Items = cart,
                TotalPrice = cart.Sum(item => item.ProductPrice)
            };

            return View(model);
        }
    }
}
