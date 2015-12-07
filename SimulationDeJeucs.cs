using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage
{
    class SimulationDeJeux
    {
        public Fabrique.FabriqueLabyrinthe créeLabyrinthe()
        {
            return new Fabrique.FabriqueLabyrinthe();
        }

        public Fabrique.FabriqueNatation créeNatation()
        {
            return new Fabrique.FabriqueNatation();
        }

        public Fabrique.FabriqueTraficRoutier créeTrafiqueRoutier()
        {
            return new Fabrique.FabriqueTraficRoutier();
        }

        public SimulationDeJeux(path)
        {

        }

    }
}
