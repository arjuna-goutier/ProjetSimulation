using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    class ZoneInpraticable : Zone
    {
        public ZoneInpraticable(string nom, bool accessible):base(nom, accessible)
        {

        }

        public override void getDescription()
        {
            Console.WriteLine("Zone Inpraticable");
        }
    }
}
