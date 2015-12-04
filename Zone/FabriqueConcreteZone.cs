using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    class FabriqueConcreteZone : FabriqueZone
    {
        public override Zone CreerZone(string type, string nom)
        {
            switch (type)
            {
                case "Patricable":
                    return new ZonePraticable(nom, true);
                case "Inpraticable":
                    return new ZoneInpraticable(nom, false);
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
