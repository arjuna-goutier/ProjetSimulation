namespace SimulationPersonnage
{
    public class Archer:Personnage
    {
        public Archer(string nom, Organisation etatMajor) : base(nom, etatMajor)
        {
            ComportementCombat = new ComportementAvecArc();
            ComportementEmettreUnSon = new ComportementCrier();
            ComportementDeplace = new ComportementDeplaceApied();
            ComportementAffichage  = new ComportementAffichageHumble();
        }
    }
}