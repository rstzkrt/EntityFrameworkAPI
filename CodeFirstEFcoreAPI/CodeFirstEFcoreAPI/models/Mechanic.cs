using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class Mechanic
    {
        public int IdMechanic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Insception> MechanicInsceptions = new HashSet<Insception>();
    }
}
