using online_store.Core.DTOs;
using online_store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Core.Interfaces
{
    public interface IProductRepository: IRepository<ProductDTO, int>
    {
        void AddProduct(Product product);
        List<ProductDTO> GetBestProducts();
        List<SearchProductDTO> GetProductsByName(string name);
        List<SearchProductDTO> GetProductsByCategory(string category);
    }
}
