using System;

namespace SimulationPersonnage.Zone
{
    class FabriqueConcreteZone : FabriqueZone
    {
        public override Zone CreerZone(string type, string nom)
        {
            switch (type)
            {
                case "Patricable":
                    return new ZonePraticable(nom);
                case "Impraticable":
                    return new ZoneInpraticable(nom);
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
