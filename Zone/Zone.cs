using System.Collections.Generic;

namespace SimulationPersonnage.Zone
{
    public abstract class Zone
    {
        public string Nom { get; set; }
        public List<Personnage> Personnages;

        public Zone(string nom)
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

        public abstract void getDescription();
    }
}
