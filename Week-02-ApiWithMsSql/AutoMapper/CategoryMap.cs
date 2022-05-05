using ApiWithMsSql.Entities;
using ApiWithMsSql.ViewModels;
using AutoMapper;

namespace ApiWithMsSql.AutoMapper
{
    public class CategoryMap:Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
        }
    }
}
