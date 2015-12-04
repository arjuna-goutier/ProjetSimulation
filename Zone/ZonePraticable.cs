using System;

namespace SimulationPersonnage.Zone
{
    public class ZonePraticable : Zone
    {
        public ZonePraticable(string nom) : base(nom)
        {

        }

        public override void getDescription()
        {
            Console.WriteLine("Zone Praticable");
        }
    }
}
