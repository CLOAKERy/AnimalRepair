﻿using Animal_Repair;
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
    public class KindOfGenderService : IKindOfGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public KindOfGenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddKindOfGender(KindOfGenderDTO kindOfGenderDto)
        {
            // Валидация данных категории
            if (string.IsNullOrEmpty(kindOfGenderDto.Gender.ToString()))
                throw new ValidationException("Название пола не может быть пустым", "");

            var kindOfGender = _mapper.Map<KindOfGenderDTO, KindOfGender>(kindOfGenderDto);
            // Пример сохранения в базу данных с использованием UnitOfWork
            _unitOfWork.KindOfGenders.CreateAsync(kindOfGender);
            _unitOfWork.Save();
        }
        public async Task UpdateKindOfGender(KindOfGenderDTO kindOfGenderDto)
        {
            KindOfGender updatedGender = _mapper.Map<KindOfGenderDTO, KindOfGender>(kindOfGenderDto);

            await _unitOfWork.KindOfGenders.UpdateAsync(updatedGender);
            _unitOfWork.Save();
        }

        public async Task RemoveKindOfGender(int kindOfGenderId)
        {
            KindOfGender kindOfGender = await _unitOfWork.KindOfGenders.GetAsync(kindOfGenderId);
            if (kindOfGender == null)
                throw new ValidationException("Пол не найден", "");

            await _unitOfWork.KindOfAnimals.DeleteAsync(kindOfGenderId);
            _unitOfWork.Save();
        }

        public async Task<KindOfGenderDTO> GetKindOfGenderById(int kindOfGenderId)
        {
            KindOfGender kindOfGender = await _unitOfWork.KindOfGenders.GetAsync(kindOfGenderId);
            if (kindOfGender == null)
                throw new ValidationException("Пол не найден", "");

            KindOfGenderDTO kindOfGenderDto = _mapper.Map<KindOfGender, KindOfGenderDTO>(kindOfGender);

            return kindOfGenderDto;
        }

        public async Task<IEnumerable<KindOfGenderDTO>> GetAllKindOfGendersAsync()
        {
            IEnumerable<KindOfGender> kindOfGenders = await _unitOfWork.KindOfGenders.GetAllAsync();
            return _mapper.Map<IEnumerable<KindOfGender>, IEnumerable<KindOfGenderDTO>>(kindOfGenders);
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
