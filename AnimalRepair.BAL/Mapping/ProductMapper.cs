using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Mapping
{
    public class ProductMapper : EntityMapper<Product, ProductDTO>
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.KindOfProductName, opt => opt.MapFrom(src => src.IdKindOfProductNavigation.Name));
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.IdKindOfProductNavigation, opt => opt.Ignore());
        }
    }
}
