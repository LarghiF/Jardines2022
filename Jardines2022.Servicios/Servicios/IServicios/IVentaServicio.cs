using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Servicios.Servicios.IServicios
{
    public interface IVentaServicio
    {
        void AgregarVenta(Venta venta);
        void AgregarDetalleVenta(DetalleVenta detalleVenta);
        List<Venta> ListarVentas();
        Venta GetVenta(int UsuarioId);
    }
}
