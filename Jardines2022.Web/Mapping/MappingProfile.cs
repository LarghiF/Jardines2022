using AutoMapper;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Web.Models.Categorias;
using Jardines2022.Web.Models.Ciudad;
using Jardines2022.Web.Models.Paises;
using Jardines2022.Web.Models.Usuario;
using System;

namespace Jardines2022.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
            LoadCategoriaMapping();
            LoadCiudadMapping();
            LoadUsuarioMapping();
        }


        private void LoadUsuarioMapping()
        {
            CreateMap<Usuario, UsuarioEditVm>().ReverseMap();
        }

        private void LoadCiudadMapping()
        {
            CreateMap<CiudadListDto, CiudadListVm>();
            CreateMap<Ciudad, CiudadEditVm>().ReverseMap();
            //CreateMap<Ciudad, CiudadListVm>().ReverseMap();
            CreateMap<Ciudad, CiudadListVm>().ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais.NombrePais));
        }

        private void LoadCategoriaMapping()
        {
            CreateMap<Categoria, CategoriaListVm>();
            CreateMap<Categoria, CategoriaListVm>().ReverseMap();
            CreateMap<Categoria, CategoriaEditVm>().ReverseMap();

        }

        private void LoadPaisMapping()
        {
            CreateMap<Pais, PaisListVm>();
            CreateMap<Pais, PaisListVm>().ReverseMap();
            CreateMap<Pais, PaisEditVm>().ReverseMap();
        }
    }
}