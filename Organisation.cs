using System;
using System.Collections.Generic;

namespace SimulationPersonnage
{
    public enum Etat
    {
        NonDefini,
        Paix,
        Guerre
    }
    public class Organisation:Observable
    {
        private Etat etat;

        public Etat Etat
        {
            get { return etat; }
            set
            {
                etat = value;
                Update(etat);
            }
        }

        public string Nom { get; set; }

        public Organisation(string nom, Etat etat = Etat.NonDefini)
        {
            Nom = nom;
            Etat = etat;
        }

        public List<IObservateur<Etat>> observateurs { get; }
    }
}