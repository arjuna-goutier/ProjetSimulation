namespace SimulationPersonnage
{
    public interface IObservateur<in TChanged>
    {
        void Update(TChanged changed);
    }
}