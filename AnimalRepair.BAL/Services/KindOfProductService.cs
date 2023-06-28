using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.DAL.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    public class KindOfProductService : IKindOfProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public KindOfProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void AddKindOfProduct(KindOfProductDTO kindOfProductDto)
        {
            // Валидация данных категории
            if (string.IsNullOrEmpty(kindOfProductDto.Name.ToString()))
                throw new ValidationException("Название категории не может быть пустым", "");

            var kindOfProduct = _mapper.Map<KindOfProductDTO, KindOfProduct>(kindOfProductDto);
            // Пример сохранения в базу данных с использованием UnitOfWork
            _unitOfWork.KindOfProducts.CreateAsync(kindOfProduct);
            _unitOfWork.Save();
        }
        public async Task UpdateKindOfProduct(KindOfProductDTO kindOfProductDto)
        {
            KindOfProduct updatedProduct = _mapper.Map<KindOfProductDTO, KindOfProduct>(kindOfProductDto, kindOfProduct);

            await _unitOfWork.KindOfProducts.UpdateAsync(updatedProduct);
            _unitOfWork.Save();
        }
        public async Task RemoveKindOfProduct(int kindOfProductId)
        {
            KindOfProduct kindOfProduct = await _unitOfWork.KindOfProducts.GetAsync(kindOfProductId);
            if (kindOfProduct == null)
                throw new ValidationException("Категория товара не найдена", "");

            await _unitOfWork.KindOfProducts.DeleteAsync(kindOfProductId);
            _unitOfWork.Save();
        }
        public async Task<KindOfProductDTO> GetKindOfProductById(int kindOfProductId)
        {
            KindOfProduct kindOfProduct = await _unitOfWork.KindOfProducts.GetAsync(kindOfProductId);
            if (kindOfProduct == null)
                throw new ValidationException("Категория товара не найдена", "");

            KindOfProductDTO kindOfProductDto = _mapper.Map<KindOfProduct, KindOfProductDTO>(kindOfProduct);

            return kindOfProductDto;
        }
        public async Task<IEnumerable<KindOfProductDTO>> GetAllKindOfProductsAsync()
        {
            IEnumerable<KindOfProduct> kindOfProducts = await _unitOfWork.KindOfProducts.GetAllAsync();
            return _mapper.Map<IEnumerable<KindOfProduct>, IEnumerable<KindOfProductDTO>>(kindOfProducts);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}