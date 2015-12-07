using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Acces
{
    class FabriqueConcreteAcces : FabriqueAcces
    {
        public override Acces cree_acces(Zone.Zone ZoneFrom,  Zone.Zone ZoneTo, string nom, string type)
        {
            switch (type) 
            {
                case "Patricable":
                    return new AccesPraticable(nom, ZoneFrom, ZoneTo );
                case "Impraticable":
                    return new AccesImpraticable(nom, ZoneFrom, ZoneTo);
                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
