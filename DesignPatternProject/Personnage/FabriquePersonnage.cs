using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Fabrique;

namespace SimulationPersonnage
{
    public interface IFabriquePersonnage
    {
        Personnage CreerPersonnage(string nom, string type);
    }

    class FabriquePersonnage :IFabriquePersonnage
    {
        public Personnage CreerPersonnage(string nom, string type)
        {
            return new Archer(nom, null);
        }
    }
}
