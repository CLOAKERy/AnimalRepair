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
    public class KindOfAnimalService : IKindOfAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public KindOfAnimalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void AddKindOfAnimal(KindOfAnimalDTO kindOfAnimalDto)
        {
            // Валидация данных категории
            if (string.IsNullOrEmpty(kindOfAnimalDto.Name.ToString()))
                throw new ValidationException("Название категории не может быть пустым", "");

            var kindOfAnimal = _mapper.Map<KindOfAnimalDTO, KindOfAnimal>(kindOfAnimalDto);
            // Пример сохранения в базу данных с использованием UnitOfWork
            _unitOfWork.KindOfAnimals.CreateAsync(kindOfAnimal);
            _unitOfWork.Save();
        }
        public async Task UpdateKindOfAnimal(KindOfAnimalDTO kindOfAnimalDto)
        {
            KindOfAnimal updatedAnimal = _mapper.Map<KindOfAnimalDTO, KindOfAnimal>(kindOfAnimalDto, kindOfAnimal);

            await _unitOfWork.KindOfAnimals.UpdateAsync(updatedAnimal);
            _unitOfWork.Save();
        }
        public async Task RemoveKindOfAnimal(int kindOfAnimalId)
        {
            KindOfAnimal kindOfAnimal = await _unitOfWork.KindOfAnimals.GetAsync(kindOfAnimalId);
            if (kindOfAnimal == null)
                throw new ValidationException("Категория для животных не найдена", "");

            await _unitOfWork.KindOfAnimals.DeleteAsync(kindOfAnimalId);
            _unitOfWork.Save();
        }
        public async Task<KindOfAnimalDTO> GetKindOfAnimalById(int kindOfAnimalId)
        {
            KindOfAnimal kindOfAnimal = await _unitOfWork.KindOfAnimals.GetAsync(kindOfAnimalId);
            if (kindOfAnimal == null)
                throw new ValidationException("Категория для животных не найдена", "");

            KindOfAnimalDTO kindOfAnimalDto = _mapper.Map<KindOfAnimal, KindOfAnimalDTO>(kindOfAnimal);

            return kindOfAnimalDto;
        }
        public async Task<IEnumerable<KindOfAnimalDTO>> GetAllKindOfAnimalsAsync()
        {
            // Получение списка всех животных
            IEnumerable<KindOfAnimal> kindOfAnimals = await _unitOfWork.KindOfAnimals.GetAllAsync();
            return _mapper.Map<IEnumerable<KindOfAnimal>, IEnumerable<KindOfAnimalDTO>>(kindOfAnimals);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
