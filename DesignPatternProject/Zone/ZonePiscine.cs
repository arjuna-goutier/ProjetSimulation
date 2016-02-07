using System.Linq;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage.Zone
{
    class ZonePiscine: BaseZone
    {
        public int Numero { get;}
            
        public ZonePiscine(string nom, int numero, int x, int y) : base(nom, x, y)
        {
            Numero = numero;

        }

        public override string Description
            => "une zone de piscine";
    }
}
