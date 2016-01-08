using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage;

namespace DesignPatternProject
{
    class Course
    {
        private IEnumerable<Nageur> participants { get; }


        public void Commencer()
        {
            foreach (var participant in participants)
            {
                participant.Commencer();
            }
        }
    }
}
