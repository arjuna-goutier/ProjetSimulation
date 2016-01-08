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
                    return new BaseZonePraticable(nom);
                case "Impraticable":
                    return new BaseZoneImpraticable(nom);
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
