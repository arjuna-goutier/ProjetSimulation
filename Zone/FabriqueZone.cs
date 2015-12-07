using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    public abstract class FabriqueZone
    {
        public abstract Zone CreerZone(string type, string nom);
    }
}
