using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SimulationPersonnage.Zone
{
    class ZoneBatiment : BaseZone
    {
        public ZoneBatiment(string nom, int x , int y) : base(nom,x,y)
        {
        }

        public override string Description
        {
            get
            {
                return "Zone Batiment";
            }
        }
    }
}
