using System;

namespace SimulationPersonnage.Zone
{
    class FabriqueConcreteZone : IFabriqueZone
    {
        public IZone CreerZone(string type, string nom)
        {
            switch (type)
            {
                case "Patricable":
                    return new ZonePraticable(nom);
                case "Impraticable":
                    return new ZoneImpraticable(nom);
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
