using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    public interface IZone
    {
        string Nom { get; set; }
        void AjouterPersonnage(Personnage personnage);
        void SupprimerPersonnage(Personnage personnage);
    }

    public abstract class Zone:IZone
    {
        public string Nom { get; set; }
        public List<Personnage> Personnages { get; set; } = new List<Personnage>();

        protected Zone(string nom)
        {
            Nom = nom;
        }

        public void AjouterPersonnage(Personnage personnage)
        {
            Personnages.Add(personnage);
        }

        public void SupprimerPersonnage(Personnage personnage)
        {
            Personnages.Remove(personnage);
        }

        public abstract string Description { get; }
    }
}
