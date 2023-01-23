using Jardines2022.Datos.Repositorios.IRepositorios;
using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Jardines2022DbContext context;
        public ClienteRepositorio()
        {
            context= new Jardines2022DbContext();
        }
        public bool ExisteCliente(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId==0)
                {
                    return context.Clientes.Any(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido);
                }
                return context.Clientes.Any(c => c.Nombre == cliente.Nombre && c.Apellido == cliente.Apellido && c.CiudadId == cliente.CiudadId);
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
                return context.Clientes.Any(c => c.correo == correo);
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
                return context.Clientes.SingleOrDefault(c => c.correo == correo);
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
                return context.Clientes.SingleOrDefault(c => c.correo == correo && c.clave == clave);
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
                return context.Clientes
                    .Include(p => p.Pais)
                    .Include(p => p.Ciudad)
                    .ToList();
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
                return context.Clientes.SingleOrDefault(c => c.ClienteId == id);
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
                if (cliente.ClienteId==0)
                {
                    context.Clientes.Add(cliente);
                }
                else
                {
                    var clienteDb = context.Clientes.SingleOrDefault(c => c.ClienteId == cliente.ClienteId);
                    clienteDb.ClienteId= cliente.ClienteId;
                    clienteDb.Codigo= cliente.Codigo;
                    clienteDb.Nombre= cliente.Nombre;
                    clienteDb.Apellido= cliente.Apellido;
                    clienteDb.Direccion= cliente.Direccion;
                    clienteDb.CodigoPostal= cliente.CodigoPostal;
                    clienteDb.PaisId= cliente.PaisId;
                    clienteDb.CiudadId= cliente.CiudadId;
                    clienteDb.correo= cliente.correo;
                    clienteDb.clave= cliente.clave;
                    clienteDb.restablecer= cliente.restablecer;
                    clienteDb.RolId= cliente.RolId;
                    context.Entry(clienteDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
