namespace SimulationPersonnage
{
    public class Ninja:Personnage
    {
        public Ninja(string nom, Organisation etatMajor) : base(nom, etatMajor)
        {
            ComportementCombat = new ComportementCombatNinja();
        }
    }
}