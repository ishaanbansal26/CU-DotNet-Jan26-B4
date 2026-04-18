using AutoMapper;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models; // adjust if needed
namespace NorthwindCatalog.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Category → CategoryDto
            CreateMap<Category, CategoryDto>()
    .ForMember(dest => dest.ImageUrl,
        opt => opt.MapFrom(src =>
            "/images/" + src.CategoryName
                .Replace(" ", "")
                .Replace("/", "") + ".jpeg"));

            // Product → ProductDto
            CreateMap<Product, ProductDto>();
        }
    }
}


