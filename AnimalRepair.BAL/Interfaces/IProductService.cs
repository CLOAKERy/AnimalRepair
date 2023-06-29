using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task AddProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task RemoveProduct(int productId);
        Task<ProductDTO> GetProductById(int productId);
        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int IdCategory);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}
