using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class Insception
    {
        public int IdInsception { get; set; }

        public string Comment { get; set; }
        public DateTime InsceptionDate { get; set; }

        public int IdCar { get; set; }
        public int IdMechanic { get; set; }
        public Car IdCarNavigation { get; set; }
        public Mechanic IdMechanicNavigation { get; set; }

        public ICollection<ServiceTypeDictInsception> ServiceTypeDictInsceptions_Insceptions = new HashSet<ServiceTypeDictInsception>();
    }
}
