using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_GeoService
{
    [ServiceContract]
    public interface IGeoService
    {
        [OperationContract]
        [FaultContract(typeof(ApplicationException))]
        [FaultContract(typeof(ArgumentException))]
        string GetCity(string zip);
    }
}
