using System.Security.AccessControl;
using System.Security.Policy;

namespace SimulationPersonnage
{
    public interface IPlateauFactory
    {
        IAcces CreerAcces();
        IZone CreerZone();
        IPlateau CreerPlateau();
    }

    public interface IAcces
    {
    }

    public interface IZone
    {
    }

    public interface IPlateau
    {
    }

    public class FourmillereFactory : IPlateauFactory
    {
        IAcces IPlateauFactory.CreerAcces()
            => new Tunnel();

        IZone IPlateauFactory.CreerZone()
            => new Salle();
        
        IPlateau IPlateauFactory.CreerPlateau()
            => new Fourmillere();
    }

    public class Fourmillere:IPlateau
    {
        
    }

    public class Salle:IZone
    {
        
    }

    public class Tunnel:IAcces
    {
        
    }
}