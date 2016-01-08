namespace SimulationPersonnage
{
    public class Chevalier:Personnage
    {
        public Chevalier(string nom, Organisation etatMajor) : base(nom, etatMajor)
        {
            ComportementCombat = new ComportementAcheval();
            ComportementEmettreUnSon = new ComportementParler();
            ComportementAffichage = new ComportementAffichageNoble();
        }

        public override string Combat()
        {
            var result = base.Combat();
            ComportementCombat = new ComportementApiedAvecHache();
            return result;
        }
    }
}