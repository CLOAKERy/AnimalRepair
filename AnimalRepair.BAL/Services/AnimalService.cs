﻿using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Mapping;
using AnimalRepair.DAL.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task AddAnimal(AnimalDTO animalDto)
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

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.Animals.CreateAsync(animal);
            _unitOfWork.Save();
        }

        public async Task UpdateAnimal(AnimalDTO animalDto)
        {
            // Маппинг AnimalDTO в Animal
            Animal updatedAnimal = _mapper.Map<AnimalDTO, Animal>(animalDto);

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
            Animal animal = await _unitOfWork.Animals.GetAsync(
                animalId,
                a => a.IdGenderNavigation,
                a => a.IdKindOfAnimalNavigation
            );

            AnimalDTO animalMapped = _mapper.Map<Animal, AnimalDTO>(animal);
            return animalMapped;
        }

        public async Task<IEnumerable<AnimalDTO>> GetAnimalsByCategory(int IdCategory)
        {
            // Получение списка животных по категории
            IEnumerable<Animal> animals = await _unitOfWork.Animals.GetByCategoryAsync(IdCategory);
            return _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animals);
        }

        public async Task<IEnumerable<AnimalDTO>> GetAllAnimalsAsync()
        {
            var animals = await _unitOfWork.Animals.GetAllAsync(
                a => a.IdGenderNavigation,
                a => a.IdKindOfAnimalNavigation
            );

            var animalMapped = _mapper.Map<IEnumerable<AnimalDTO>>(animals);
            return animalMapped;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<AnimalDTO>> GetAnimalsByGenderAsync(int idGender)
        {
            IEnumerable<Animal> animals = await _unitOfWork.Animals.GetAnimalsByGenderAsync(idGender);
            return _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animals);
        }
    }

}
