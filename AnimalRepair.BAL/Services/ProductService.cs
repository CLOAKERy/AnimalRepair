using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductDTO productDto)
        {
            // Валидация данных продукта
            if (string.IsNullOrEmpty(productDto.IdKindOfProduct.ToString()))
                throw new ValidationException("Категория товара не может быть пустым", "");
            if (string.IsNullOrEmpty(productDto.Name.ToString()))
                throw new ValidationException("Название не может быть пустой", "");
            if (string.IsNullOrEmpty(productDto.Price.ToString()))
                throw new ValidationException("Цена не может быть пустой", "");
            if (string.IsNullOrEmpty(productDto.Description))
                throw new ValidationException("Описание не может быть пустой", "");

            // Маппинг productDTO в product
            var product = _mapper.Map<ProductDTO, Product>(productDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.Products.CreateAsync(product);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductssAsync()
        {
            var animals = await _unitOfWork.Products.GetAllAsync(a => a.IdKindOfProductNavigation);

            var animalMapped = _mapper.Map<IEnumerable<ProductDTO>>(animals);
            return animalMapped;
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            // Поиск животного по идентификатору
            Product product = await _unitOfWork.Products.GetAsync(productId);
            if (product == null)
                throw new ValidationException("Животное не найдено", "");

            ProductDTO productDto = _mapper.Map<Product, ProductDTO>(product);

            return productDto;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(string category)
        {
            // Получение списка животных по категории
            IEnumerable<Product> products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }

        public async Task RemoveProduct(int productId)
        {
            Product product = await _unitOfWork.Products.GetAsync(productId);
            if (product == null)
                throw new ValidationException("Животное не найдено", "");

            await _unitOfWork.Products.DeleteAsync(productId);
            _unitOfWork.Save();
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            // Поиск животного по идентификатору
            Product product = await _unitOfWork.Products.GetAsync(productDto.Id);
            if (product == null)
                throw new ValidationException("Животное не найдено", "");

            // Обновление данных животного
            product.IdKindOfProduct = productDto.IdKindOfProduct;
            product.Price = productDto.Price;
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Picture = productDto.Picture;
            // Обновление других свойств животного

            // Маппинг productDTO в product
            Product updatedproduct = _mapper.Map<ProductDTO, Product>(productDto);

            // Обновление животного в базе данных
            await _unitOfWork.Products.UpdateAsync(updatedproduct);
            _unitOfWork.Save();
        }
    }
}
