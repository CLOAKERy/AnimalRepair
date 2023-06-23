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
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnimalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddAnimal(AnimalDTO animalDto)
        {
            // Валидация данных животного
            if (string.IsNullOrEmpty(animalDto.IdKindOfAnimal.ToString()))
                throw new ValidationException("Категория животного не может быть пустым", "");
            if (string.IsNullOrEmpty(animalDto.IdGender.ToString()))
                throw new ValidationException("Пол животного не может быть пустой", "");
            if (string.IsNullOrEmpty(animalDto.DateOfBirth))
                throw new ValidationException("Дата рождения не может быть пустой", "");
            if (string.IsNullOrEmpty(animalDto.Description))
                throw new ValidationException("Описание животного не может быть пустой", "");

            // Маппинг AnimalDTO в Animal
            var animal = _mapper.Map<AnimalDTO, Animal>(animalDto);

            // Добавление животного в базу данных или выполнение другой логики

            // Пример сохранения в базу данных с использованием UnitOfWork
            _unitOfWork.Animals.CreateAsync(animal);
            _unitOfWork.Save();
        }

        public async Task UpdateAnimal(AnimalDTO animalDto)
        {
            // Поиск животного по идентификатору
            Animal animal = await _unitOfWork.Animals.GetAsync(animalDto.Id);
            if (animal == null)
                throw new ValidationException("Животное не найдено", "");

            // Обновление данных животного
            animal.IdKindOfAnimal = animalDto.IdKindOfAnimal;
            animal.IdGender = animalDto.IdGender;
            animal.DateOfBirth = animalDto.DateOfBirth;
            animal.Description = animalDto.Description;
            // Обновление других свойств животного

            // Маппинг AnimalDTO в Animal
            Animal updatedAnimal = _mapper.Map<AnimalDTO, Animal>(animalDto, animal);

            // Обновление животного в базе данных
            await _unitOfWork.Animals.UpdateAsync(updatedAnimal);
            _unitOfWork.Save();
        }

        public async Task RemoveAnimal(int animalId)
        {
            Animal animal = await _unitOfWork.Animals.GetAsync(animalId);
            if (animal == null)
                throw new ValidationException("Животное не найдено", "");

            await _unitOfWork.Animals.DeleteAsync(animalId);
            _unitOfWork.Save();
        }

        public async Task<AnimalDTO> GetAnimalById(int animalId)
        {
            // Поиск животного по идентификатору
            Animal animal = await _unitOfWork.Animals.GetAsync(animalId);
            if (animal == null)
                throw new ValidationException("Животное не найдено", "");

            AnimalDTO animalDto = _mapper.Map<Animal, AnimalDTO>(animal);

            return animalDto;
        }

        public IEnumerable<AnimalDTO> GetAnimalsByCategory(string category)
        {
            // Получение списка животных по категории
            IEnumerable<Animal> animals = (IEnumerable<Animal>)_unitOfWork.Animals.GetAllAsync();
            return _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animals);
        }

        public IEnumerable<AnimalDTO> GetAllAnimals()
        {
            // Получение списка всех животных
            IEnumerable<Animal> animals = (IEnumerable<Animal>)_unitOfWork.Animals.GetAllAsync();
            return _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animals);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }

}
