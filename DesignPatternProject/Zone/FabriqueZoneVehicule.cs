using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Zone
{
    class FabriqueZoneVehicule:FabriqueConcreteZone
    {

        public override IZone CreerZone(IDictionary<string, string> arguments)
        {
            switch (arguments["type"])
            {
                case "ZoneRoute":
                    return new ZoneRoute(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "ZoneBatiment":
                    return new ZoneBatiment(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "ZoneEntré":
                    return new ZoneEntré(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "ZoneSortie":
                    return new ZoneSortie(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                default:
                    throw new Exception("");
            }
        }
    }
}
