using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    public class BaseZonePraticable : BaseZone
    {
        public BaseZonePraticable(string nom) : base(nom)
        {

        }

        public override string Description
            => "Zone Praticable";
    }
}
