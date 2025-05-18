using AutoMapper;
using APITaller1.src.Models;
using APITaller1.src.Dtos.User;
using APITaller1.src.Dtos;

namespace APITaller1.src.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // De entidad a DTO
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role!.Name));

            // De CreateUserDto a entidad
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // se hace manual
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));

            // Mapeo Address
            CreateMap<AddressDto, Address>();

            // LoginDto a User (opcional, si se usa)
            CreateMap<LoginDto, User>();

            // UpdateUserDto a User (ignora los nulls para no sobreescribir)
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
