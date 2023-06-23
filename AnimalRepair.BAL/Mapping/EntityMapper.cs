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
    public class EntityMapper<TSource, TDestination> : Profile
    {
        public EntityMapper()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
