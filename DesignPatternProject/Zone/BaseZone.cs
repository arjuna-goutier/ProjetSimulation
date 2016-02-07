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
        int X { get; }
        int Y { get; }
        void AjouterPersonnage(IPersonnage personnage);
        void SupprimerPersonnage(IPersonnage personnage);
        IEnumerable<IPersonnage> Personnages { get; } 
        IEnumerable<IZone> ZoneLimitrophe { get; }
        IList<IAcces> Access { get; }
        void LinkTo<TCreated>(IZone other) where TCreated : IAcces;
    }

    public abstract class BaseZone: IZone
    {
        public string Nom { get; set; }

        public int X { get; }
        public int Y { get; }
        public List<IPersonnage> Personnages { get; set; } = new List<IPersonnage>();
        public override string ToString() 
            => Nom;

        protected BaseZone(string nom, int x, int y)
        {
            Nom = nom;
            X = x;
            Y = y;
        }

        public void AjouterPersonnage(IPersonnage personnage)
        {
            Personnages.Add(personnage);
            //personnage.Position = this;
        }

        public void SupprimerPersonnage(IPersonnage personnage)
        {
            Personnages.Remove(personnage);
        }

        public IEnumerable<IZone> ZoneLimitrophe
            => Access.Select(acces => acces.Other(this));

        public void LinkTo<TCreated>(IZone other) where TCreated : IAcces
        {
            var v = (TCreated) Activator.CreateInstance(typeof(TCreated), this, other);
            other.Access.Add(v);
            this.Access.Add(v);
        }

        private readonly IList<IAcces> access = new List<IAcces>();
        public IList<IAcces> Access
            => access;
        public abstract string Description { get; }

        IEnumerable<IPersonnage> IZone.Personnages
            => Personnages;
    }
}
