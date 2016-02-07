using SimulationPersonnage.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage
{
    public class Voiture : Personnage
    {
        public Voiture(ISimulation simulation, string nom) : base(simulation, nom)
        {

        }

        public void Commencer(IZone Arrivé)
            => ComportementDeplace = new ComportementAlleràArrivé(Arrivé);
 }
}
