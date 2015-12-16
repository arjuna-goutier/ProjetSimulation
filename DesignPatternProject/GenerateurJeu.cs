using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Fabrique;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    interface IGenerateurJeu
    {
        IPlateau GenererJeux(ISimulationReader reader);
    }

    class GenerateurJeu
    {
        private IFabriqueAcces fabriqueAcces;
        private IFabriquePersonnage fabriquePersonnage;
        private IFabriquePlateau fabriquePlateau;
        private IFabriqueZone fabriqueZone;

        public IPlateau GenererJeux(ISimulationReader reader)
        {
            var simulation = reader.FabriqueSimulation();
            fabriqueAcces = simulation.CreerFabriqueAcces();
            fabriqueZone = simulation.CreerFabriqueZone();
            fabriquePersonnage = simulation.CreerFabriquePersonnage();
            fabriquePlateau = simulation.CreerPlateauFactory();

            var plateau = fabriquePlateau.CreerPlateau();
            foreach (var readed in reader.GetElements())
            {
                switch (readed.ObjectType)
                {
                    case ESimulationObjectType.Personnage:
                        AjouterPersonnage(plateau, readed);
                        break;
                    case ESimulationObjectType.Zone:
                        AjouterZone(plateau, readed);
                        break;
                    case ESimulationObjectType.Acces:
                        AjouterAcces(plateau, readed);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return plateau;
        }

        private void AjouterPersonnage(IPlateau plateau, IReaded readed)
        {
            var at = FindByName(plateau, readed["at"]);
            at.AjouterPersonnage(fabriquePersonnage.CreerPersonnage(readed["Nom"], readed["Type"]));
        }

        private void AjouterZone(IPlateau plateau, IReaded readed)
        {
            plateau.AjouterZone(fabriqueZone.CreerZone(readed["Nom"], readed["Type"]));
        }
        private void AjouterAcces(IPlateau plateau, IReaded readed)
        {
            var from = FindByName(plateau, readed["from"]);
            var to = FindByName(plateau, readed["to"]);
            var acces = fabriqueAcces.CreerAcces(from, to, readed["Nom"], readed["Type"]);
            plateau.AjouterAcces(acces);
        }

        private static IZone FindByName(IPlateau plateau, string Name)
            => plateau.ListZones.Single(new NameComparer(Name).Compare);
    }

    internal interface ISimulationReader
    {
        IEnumerable<IReaded> GetElements();
        IFabriqueSimulation FabriqueSimulation();
    }

    interface ISimuaitonReaderInConstuction:ISimulationReader
    {
        void AddElement(IReaded readed);
    }

    class BaseSimulationReader:ISimuaitonReaderInConstuction
    {
        private readonly IList<IReaded> elements = new List<IReaded>();

        public void AddElement(IReaded readed)
            => elements.Add(readed);

        public IEnumerable<IReaded> GetElements()
            => elements;

        public IFabriqueSimulation FabriqueSimulation()
            => new BaseFabriqueSimulation();
    }

    internal interface IReaded
    {
        string this[string key] { get; }
        ESimulationObjectType ObjectType { get; }
    }

    class Readed :IReaded
    {
        private readonly IDictionary<string, string> keys;
        public ESimulationObjectType ObjectType { get; }

        public Readed(ESimulationObjectType objectType,IDictionary<string,string> keys)
        {
            ObjectType = objectType;
            this.keys = keys;
        }

        
        public string this[string key]
            => keys[key];

    }


    internal enum ESimulationObjectType
    {
        Personnage,
        Zone,
        Acces
    }
}
