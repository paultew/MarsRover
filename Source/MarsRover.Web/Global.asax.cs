using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MarsRover.Contracts;
using MarsRover.Factories;
using MarsRover.Parsers;
using MarsRover.Web.Infrastructure;

namespace MarsRover.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeServiceLocator();
            //FluentValidationModelValidatorProvider.Configure();
        }

        public void Application_OnEnd()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }

        private static void InitializeServiceLocator()
        {
            container = new WindsorContainer();
            container.Register(
                Component.For<ISurfaceParser>().ImplementedBy<PlateauParser>().LifeStyle.Singleton,
                Component.For<ICommandParser>().ImplementedBy<StringCommandParser>().LifeStyle.Singleton,
                Component.For<ILocationParser>().ImplementedBy<TwoDimensionLocationParser>().LifeStyle.Singleton,
                Component.For<IRoverFactory>().ImplementedBy<MarsRoverFactory>().LifeStyle.Singleton
            );

            var contollers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();
            foreach (var controller in contollers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }

            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
