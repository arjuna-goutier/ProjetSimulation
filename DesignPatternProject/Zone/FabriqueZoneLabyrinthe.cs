using SimulationPersonnage.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.Zone
{
    class FabriqueZoneLabyrinthe : FabriqueConcreteZone
    {
        public override IZone CreerZone(IDictionary<string, string> arguments)
        {
            switch (arguments["type"])
            {
                case "ZonePraticable":
                    return new BaseZonePraticable(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "ZoneImpraticable":
                    return new BaseZoneImpraticable(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "ZoneSortie":
                    return new ZoneSortie(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                default:
                    throw new Exception("");
            }
        }
    }
}
