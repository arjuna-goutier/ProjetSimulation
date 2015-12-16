using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    class NameComparer
    {
        private readonly string name;
        public NameComparer(string name)
        {
            this.name = name;
        }
        public bool Compare(IZone x)
            => x.Nom.CompareTo(name) == 0;
    }
}
