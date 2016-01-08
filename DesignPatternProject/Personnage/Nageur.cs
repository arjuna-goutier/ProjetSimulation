using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{

    class Nageur:Personnage
    {
        public void Commencer()
            => ComportementDeplace = new ComportementNage();
        
        public void Arriver()
            => ComportementDeplace = new ComportemenImmobile();
        
        private IList<Modifieur<int>> Mofifieurs { get; } = new List<Modifieur<int>>();

        public int Vitesse { get; set; } = 10;

        public Nageur(string nom) : base(nom, null)
        {
            ComportementDeplace = new ComportemenImmobile();
        }
        public void généré_bonus(int bonus)
        {
            Vitesse=+ bonus;
        }

        public void réintialisé()
        {
            Vitesse = 10;

        }

    }

    static class BonusesHelper
    {
        public static TValue Appliquer<TValue>(this IEnumerable<Modifieur<TValue>> bonus, TValue start)
            => bonus.Aggregate(start, (c, mod) => mod(c));
    }

    internal delegate TValue Modifieur<TValue>(TValue value);
}