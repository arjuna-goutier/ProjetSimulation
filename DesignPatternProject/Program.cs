using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternProject.Zone;
using SimulationPersonnage;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace DesignPatternProject
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var reader = new BaseSimulationReader();
            reader.FabriqueSimulation();
            var generateur = new GenerateurJeu();
            reader.AddElement(new Readed(ESimulationObjectType.Acces, null));
            var i = generateur.GenererJeux(reader);
            */
            var nageur = new Nageur("Tom");
            var zones = new List<IZone>();
            foreach (var value in Enumerable.Range(1, 10))
            {
                var zone = new ZonePiscine(value.ToString(), value);
                if(zones.Count != 0)
                    zones[zones.Count - 1].LinkTo<AccesPraticable>(zone);
                zones.Add(zone);
            }
            nageur.Position = zones.First();
            nageur.Commencer(5);
            foreach (var i in Enumerable.Range(1,10000))
            {
                nageur.SeDeplacer();
            }
            Console.Read();
        }
    }
}
