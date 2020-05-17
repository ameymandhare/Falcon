[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FalconSchool.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FalconSchool.App_Start.NinjectWebCommon), "Stop")]

namespace FalconSchool.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Configuration;
    using Falcon.DataAceess.DataRepository;
    using Falcon.Service.Prospect;
    using Falcon.DataAceess.ProspectRepository;
    using Falcon.Service.Common;
    using Falcon.DataAceess;
    using Falcon.Service.MasterRepository;

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
            #region Common
            kernel.Bind<IAppConfig>().To<AppConfig>();
            kernel.Bind<IRepository>().To<Repository>();
            #endregion

            #region Services
            kernel.Bind<IProspectStudentService>().To<ProspectStudentService>();
            kernel.Bind<IMasterService>().To<MasterService>();
            #endregion

            #region Repository
            kernel.Bind<IProspectStudentRepository>().To<ProspectStudentRepositiry>();
            kernel.Bind<IMasterRepository>().To<MasterRepository>();
            #endregion
        }
    }
}
