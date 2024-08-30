using AutoMapper;
using CrudDapper.DTOs;
using CrudDapper.Models;

namespace CrudDapper.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Usuario, UsuarioListarDto>();
            //CreateMap<Usuario, UsuarioListarDto>().ReverseMap();
            //CreateMap<UsuarioListarDto, Usuario >().ReverseMap();
        }
    }
}
