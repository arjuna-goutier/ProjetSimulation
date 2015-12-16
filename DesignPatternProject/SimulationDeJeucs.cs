using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage
{
    interface ISimulation
    {
        void Commencer();
    }
    class SimulationDeJeux:ISimulation
    {
        public void Commencer()
        {
            
        }

        private PlateauDeJeu plateau;

        public SimulationDeJeux(PlateauDeJeu plateau)
        {
            this.plateau = plateau;
        }
    }
}
