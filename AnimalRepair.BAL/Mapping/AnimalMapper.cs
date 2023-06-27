using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Mapping
{
    public class AnimalMapper : EntityMapper<Animal, AnimalDTO>
    {
        public AnimalMapper()
        {
            // Дополнительная логика маппинга для Animal и AnimalDTO
            CreateMap<Animal, AnimalDTO>()
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.IdGenderNavigation.Gender))
                .ForMember(dest => dest.KindOfAnimalName, opt => opt.MapFrom(src => src.IdKindOfAnimalNavigation.Name));
            CreateMap<AnimalDTO, Animal>()
                .ForMember(dest => dest.IdGenderNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdKindOfAnimalNavigation, opt => opt.Ignore());

        }
    }
}
