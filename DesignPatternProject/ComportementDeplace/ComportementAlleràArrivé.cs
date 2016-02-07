using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;


namespace SimulationPersonnage
{
    public class ComportementAlleràArrivé : IComportementDeplace
    {
        IZone zonePrecedante;
        static readonly Random random = new Random();
        IZone Arrivé;
        public ComportementAlleràArrivé(IZone Arrivé)
        {
           this.Arrivé = Arrivé;
        }

        public void Deplace(Personnage personnage)
        {
            Avance(personnage);
            if (personnage.position == Arrivé)
                personnage.ComportementDeplace = new ComportemenImmobile();
        }
        private void Avance(Personnage voiture)
        {
            var current = voiture.Position;
            var accésPossible = current.ZoneLimitrophe;
            if (!current.Personnages.OfType<FeuTricolor>().Single().peuPassé)
                return;
            var possiblités = accésPossible.Where(z => z != zonePrecedante);
            var valeur = random.Next(possiblités.Count());
            zonePrecedante = voiture.Position;
            voiture.position = possiblités.ElementAt(valeur);
        }
    }

}

