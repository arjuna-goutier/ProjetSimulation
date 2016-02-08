using System.Security.Cryptography.X509Certificates;
using DesignPatternProject;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    class Personnage:IPersonnage
    {
        public string Nom { get; }
        public IComportementDeplace ComportementDeplace { get; set; }
        public IZone position;
        public IZone Position {
            get
            {
                return position;
            }
            set
            {
                position?.SupprimerPersonnage(this);
                value.AjouterPersonnage(this);
                position = value;
            }
        }
        public ISimulation simulation;

        public Personnage(ISimulation simulation, string nom)
        {
            Nom = nom;
            simulation.Attach<TickEvent>(Tick);
            this.simulation = simulation;
        }

        public virtual void Tick(TickEvent e)
        {
            ComportementDeplace?.Deplace(this);
        }

        public void SeDeplacer()
            => ComportementDeplace?.Deplace(this);

        public override string ToString()
            => Nom;
    }

    public interface IPersonnage:IPositionnable
    {
        string Nom { get; }
    }

    public interface IPositionnable
    {
        IZone Position { get; set; }
    }
}