using Jardines2022.Datos;
using Jardines2022.Datos.Repositorios;
using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using Jardines2022.Servicios.Servicios.IServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio repositorio;
        private readonly IUnitOfWork unitOfWork;
        public VentaServicio(VentaRepositorio repositorio, UnitOfWork unitOfWork)
        {
            this.repositorio = repositorio;
            this.unitOfWork = unitOfWork;
        }
        public void AgregarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                repositorio.AgregarDetalleVenta(detalleVenta);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AgregarVenta(Venta venta)
        {
            try
            {
                repositorio.AgregarVenta(venta);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Venta GetVenta(int UsuarioId)
        {
            try
            {
                return repositorio.GetVenta(UsuarioId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Venta> ListarVentas()
        {
            try
            {
                return repositorio.ListarVentas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
