using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Data;
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
            builder.RegisterAssemblyTypes(typeof(ZipCodeRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .As(t => t.GetInterfaces().FirstOrDefault(
                   i => i.Name == "I" + t.Name));
            //builder.RegisterType<GeoLibDbContext>();
            container = builder.Build();

            //GeoLibDbContext test = new GeoLibDbContext();
            //var t = test.ZipCodeSet.Where(z => z.Zip == "00501");

            ServiceHost hostGeoService = new ServiceHost(typeof(GeoService));
            hostGeoService.AddDependencyInjectionBehavior(typeof(GeoService), container);

            hostGeoService.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();
            hostGeoService.Close();

        }
    }
}
