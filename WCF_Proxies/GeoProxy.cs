using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_GeoService;

namespace WCF_Proxies
{
    public class GeoProxy : ClientBase<IGeoService>, IGeoService
    {
        public string GetCity(string zip)
        {
            return Channel.GetCity(zip);
        }
    }
}
