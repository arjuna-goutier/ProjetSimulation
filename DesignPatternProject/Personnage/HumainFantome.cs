using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
  public class Humain : Personnage
    {
        public Humain(ISimulation simulation, string nom) : base(simulation, nom)
        {

        }
        public void Commencer(IZone Arrivé)
            => ComportementDeplace = new ComportementAlleràNimporteArrivé(Arrivé);
    }

    public class fantome : Personnage
    {
        public fantome(ISimulation simulation , string nom ): base(simulation, nom)
        {

        }
        public void commencer()
            => ComportementDeplace = new ComportementTourner();
    } 
}
