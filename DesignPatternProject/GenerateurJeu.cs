using System;
using System.Linq;
using SimulationPersonnage.Acces;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    interface IGenerateurJeu
    {
        ISimulation GenererJeux(ISimulationReader reader);
    }


    class GenerateurJeu:IGenerateurJeu
    {
        private IFabriqueAcces fabriqueAcces;
        private IFabriquePersonnage fabriquePersonnage;
        private IFabriquePlateau fabriquePlateau;
        private IFabriqueZone fabriqueZone;

        public ISimulation GenererJeux(ISimulationReader reader)
        {
            var partMaker = reader.FabriqueSimulation();
            var simulation = partMaker.CreerSimulation(reader.GetElements().First().arguments);

            fabriqueAcces = partMaker.CreerFabriqueAcces(simulation);
            fabriqueZone = partMaker.CreerFabriqueZone(simulation);
            fabriquePersonnage = partMaker.CreerFabriquePersonnage(simulation);
            fabriquePlateau = partMaker.CreerPlateauFactory(simulation);

            simulation.Plateau = fabriquePlateau.CreerPlateau();
            foreach (var readed in reader.GetElements().Skip(1))
            {
                switch (readed.ObjectType)
                {
                    case ESimulationObjectType.Personnage:
                        AjouterPersonnage(simulation.Plateau, readed);
                        break;
                    case ESimulationObjectType.Zone:
                        AjouterZone(simulation.Plateau, readed);
                        break;
                    case ESimulationObjectType.Acces:
                        AjouterAcces(simulation.Plateau, readed);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return simulation;
        }

        private void AjouterPersonnage(IPlateau plateau, IReaded readed)
        {
            var personnage = fabriquePersonnage.CreerPersonnage(readed["nom"], readed["type"]);
            var at = FindByName(plateau, readed["at"]);
            personnage.Position = at;
        }

        private void AjouterZone(IPlateau plateau, IReaded readed)
        {
            plateau.AjouterZone(fabriqueZone.CreerZone(readed.arguments));
        }

        private void AjouterAcces(IPlateau plateau, IReaded readed)
        {
            var from = FindByName(plateau, readed["from"]);
            var to = FindByName(plateau, readed["to"]);
            var acces = fabriqueAcces.CreerAcces(from, to, readed["nom"], readed["type"]);
            plateau.AjouterAcces(acces);
        }

        private static IZone FindByName(IPlateau plateau, string name) 
            => plateau.GetZone(name);
    }
}
