using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Acces
{
    class AccesImpraticable : Acces
    {
        public AccesImpraticable(string nom, Zone.Zone ZoneFrom, Zone.Zone ZoneTo ): base(nom, ZoneFrom , ZoneTo)
        {

        }
    }
}
