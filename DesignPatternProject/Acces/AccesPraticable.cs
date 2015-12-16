using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Acces
{
    class AccesPraticable : Acces 
    {
        public AccesPraticable(string nom, IZone zoneFrom, IZone zoneTo): base(nom,  zoneFrom, zoneTo)
        {

        }
    }
}
