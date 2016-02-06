using System.Collections.Generic;
using DesignPatternProject.Simulation;
using DesignPatternProject.Zone;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Fabrique
{
    class FabriqueNatation : BaseFabriqueSimulation
    {
        public override ISimulation CreerSimulation(IDictionary<string, string> arguments)
            => new NatationSimulation(arguments);

        public override IFabriquePersonnage CreerFabriquePersonnage(ISimulation simulation)
            => new FabriquePersonnageNatation(simulation);

        public override IFabriqueZone CreerFabriqueZone(ISimulation simulation)
            => new FabriqueZoneNatation();
    }
}
