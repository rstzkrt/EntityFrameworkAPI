using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class ServiceTypeDict
    {

        public int IdServiceType { get; set; }
        public string ServiceType { get; set; }
        public float Price { get; set; }

        public ICollection<ServiceTypeDictInsception> ServiceTypeDictInsceptions_ServiceTypeDict = new HashSet<ServiceTypeDictInsception>();
    }
}
