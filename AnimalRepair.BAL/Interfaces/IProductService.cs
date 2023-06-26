using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IProductService : IDisposable
    {
        Task AddProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task RemoveProduct(int productId);
        Task<ProductDTO> GetProductById(int productId);
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(string category);
        Task<IEnumerable<ProductDTO>> GetAllProductssAsync();
    }
}
