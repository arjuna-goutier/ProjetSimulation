namespace SimulationPersonnage
{
    public class ComportementAffichageHumble:IComportementAffichage
    {
        public string Afficher(Personnage personnage)
            => $"Je suis {personnage.Nom}, de {personnage.EtatMajor.Nom}. Je suis en {personnage.Etat}";
    }
}