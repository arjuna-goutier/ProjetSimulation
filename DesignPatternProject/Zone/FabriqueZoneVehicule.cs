using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace DesignPatternProject.Zone
{
    class FabriqueZoneVehicule:FabriqueConcreteZone
    {
        public override IZone CreerZone(IDictionary<string, string> arguments)
        {
            return base.CreerZone(arguments);
        }
    }
}
