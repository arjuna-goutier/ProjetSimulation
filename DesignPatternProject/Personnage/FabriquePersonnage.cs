using System;
using SimulationPersonnage;

namespace SimulationPersonnage
{
    interface IFabriquePersonnage
    {
        IPersonnage CreerPersonnage(string nom, string type);
    }

    class FabriquePersonnage :IFabriquePersonnage
    {
        public FabriquePersonnage(ISimulation simulation)
        {
            Simulation = simulation;
        }

        protected ISimulation Simulation { get; }
        public virtual IPersonnage CreerPersonnage(string nom, string type)
            => new Personnage(Simulation, nom);
    }

    class FabriquePersonnageNatation:FabriquePersonnage
    {
        public override IPersonnage CreerPersonnage(string nom, string type)
        {
            switch (type)
            {
                case "nageur":
                    return new Nageur((NatationSimulation) Simulation, nom);
                case "spectateur":
                    return new Spectateur((NatationSimulation) Simulation, nom);
                default:
                    throw new Exception("type inconnu");
            }
        }

        public FabriquePersonnageNatation(ISimulation simulation) : base(simulation)
        {
        }
    }

    class FabriquePersonnageTraficRoutier : FabriquePersonnage
    {
        public FabriquePersonnageTraficRoutier(ISimulation simulation) : base (simulation)
        {

        }
        public override IPersonnage CreerPersonnage(string nom, string type)
        {
            switch (type)
            {
                case "voiture":
                    return new Voiture(Simulation, nom);
                case "feuTricolor":
                    return new FeuTricolor(Simulation, nom);
                default:
                    throw new Exception("type inconnu");
            }
        }
    }

}
