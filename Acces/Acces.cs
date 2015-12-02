using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;


namespace SimulationPersonnage.Acces
{
     public abstract class Acces
    {
        public string Nom { get; set; }
        public Zone.Zone ZoneFrom { get; set; }
        public Zone.Zone ZoneTo { get; set; }
        public Acces(string nom, Zone.Zone ZoneFrom, Zone.Zone ZoneTo)
        {
            this.Nom = nom;
            this.ZoneFrom = ZoneFrom;
            this.ZoneTo = ZoneTo;
        }

    }
}
