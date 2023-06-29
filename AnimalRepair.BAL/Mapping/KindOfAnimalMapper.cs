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
    public class KindOfAnimalMapper : EntityMapper<KindOfAnimal, KindOfAnimalDTO>
    {
     //   public KindOfAnimalMapper(){
     //   // Дополнительная логика маппинга для Animal и AnimalDTO
     //   CreateMap<KindOfAnimal, KindOfAnimalDTO>()
     //           .ForMember(dest => dest.Name, opt => opt.MapFrom)
     //}
    }
}
