using System.Collections.Generic;
using SimulationPersonnage.Fabrique;

namespace SimulationPersonnage
{

    internal interface ISimulationReader
    {
        IEnumerable<IReaded> GetElements();
        IFabriqueSimulation FabriqueSimulation();
    }

    interface ISimuaitonReaderInConstuction : ISimulationReader
    {
        void AddElement(IReaded readed);
    }

    class BaseSimulationReader : ISimuaitonReaderInConstuction
    {
        private readonly IList<IReaded> elements = new List<IReaded>();

        public void AddElement(IReaded readed)
            => elements.Add(readed);

        public IEnumerable<IReaded> GetElements()
            => elements;

        public IFabriqueSimulation FabriqueSimulation()
            => new BaseFabriqueSimulation();
    }

    public interface IReaded
    {
        string this[string key] { get; }
        IDictionary<string,string> arguments { get; }
        ESimulationObjectType ObjectType { get; }
    }

    class Readed : IReaded
    {
        private readonly IDictionary<string, string> keys;

        public IDictionary<string, string> arguments
            => keys;
        public ESimulationObjectType ObjectType { get; }

        public Readed(ESimulationObjectType objectType, IDictionary<string, string> keys)
        {
            ObjectType = objectType;
            this.keys = keys;
        }

        public string this[string key]
            => keys[key];
    }


    public enum ESimulationObjectType
    {
        Simulation,
        Personnage,
        Zone,
        Acces
    }
}
