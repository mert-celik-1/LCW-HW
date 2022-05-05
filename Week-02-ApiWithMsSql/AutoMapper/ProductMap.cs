using ApiWithMsSql.Entities;
using ApiWithMsSql.ViewModels;
using AutoMapper;

namespace ApiWithMsSql.AutoMapper
{
    /// <summary>
    /// Urunler ve dto yu eşlemek için kullanılan kod bloğu
    /// </summary>
    public class ProductMap:Profile
    {

        public ProductMap()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, CreateProductViewModel>().ReverseMap();
            
        }   
    
    }
}
