using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Jardines2022.Datos.Repositorios
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly Jardines2022DbContext context;
        public VentaRepositorio(Jardines2022DbContext context)
        {
            this.context = context;
        }
        public void AgregarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                context.detalleVentas.Add(detalleVenta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarVenta(Venta venta)
        {
            try
            {
                context.Ventas.Add(venta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Venta GetVenta(int UsuarioId)
        {
            try
            {
                return context.Ventas.SingleOrDefault(v => v.UsuarioId==UsuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Venta> ListarVentas()
        {
            try
            {
                return context.Ventas
                    .Include(v=>v.Usuario)
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
