using AutoMapper;
using Dtos.Models;
using Entities.Models;
using Dtos.ViewModels;

namespace Services.Helpers
{
    public class CustomMapper :Profile
    {
        public CustomMapper()
        {
            CreateMap<Categories, CategoriesListDto>().ReverseMap();
            CreateMap<Categories, CategoriesCreateDto>().ReverseMap();
            CreateMap<Categories, CategoriesUpdateDto>().ReverseMap();
            CreateMap<Products, ProductsListDto>().ReverseMap();
            CreateMap<Products, ProductsCreateDto>().ReverseMap();
            CreateMap<Products, ProductsUpdateDto>().ReverseMap();
            CreateMap<Countries, CountriesListDto>().ReverseMap();
            CreateMap<Countries, CountriesCreateDto>().ReverseMap();
            CreateMap<Countries, CountriesUpdateDto>().ReverseMap();
            CreateMap<States, StatesListDto>().ReverseMap();
            CreateMap<States, StatesCreateDto>().ReverseMap();
            CreateMap<States, StatesUpdateDto>().ReverseMap();
            CreateMap<Cities, CitiesListDto>().ReverseMap();
            CreateMap<Cities, CitiesCreateDto>().ReverseMap();
            CreateMap<Cities, CitiesUpdateDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
        }
    }
}
