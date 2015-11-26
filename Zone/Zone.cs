using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationPersonnage.Zone
{
    public abstract class Zone
    {
        public String Nom { get; set; }
        public bool IsAccessible { get; set; }
        public List<Personnage> Personnages;

        public Zone(string nom, bool accessible)
        {
            Nom = nom;
            IsAccessible = accessible;
        }

        public void AjouterPersonnage(Personnage personnage)
        {
            Personnages.Add(personnage);
        }

        public void SupprimerPersonnage(Personnage personnage)
        {
            Personnages.Remove(personnage);
        }

        public abstract void getDescription();
    }
}
