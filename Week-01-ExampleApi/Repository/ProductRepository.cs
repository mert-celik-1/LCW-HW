using AutoMapper;
using ExampleApi.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ExampleApi.Repository
{
    /// <summary>
    /// Ürünler ile ilgili işlemler yapmak için oluşturulan repo
    /// </summary>
    public class ProductRepository: IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<Product> Products = new List<Product>()
        {
            new Product(){Id=1,Name="Pantolon",Description="Kumaş",Price=30,Quantity=1},
            new Product(){Id=2,Name="Gömlek",Description="Kot",Price=30,Quantity=1},
            new Product(){Id=3,Name="Perde",Description="Tül",Price=30,Quantity=1},

        };

        public List<ProductDto> GetProducts()
        {
            var productsDto = _mapper.Map<List<ProductDto>>(Products);

            return productsDto;
        }

        public ProductDto GetProductById(int id)
        {
            var product = Products.Where(x=>x.Id==id).FirstOrDefault();

            if (product == null)
            {
                return null;
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public void AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            Products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var product = Products.Where(x => x.Id == id).FirstOrDefault();
            
            Products.Remove(product);
        }

        public ProductDto EditProduct(ProductDto productDto)
        {
            var product = Products.Where(x => x.Id == productDto.Id).FirstOrDefault();

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;

            var productResponse = _mapper.Map<ProductDto>(product);

            return productResponse;
        }
    }
}
