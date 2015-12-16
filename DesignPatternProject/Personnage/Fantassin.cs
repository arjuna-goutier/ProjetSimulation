namespace SimulationPersonnage
{
    public class Fantassin:Personnage
    {
        public Fantassin(string nom, Organisation etatMajor) : base(nom, etatMajor)
        {
            ComportementCombat = new ComportementApiedAvecHache();
            ComportementEmettreUnSon = new ComportementCrier();
            ComportementDeplace = new ComportementDeplaceApied();
            ComportementAffichage = new ComportementAffichageHumble();
        }
    }
}