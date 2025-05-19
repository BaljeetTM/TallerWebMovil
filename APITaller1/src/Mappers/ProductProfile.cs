using APITaller1.src.Dtos.Product;
using APITaller1.src.Models;

using AutoMapper;

namespace APITaller1.src.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // De entidad a respuesta
            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src =>
                    src.Images != null
                        ? src.Images.Select(i => i.Url).ToList()
                        : new List<string>()));

            // De DTO de creación a entidad (ignora imágenes, se manejan en el controlador/servicio)
            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            // De DTO de actualización a entidad
            CreateMap<ProductUpdateDto, Product>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}