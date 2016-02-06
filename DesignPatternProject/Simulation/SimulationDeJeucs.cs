using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternProject;

namespace SimulationPersonnage
{
    interface ISimulation:IObservable<TimeEvent>
    {
        void Simuler();
        IPlateau Plateau { get; set; }
    }

    class SimulationDeJeux:Observable<TimeEvent>, ISimulation
    {
        public SimulationDeJeux(IDictionary<string, string> arguments)
        {
        }

        private  const int TimeToSleep = 0;
        public virtual bool EstFinis { get; protected set; }

        public void Simuler()
        {
            Raise(new BeginEvent());
            while (!EstFinis)
            {
                Tick();
                Raise(new EndTurnEvent());
            }
            Raise(new EndEvent());
        }

        protected virtual void Tick()
            => Raise(new TickEvent());

        protected virtual void WaitNextTurn()
        {
            System.Threading.Thread.Sleep(TimeToSleep);
        }
        public IPlateau Plateau { get; set; }
    }

    class NatationSimulation : SimulationDeJeux
    {
        readonly ISet<Nageur> arrivés = new HashSet<Nageur>(); 
        public int NombreDeTour { get; set; }
        public void Arrivé(Nageur nageur)
        {
            Console.WriteLine(nageur.Nom + " est arrivé");
            arrivés.Add(nageur);
            EstFinis = arrivés.Count == Plateau.Personnages.Count();
        }

        public NatationSimulation(IDictionary<string, string> arguments) : base(arguments)
        {
            NombreDeTour = int.Parse(arguments["NombreDeTour"]);
        }
    }
}
