using ExampleApi.Dtos;
using System.Collections.Generic;

namespace ExampleApi.Repository
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
        ProductDto GetProductById(int id);
        void AddProduct(ProductDto product);
        void DeleteProduct(int id);
        ProductDto EditProduct(ProductDto productDto);
    }
}
