using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    public abstract class Personnage:Observable, IObservateur<Etat>,IPositionnable
    {
        public string Nom { get; }
        public Etat Etat { get; set; }
        public Organisation EtatMajor;
        public IComportementEmettreUnSon ComportementEmettreUnSon { get; set; }
        public IComportementCombat ComportementCombat { get; set; }
        public IComportementDeplace ComportementDeplace { get; set; }
        public IComportementAffichage ComportementAffichage { get; set; }
        public IZone Position { get; set; }

        protected Personnage(string nom, Organisation etatMajor)
        {
            Nom = nom;
            EtatMajor = etatMajor;
            EtatMajor?.Attach(this);
        }

        public string Afficher()
            => ComportementAffichage?.Afficher(this) ?? "Je refuse de divulguer mon identité";
        
        public virtual string Combat()
            => ComportementCombat?.Combatre() ?? "Je ne peut pas combatre";

        public string EmettreSon()
            => ComportementEmettreUnSon?.EmettreUnSon() ?? "Je ne peut pas parler";

        public void SeDeplacer()
            => ComportementDeplace?.Deplace(this);

        public void Update(Etat etat)
            => Etat = etat;
    }

    public interface IPositionnable
    {
        IZone Position { get; set; }
    }
}