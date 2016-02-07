using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Zone
{
    class ZoneRoute : BaseZone
    {
        public ZoneRoute(string nom, int X , int Y) : base(nom,X,Y) 
        {
        }

        public override string Description
        {
            get
            {
                return "Zone Route";
            }
        }
    }
}
