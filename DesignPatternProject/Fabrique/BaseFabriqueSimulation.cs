using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Fabrique
{
    interface IFabriqueSimulation
    {
        IFabriquePlateau CreerPlateauFactory();
        IFabriqueZone CreerFabriqueZone();
        IFabriquePersonnage CreerFabriquePersonnage();
        IFabriqueAcces CreerFabriqueAcces();
    }
    class BaseFabriqueSimulation:IFabriqueSimulation
    {
        public IFabriquePlateau CreerPlateauFactory() 
            => new FabriquePlateau();

        public IFabriqueZone CreerFabriqueZone() 
            => new FabriqueConcreteZone();

        public IFabriquePersonnage CreerFabriquePersonnage()
            => new FabriquePersonnage();

        public IFabriqueAcces CreerFabriqueAcces()
            => new FabriqueConcreteAcces();
    }
}
