using Animal_Repair.Models;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.BusinessModel;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        IOrderProductService orderProductService;
        IOrderService orderService;
        public OrderController(IOrderProductService serv, IOrderService orderserv, ILogger<OrderController> logger)
        {
            orderProductService = serv;
            _logger = logger;
            orderService = orderserv;
        }


        public async Task<IActionResult> Create()
        {
            // Получите id пользователя из куки файла
            int userId = Convert.ToInt32(User.Identity.Name);
            List<ProductDTO> productDTOs = new();
            List<AnimalDTO> animalDTOs = new();
            var globalCart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            var cart = new CartViewModel
            {
                Items = globalCart,
                TotalPrice = globalCart.Sum(item => item.ProductPrice)
            };
            // Получите данные из корзины, чтобы сформировать заказ
            foreach (var item in cart.Items) 
            {
                if(item.IsProduct == true)
                {
                    productDTOs.Add(new ProductDTO { Id = item.ProductId });
                }
                if (item.IsProduct == false)
                {
                    animalDTOs.Add(new AnimalDTO { Id = item.AnimalId });
                }

            }

            // Создайте заказ
            OrderDTO order = new OrderDTO
            {
                IdCustomer = userId,
                Date = DateTime.Now.ToString(),
                Price = Convert.ToInt32(cart.TotalPrice),
                Status = "Принят"
            };

            // Добавьте заказ в базу данных или выполните другие необходимые действия
            await orderProductService.SaveOrderWithProducts(order, productDTOs, animalDTOs);
            // Очистите корзину
            HttpContext.Session.Remove("Cart");

            // Перенаправьте пользователя на страницу подтверждения заказа или другую страницу
            return RedirectToAction("Confirmation");
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable <OrderDTO> order = await orderService.GetAllOrders();
            return View(order);
        }

        public IActionResult Confirmation()
        {
            return View();
        }


    }
}
