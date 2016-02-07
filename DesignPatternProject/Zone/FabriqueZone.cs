using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    interface IFabriqueZone
    {
        IZone CreerZone(IDictionary<string,string> arguments);

    }
}
