using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    class ZoneImpraticable : Zone
    {
        public ZoneImpraticable(string nom):base(nom)
        {

        }

        public override string Description
                => "Zone Inpraticable";
    }
}
