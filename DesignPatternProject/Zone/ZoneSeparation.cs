using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace DesignPatternProject.Zone
{
    class ZoneSeparation: BaseZone
    {
        public ZoneSeparation(string nom, int x, int y) : base(nom, x, y)
        {
        }

        public override string Description
            => "separation";
    }
}
