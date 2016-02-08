
using System;
using System.Collections.Generic;
using SimulationPersonnage.Zone;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Fabrique
{
    class FabriqueTraficRoutier :BaseFabriqueSimulation
    {
        public override ISimulation CreerSimulation(IDictionary<string, string> arguments)
          => new TraficRoutierSimulation(arguments);

        public override IFabriquePersonnage CreerFabriquePersonnage(ISimulation simulation)
            => new FabriquePersonnageTraficRoutier(simulation);

        public override IFabriqueZone CreerFabriqueZone(ISimulation simulation)
            => new FabriqueZoneVehicule();

    }
}
