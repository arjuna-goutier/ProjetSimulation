using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Policy;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    public interface IPlateauFactory
    {
        PlateauDeJeuAbstrait CreerPlateau();
    }

    public class LabyrintheFactory : IPlateauFactory
    {
        PlateauDeJeuAbstrait IPlateauFactory.CreerPlateau()
            => new PlateauDeJeu();
    }

    public abstract class PlateauDeJeuAbstrait
    {
        List<Zone.Zone> ListZones { get; set; }
        List<Acces.Acces> ListAcces { get; set; }

        public abstract void AjouterZone(Zone.Zone zone);
        public abstract void AjouterAcce(Acces.Acces acces);
    }

    public class PlateauDeJeu : PlateauDeJeuAbstrait
    {
        List<Acces.Acces> ListAcces;
        List<Zone.Zone> ListZones;

        public PlateauDeJeu()
        {
            ListAcces = new List<Acces.Acces>();
            ListZones = new List<Zone.Zone>();
        }

        public List<Acces.Acces> getListAcces()
        {
            return ListAcces;
        }

        public List<Zone.Zone> getListZone()
        {
            return ListZones;
        }

        public override void AjouterAcce(Acces.Acces acces)
        {
            ListAcces.Add(acces);
        }

        public override void AjouterZone(Zone.Zone zone)
        {
            ListZones.Add(zone);
        }
    }
}