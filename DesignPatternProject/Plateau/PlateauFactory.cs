using System.Collections.Generic;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;
using System;
using System.Linq;

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

    public interface IPlateau
    {
        void AjouterAcces(IAcces acces);
        void AjouterZone(IZone zone);
        IEnumerable<IAcces> ListAcces { get; }
        IEnumerable<IZone> ListZones { get; }
        IEnumerable<IPersonnage> Personnages { get; }
        IAcces GetAcces(string nom);
        IZone GetZone(string nom);
        IEnumerable<IEnumerable<IZone>> Grille { get; }
    }

    class PlateauDeJeu : IPlateau
    {
        private readonly IDictionary<string, IAcces> listAcces = new Dictionary<string, IAcces>();
        private readonly IDictionary<string, IZone> listZones = new Dictionary<string, IZone>();
        protected List<IPersonnage> listPersonage { get; } = new List <IPersonnage>();



        public IEnumerable<IAcces> ListAcces
            => listAcces.Values;
        public IEnumerable<IZone> ListZones
            => listZones.Values;

        public IEnumerable<IPersonnage> Personnages 
            => ListZones.SelectMany(z => z.Personnages);

        public IAcces GetAcces(string nom)
            => listAcces[nom];

        public IZone GetZone(string nom)
            => listZones[nom];

        public IEnumerable<IEnumerable<IZone>> Grille
        {
            get
            {
                for (var y = 0; listZones.ContainsKey($"({0},{y})"); ++y)
                    yield return ligne(y);
            }
        }

        private IEnumerable<IZone> ligne(int y)
        {
            for (var x = 0; listZones.ContainsKey($"({x},{y})"); ++x)
                yield return listZones[$"({x},{y})"];
        }

        public void AjouterAcces(IAcces acces)
            => listAcces.Add(acces.Nom, acces);
        
        public void AjouterZone(IZone zone)
            => listZones.Add(zone.Nom, zone);
    }
}