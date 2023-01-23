[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Jardines2022.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Jardines2022.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Jardines2022.Web.App_Start
{
    using System;
    using System.Web;
    using Jardines2022.Datos;
    using Jardines2022.Datos.Repositorios;
    using Jardines2022.Datos.Repositorios.IRepositorios;
    using Jardines2022.Servicios.Servicios;
    using Jardines2022.Servicios.Servicios.IServicios;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPaisesRepositorio>().To<PaisesRepositorio>().InRequestScope();
            kernel.Bind<IPaisesServicio>().To<PaisesServicio>().InRequestScope();

            kernel.Bind<ICiudadRepositorio>().To<CiudadRepositorio>().InRequestScope();
            kernel.Bind<ICiudadServicio>().To<CiudadServicio>().InRequestScope();

            kernel.Bind<ICategoriaRepositorio>().To<CategoriaRepositorio>().InRequestScope();
            kernel.Bind<ICategoriaServicio>().To<CategoriaServicio>().InRequestScope();

            kernel.Bind<IProductoRepositorio>().To<ProductoRepositorio>().InRequestScope();
            kernel.Bind<IProductoServicio>().To<ProductoServicio>().InRequestScope();

            kernel.Bind<IProveedorRepositorio>().To<ProveedorRepositorio>().InRequestScope();
            kernel.Bind<IProveedorServicio>().To<ProveedorServicio>().InRequestScope();

            kernel.Bind<IClienteRepositorio>().To<ClienteRepositorio>().InRequestScope();
            kernel.Bind<IClienteServicio>().To<ClienteServicio>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            kernel.Bind<Jardines2022DbContext>().ToSelf().InSingletonScope();

        }
    }
}