using System;
using System.Collections.Generic;

namespace SimulationPersonnage.Zone
{
    class FabriqueConcreteZone : IFabriqueZone
    {
        public virtual IZone CreerZone(IDictionary<string,string> arguments)
        {
            switch (arguments["type"])
            {
                case "Praticable":
                    return new BaseZonePraticable(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "Impraticable":
                    return new BaseZoneImpraticable(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
