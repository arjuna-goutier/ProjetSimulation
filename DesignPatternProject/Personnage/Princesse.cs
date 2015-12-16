namespace SimulationPersonnage
{
    public class Princesse : Personnage   
    {
        public Princesse(string nom,Organisation organisation) : base(nom, organisation)
        {
            ComportementEmettreUnSon = new ComportementParlerPrincesse();
            ComportementDeplace = new ComportementDeplaceApied();
            ComportementAffichage = new ComportementAffichageNoble();
        }
    }
}