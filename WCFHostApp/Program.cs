using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_GeoService;

namespace WCF_HostConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = null;
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<GeoService>();
            container = builder.Build();

            ServiceHost hostGeoService = new ServiceHost(typeof(GeoService));
            hostGeoService.AddDependencyInjectionBehavior(typeof(GeoService), container);

            hostGeoService.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
            hostGeoService.Close();

        }
    }
}
