using SimulationPersonnage.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.Zone
{
    class ZoneSpectateur : BaseZone
    {
        public ZoneSpectateur(string nom, int x, int y) : base(nom, x, y)
        {
        }

        public override string Description
            => "gradin";
    }
}
