using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternProject.Zone;
using SimulationPersonnage.Zone;


namespace SimulationPersonnage.Acces
{
    public interface IAcces
    {
        string Nom { get; set; }
        IZone ZoneFrom { get; set; }
        IZone ZoneTo { get; set; }
        IZone Other(IZone zone);
    }

    class Acces:IAcces
    {
        public string Nom { get; set; }
        public IZone ZoneFrom { get; set; }
        public IZone ZoneTo { get; set; }

        public IZone Other(IZone zone)
        {
            if (ZoneFrom == zone)
                return ZoneTo;
            if (ZoneTo == zone)
                return ZoneFrom;
            return null;
        }

        protected Acces(string nom, IZone zoneFrom, IZone zoneTo)
        {
            this.Nom = nom;
            ZoneFrom = zoneFrom;
            ZoneTo = zoneTo;
            zoneFrom.Access.Add(this);
            zoneTo.Access.Add(this);
        }
    }
}
