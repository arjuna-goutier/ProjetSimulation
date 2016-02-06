using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Acces
{
    class FabriqueConcreteAcces : IFabriqueAcces
    {
        public IAcces CreerAcces(IZone zoneFrom, IZone zoneTo, string nom, string type)
        {
            switch (type) 
            {
                case "Praticable":
                    return new AccesPraticable(nom, zoneFrom, zoneTo );
                case "Impraticable":
                    return new AccesImpraticable(nom, zoneFrom, zoneTo);
                default:
                    throw new ArgumentException("Invalid type", nameof(type));
            }
        }
    }
}
