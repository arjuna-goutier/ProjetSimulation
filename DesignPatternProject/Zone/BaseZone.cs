using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Acces;

namespace SimulationPersonnage.Zone
{
    public interface IZone
    {
        string Nom { get; set; }
        void AjouterPersonnage(Personnage personnage);
        void SupprimerPersonnage(Personnage personnage);
        IList<IAcces> Access { get; set; }
        IEnumerable<IZone> ZoneLimitrophe { get; }
        TAcces LinkTo<TAcces>(IZone other) where  TAcces :  IAcces;
    }

    public abstract class BaseZone:IZone
    {
        public string Nom { get; set; }
        public List<Personnage> Personnages { get; set; } = new List<Personnage>();


        protected BaseZone(string nom)
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

        public IEnumerable<IZone> ZoneLimitrophe
            => Access.Select(acces => acces.Other(this));

        public TAcces LinkTo<TAcces>(IZone other) where TAcces : IAcces
        {
            var v = (TAcces) Activator.CreateInstance(typeof(TAcces), this, other);
            other.Access.Add(v);
            this.Access.Add(v);
            return v;
        }

        public IList<IAcces> Access { get; set; } = new List<IAcces>();
        public abstract string Description { get; }
    }
}
