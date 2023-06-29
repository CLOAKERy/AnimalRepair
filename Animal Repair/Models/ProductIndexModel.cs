using AnimalRepair.BLL.DTO;

namespace Animal_Repair.Models
{
    public class ProductIndexModel
    {
        public IEnumerable<KindOfProductDTO> KindOfProducts { get; set; } = null!;
        public IEnumerable<ProductDTO> Products  { get; set; }
    }
}
