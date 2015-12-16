using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;


namespace SimulationPersonnage.Acces
{
    public interface IAcces
    {
        string Nom { get; set; }
        IZone ZoneFrom { get; set; }
        IZone ZoneTo { get; set; }
    }

    public interface CopyOfIAcces
    {
        string Nom { get; set; }
        IZone ZoneFrom { get; set; }
        IZone ZoneTo { get; set; }
    }

    public class Acces:IAcces
    {
        public string Nom { get; set; }
        public IZone ZoneFrom { get; set; }
        public IZone ZoneTo { get; set; }

        protected Acces(string nom, IZone zoneFrom, IZone zoneTo)
        {
            this.Nom = nom;
            this.ZoneFrom = zoneFrom;
            this.ZoneTo = zoneTo;
        }
    }
}
