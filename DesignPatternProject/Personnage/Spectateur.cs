using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternProject;

namespace SimulationPersonnage
{
    class Spectateur:Personnage
    {
        private int ExcitationLevel { get; set; }

        public bool Applaudit 
            => ExcitationLevel > 5;

        public bool Hue
            => ExcitationLevel < 5;

        public Spectateur(ISimulation simulation, string nom) : base(simulation, nom)
        {
            simulation.Attach<BeginCourse>(e => ExcitationLevel += 5);
            simulation.Attach<FinCourse>(e => ExcitationLevel += 5);
        }
        public void Tick()
        {
            ExcitationLevel -= 1;
        }
    }
}
