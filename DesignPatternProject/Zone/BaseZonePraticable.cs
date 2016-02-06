using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    class BaseZonePraticable : BaseZone
    {
        public BaseZonePraticable(string nom, int x, int y) : base(nom, x, y)
        {

        }

        public override string Description
            => "Zone Praticable";
    }
}
