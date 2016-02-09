using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    class ComportementAlleràNimporteArrivé : IComportementDeplace
    {
        IZone zonePrecedante;
        static readonly Random random = new Random();
        IZone Arrivé;
        public ComportementAlleràNimporteArrivé(IZone arrivé)
        {
            this.Arrivé = arrivé;

        }
        public void Deplace(Personnage personnage)
        {
            Avance(personnage);
            if (personnage.position == Arrivé)
                personnage.ComportementDeplace = new ComportemenImmobile();
        }
        private void Avance(Personnage Humain)
        {
            var current = Humain.Position;
            var accésPossible = current.ZoneLimitrophe;
            var possiblités = accésPossible.Where(z => z != zonePrecedante && z.Personnages.Any(p => p is fantome));
            if (possiblités.Count() == 0)
            {
                Humain.position = zonePrecedante;
                return;
            }
            var valeur = random.Next(possiblités.Count());
            zonePrecedante = Humain.Position;
            Humain.position = possiblités.ElementAt(valeur);
        }
    }
}
