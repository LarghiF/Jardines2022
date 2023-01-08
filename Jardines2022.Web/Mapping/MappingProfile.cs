using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Web.Models.Categorias;
using Jardines2022.Web.Models.Ciudad;
using Jardines2022.Web.Models.Paises;

namespace Jardines2022.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadPaisMapping();
            LoadCategoriaMapping();
            LoadCiudadMapping();
        }

        private void LoadCiudadMapping()
        {
            CreateMap<CiudadListDto, CiudadListVm>();
            CreateMap<Ciudad, CiudadEditVm>().ReverseMap();
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