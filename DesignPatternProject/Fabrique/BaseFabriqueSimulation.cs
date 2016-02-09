using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Fabrique
{
    public interface IFabriqueSimulation
    {
        IFabriquePlateau CreerPlateauFactory(ISimulation simulation);
        IFabriqueZone CreerFabriqueZone(ISimulation simulation);
        IFabriquePersonnage CreerFabriquePersonnage(ISimulation simulation);
        IFabriqueAcces CreerFabriqueAcces(ISimulation simulation);
        ISimulation CreerSimulation(IDictionary<string, string> arguments);
    }
    class BaseFabriqueSimulation:IFabriqueSimulation
    {
        public virtual IFabriquePlateau CreerPlateauFactory(ISimulation simulation) 
            => new FabriquePlateau();

        public virtual IFabriqueZone CreerFabriqueZone(ISimulation simulation) 
            => new FabriqueConcreteZone();

        public virtual IFabriquePersonnage CreerFabriquePersonnage(ISimulation simulation)
            => new FabriquePersonnage(simulation);

        public virtual IFabriqueAcces CreerFabriqueAcces(ISimulation simulation)
            => new FabriqueConcreteAcces();

        public virtual ISimulation CreerSimulation(IDictionary<string, string> arguments)
            => new SimulationDeJeux(arguments);
    }
}
