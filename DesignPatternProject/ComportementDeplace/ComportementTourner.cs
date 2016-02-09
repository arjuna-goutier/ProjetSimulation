using SimulationPersonnage;
using SimulationPersonnage.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternProject.ComportementDeplace
{
    class ComportementTourner : IComportementDeplace
    {
        IZone zonePrecedante;
        static readonly Random random = new Random();
        public void Deplace(Personnage personnage)
        {
            Avance(personnage);
        }
        private void Avance(Personnage Fontome)
        {
            var current = Fontome.Position;
            var accésPossible = current.ZoneLimitrophe;
            var possiblités = accésPossible.Where(z => z != zonePrecedante);
            var valeur = random.Next(possiblités.Count());
            zonePrecedante = Fontome.Position;
            Fontome.position = possiblités.ElementAt(valeur);
        }
    }
}
