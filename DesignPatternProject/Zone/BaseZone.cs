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
        IEnumerable<IZone> ZoneLimitrophe { get; }
        IList<IAcces> Access { get; }
        void LinkTo<TCreated>(IZone other) where TCreated : IAcces;
        int isPersonnagesEmtpy();
    }

    public abstract class BaseZone: IZone
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

        public void LinkTo<TCreated>(IZone other) where TCreated : IAcces
        {
            var v = (TCreated) Activator.CreateInstance(typeof(TCreated), this, other);
            other.Access.Add(v);
            this.Access.Add(v);
        }

        public int isPersonnagesEmtpy()
        {
            return Personnages.Count();
        }

        private readonly IList<IAcces> access = new List<IAcces>();
        public IList<IAcces> Access
            => access;
        public abstract string Description { get; }
    }
}
