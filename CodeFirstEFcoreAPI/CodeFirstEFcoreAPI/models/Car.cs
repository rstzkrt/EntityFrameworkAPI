using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstEFcoreAPI.models
{
    public class Car
    {
        public int IdCar { get; set; }
        public int ProductionYear { get; set; }
        public string name  { get; set; }
        
        public ICollection<Insception> CarInsceptons = new HashSet<Insception>();

    }
}
