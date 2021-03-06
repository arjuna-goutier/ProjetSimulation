﻿using System;
using DesignPatternProject.Simulation;

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
}
