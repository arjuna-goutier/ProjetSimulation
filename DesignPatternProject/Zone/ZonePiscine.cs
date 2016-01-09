using System.Linq;
using SimulationPersonnage.Zone;

namespace DesignPatternProject.Zone
{
    class ZonePiscine: BaseZone
    {
        public int Numero { get;}
            
        public ZonePiscine(string nom, int numero) : base(nom)
        {
            Numero = numero;
        }

        public override string Description
            => "une zone de piscine";
    }
}
