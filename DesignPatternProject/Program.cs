using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage;

namespace DesignPatternProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new BaseSimulationReader();
            reader.FabriqueSimulation();
            var generateur = new GenerateurJeu();
            reader.AddElement(new Readed(ESimulationObjectType.Acces, null));
            var i = generateur.GenererJeux(reader);
            
        }
    }
}
