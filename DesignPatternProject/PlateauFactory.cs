using System.Collections.Generic;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    interface IFabriquePlateau
    {
        IPlateau CreerPlateau();
    }

    public class FabriquePlateau : IFabriquePlateau
    {
        IPlateau IFabriquePlateau.CreerPlateau()
            => new PlateauDeJeu();
    }

    interface IPlateau
    {
        void AjouterAcces(IAcces acces);
        void AjouterZone(IZone zone);
        IEnumerable<IAcces> ListAcces { get; }
        IEnumerable<IZone> ListZones { get; }
    }

    public class PlateauDeJeu:IPlateau
    {
        private List<IAcces> listAcces { get; } = new List<IAcces>();
        private List<IZone> listZones { get; } = new List<IZone>();
        public IEnumerable<IAcces> ListAcces 
            => listAcces;
        public IEnumerable<IZone> ListZones 
            => ListZones;  
        public void AjouterAcces(IAcces acces)
            => listAcces.Add(acces);
        
        public void AjouterZone(IZone zone)
            => listZones.Add(zone);
    }
}