﻿using Jardines2022.Entidades.Dtos;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IProductoServicio
    {
        List<Producto> GetLista();
        List<ProductoListDto> GetListaProductosPorCategorias(int id);
        void ActualizarStock(int id, int cantidad, string signo);
        Producto GetProductoPorId(int id);
        void Guardar(Producto producto);
        void Borrar(Producto producto);
        bool Existe(Producto producto);
        bool EstaRelacionado(Producto producto);
    }
}
