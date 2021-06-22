using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class ServiceTypeDictInsception
    {
        public int IdServiceType{ get; set; }
        public int IdInsception { get; set; }
        public string Comments { get; set; }

        public ServiceTypeDict IdServiceTypeNavigation { get; set; }
        public Insception IdInsceptionNavigation { get; set; }


    }
}
