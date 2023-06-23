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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDTO>(); // Определение сопоставления от Animal к AnimalDTO
            CreateMap<AnimalDTO, Animal>(); // Определение сопоставления от AnimalDTO к Animal
        }
    }
}
