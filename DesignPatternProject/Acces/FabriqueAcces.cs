using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Acces
{
    interface IFabriqueAcces
    {
        IAcces CreerAcces(IZone zoneFrom, IZone zoneTo, string nom, string type);
    }
}
