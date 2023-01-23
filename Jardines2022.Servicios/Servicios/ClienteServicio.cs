using Jardines2022.Datos;
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
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio repositorio;
        private readonly IUnitOfWork unitOfWork;
        public ClienteServicio(IClienteRepositorio repositorio,IUnitOfWork unitOfWork)
        {
            this.repositorio = repositorio;
            this.unitOfWork = unitOfWork;
        }

        public bool ExisteCliente(Cliente cliente)
        {
            try
            {
                return repositorio.ExisteCliente(cliente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ExisteCorreo(string correo)
        {
            try
            {
                return repositorio.ExisteCorreo(correo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cliente GetClientePorCorreo(string correo)
        {
            try
            {
                return repositorio.GetClientePorCorreo(correo);
            }
            catch (Exception e)
            {
                throw e; 
            }
        }

        public Cliente GetClientePorCorreoYClave(string correo, string clave)
        {
            try
            {
                return repositorio.GetClientePorCorreoYClave(correo, clave);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Cliente> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Cliente GetProID(int id)
        {
            try
            {
                return repositorio.GetProID(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                repositorio.Guardar(cliente);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
