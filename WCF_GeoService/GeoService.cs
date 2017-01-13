using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCF_GeoService
{
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class GeoService : IGeoService
    {
        private Dictionary<string, string> cityZipDict;
        private int Counter = 0;
        public GeoService()
        {
            cityZipDict = new Dictionary<string, string>();
            cityZipDict.Add("1000", "Sofia");
            cityZipDict.Add("2000", "Plovdiv");
            cityZipDict.Add("3000", "Burgas");
        }

        [PrincipalPermission(SecurityAction.Demand)] //, Role = "Administrators")]
        public string GetCity(string zip)
        {
            Counter++;
            Console.WriteLine("Counter = {0}", Counter.ToString());
            string hostIdentity = WindowsIdentity.GetCurrent().Name;
            string primaryIdentity = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            string windowsIdentity = ServiceSecurityContext.Current.WindowsIdentity.Name;
            string threadIdentity = Thread.CurrentPrincipal.Identity.Name;

            //return  cityZipDict.FirstOrDefault(o => o.Key == zip).Value ?? "Not Found";
            if (cityZipDict.FirstOrDefault(o => o.Key == zip).Value != null)
            {
                return cityZipDict.FirstOrDefault(o => o.Key == zip).Value;
            }
            else
            {
                // throw new ApplicationException(string.Format("zip code not found {0}", zip));
                //throw new FaultException(string.Format("Zip code {0} not found.", zip));
                //ApplicationException ex = new ApplicationException(string.Format("Zip code {0} not found.", zip));
                //throw new FaultException<ApplicationException>(ex, "Just another message");

                ArgumentException ex = new ArgumentException(string.Format("Zip code {0} not found.", zip));
                throw new FaultException<ArgumentException>(ex, "Argument not valid");
            }
        }
    }
}
