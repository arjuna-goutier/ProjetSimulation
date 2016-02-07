using System;
using DesignPatternProject.Simulation;

namespace SimulationPersonnage
{

    class Nageur:Personnage
    {
        private const int VitesseDefaut = 2;
        private static readonly Random random = new Random();
        public int Vitesse { get; set; } = VitesseDefaut;

        public void Commencer(int nombreTour)
            => ComportementDeplace = new ComportementNage(nombreTour);

        public void Arriver()
        {
            ComportementDeplace = new ComportemenImmobile();
            (simulation as NatationSimulation)?.Arrivé(this);
        }

        public void GénererBonus(int bonus)
            => Vitesse = Math.Max(0, VitesseDefaut + bonus);

        public override void Tick(TickEvent e)
        {
            GénererBonus(random.Next(0, 3));
            SeDeplacer();
        }

        public void Réintialiser()
            => Vitesse = VitesseDefaut;

        public Nageur(NatationSimulation simulation, string nom) : base(simulation, nom)
        {
            simulation.Attach<FinCourse>(e => Arriver());
            ComportementDeplace = new ComportementNage(simulation.NombreDeTour);
        }
    }
}