using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Acces
{
    public abstract class FabriqueAcces
    {
        public abstract Acces cree_acces(Zone.Zone ZoneFrom, Zone.Zone ZoneTo, string nom, string type);
    }
}
