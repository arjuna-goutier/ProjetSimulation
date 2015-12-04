using System;

namespace SimulationPersonnage.Zone
{
    class ZoneInpraticable : Zone
    {
        public ZoneInpraticable(string nom):base(nom)
        {

        }

        public override void getDescription()
        {
            Console.WriteLine("Zone Inpraticable");
        }
    }
}
