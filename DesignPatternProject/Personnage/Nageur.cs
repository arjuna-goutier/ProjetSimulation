using System;
using DesignPatternProject.Simulation;

namespace SimulationPersonnage
{

    class Nageur:Personnage
    {
        private const int VitesseDefaut = 10;
        public int Vitesse { get; set; } = VitesseDefaut;

        public void Commencer(int nombreTour)
            => ComportementDeplace = new ComportementNage(nombreTour);

        public void Arriver()
        {
            ComportementDeplace = new ComportemenImmobile();
            (simulation as NatationSimulation)?.Arrivé(this);
        }

        public void GénererBonus(int bonus)
            => Vitesse = VitesseDefaut + bonus;

        public override void Tick(TickEvent e)
        {
            var random = new Random();
            GénererBonus(random.Next(-10, 10));
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