namespace SimulationPersonnage
{
    public class ComportementAffichageNoble:IComportementAffichage
    {
        public string Afficher(Personnage personnage)
            => $"Je suis {personnage.Nom}, de {personnage.EtatMajor.Nom}, tu a dus déja avoir entendu parle de mois ! Je suis en {personnage.Etat}";
    }
}