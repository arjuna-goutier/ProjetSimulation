namespace SimulationPersonnage
{
    public abstract class Personnage:IObservateur<Etat>
    {
        public string Nom { get; }
        public Etat Etat { get; set; }
        public Organisation EtatMajor;
        public IComportementEmettreUnSon ComportementEmettreUnSon { get; set; }
        public IComportementCombat ComportementCombat { get; set; }
        public IComportementDeplace ComportementDeplace { get; set; }
        public IComportementAffichage ComportementAffichage { get; set; }

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

        public string SeDeplacer()
            => ComportementDeplace?.Deplace() ?? "Je ne peut pas me deplacer";

        public void Update(Etat etat)
            => Etat = etat;
    }
}