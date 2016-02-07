using System;
using System.Collections.Generic;
using SimulationPersonnage.Zone;

namespace DesignPatternProject.Zone
{
    class FabriqueZoneNatation:FabriqueConcreteZone
    {
        public override IZone CreerZone(IDictionary<string, string> arguments)
        {
            switch (arguments["type"])
            {
                case "piscine":
                    return new ZonePiscine(arguments["nom"], int.Parse(arguments["numero"]), int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "bord":
                    return new ZoneBord(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "separation":
                    return new ZoneSeparation(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                case "gradin":
                    return new ZoneSpectateur(arguments["nom"], int.Parse(arguments["x"]), int.Parse(arguments["y"]));
                default:
                    throw new Exception("");
            }
        }
    }

    internal class ZoneBord : BaseZone
    {
        public ZoneBord(string nom, int x,int y):base(nom,x,y)
        {
        }

        public override string Description => "bord";
    }
}
