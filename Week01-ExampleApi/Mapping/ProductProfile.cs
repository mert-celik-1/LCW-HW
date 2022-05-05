using AutoMapper;
using ExampleApi.Dtos;

namespace ExampleApi.Mapping
{
    /// <summary>
    /// Urunler ve dto yu eşlemek için kullanılan kod bloğu
    /// </summary>
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
       
    }
}
