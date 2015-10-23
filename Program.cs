using System;
using System.Collections.Generic;

namespace SimulationPersonnage
{
    class SimulationJeu
    {

        private readonly IList<Personnage> personnages = new List<Personnage>();
         
        static void Main()
        {
            var s = new SimulationJeu();
            var donjon = new Organisation("Donjon");
            var royaume = new Organisation("Royaume");

            s.CreationPersonnage(new Archer("Paul",donjon));
            s.CreationPersonnage(new Chevalier("Jean",royaume));
            s.CreationPersonnage(new Fantassin("Frederik",donjon));
            s.CreationPersonnage(new Princesse("Blanche neige",royaume));
            s.CreationPersonnage(new Ninja("Hattori",donjon));

            donjon.Etat = Etat.Guerre;
            royaume.Etat = Etat.Guerre;
            s.AfficheTous();
            s.EmettreSonTous();
            s.DeplacerTous();
            s.LancerCombat();
            s.LancerCombat();
            s.DeplacerTous();
            donjon.Etat = Etat.Paix;
            royaume.Etat = Etat.Paix;
            s.AfficheTous();

            Console.ReadLine();
        }

        public void AfficheTous()
        {
            foreach (var personnage in personnages)
                Console.WriteLine(personnage.Afficher());
        }

        public void DeplacerTous()
        {
            foreach (var personnage in personnages)
                Console.WriteLine(personnage.SeDeplacer());
        }

        public void EmettreSonTous()
        {
            foreach (var personnage in personnages)
                Console.WriteLine(personnage.EmettreSon());
        }

        public void CreationPersonnage(Personnage personnage)
            => personnages.Add(personnage);

        public void LancerCombat()
        {
            foreach (var personnage in personnages)
                Console.WriteLine(personnage.Combat());
        }

        SimulationJeu()
        {
            
        }
    }
}
