using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Acces
{
    class AccesImpraticable : Acces
    {
        public AccesImpraticable(string nom, IZone zoneFrom, IZone zoneTo ): base(zoneFrom , zoneTo)
        {

        }
    }
}
