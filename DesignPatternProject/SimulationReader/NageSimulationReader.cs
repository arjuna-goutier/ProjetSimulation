using System;
using System.Collections.Generic;
using SimulationPersonnage;
using SimulationPersonnage.Fabrique;

namespace DesignPatternProject.SimulationReader
{
    //crée un flux correspondant aux choix des utilisateurs
    class NageSimulationReader: ISimulationReader
    {
        public int NombreNageur;
        public int NombreSpectateur;
        public int LongueurPiscine;
        public int NombreTour;


        public string Coordonnées(int x, int y)
            => $"({x},{y})";

        public IEnumerable<IReaded> GetElements()
        {
            yield return new Readed(ESimulationObjectType.Simulation, new Dictionary<string, string> {
                ["NombreDeTour"] = NombreTour.ToString()
            });
            for (var y = 0; y < NombreNageur * 2; ++y)
            {
                if (y%2 != 0 && y != NombreNageur * 2 - 1) {
                    for (var x = 0; x < LongueurPiscine; ++x)
                        yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                            ["type"] = "separation",
                            ["nom"] = Coordonnées(x, y),
                            ["numero"] = x.ToString(),
                            ["x"] = x.ToString(),
                            ["y"] = y.ToString()
                        });
                    continue;
                }
                //on commence par faire le nageur et ou il est
                yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                    ["type"] = "piscine",
                    ["nom"] = Coordonnées(0, y),
                    ["numero"] = 0.ToString(),
                    ["x"] = 0.ToString(),
                    ["y"] = y.ToString()

                });
                yield return new Readed(ESimulationObjectType.Personnage, new Dictionary<string, string> {
                    ["type"] = "nageur",
                    ["nom"] = Guid.NewGuid().ToString(),
                    ["at"] = Coordonnées(0, y),
                });

                for (var x = 1; x < LongueurPiscine; ++x)
                {
                    yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                        ["type"] = "piscine",
                        ["nom"] = Coordonnées(x, y),
                        ["numero"] = x.ToString(),
                        ["x"] = x.ToString(),
                        ["y"] = y.ToString()
                    });

                    yield return new Readed(ESimulationObjectType.Acces, new Dictionary<string, string> {
                        ["type"] = "Praticable",
                        ["nom"] = Guid.NewGuid().ToString(),
                        ["to"] = Coordonnées(x - 1, y),
                        ["from"] = Coordonnées(x, y),
                    });

                    if (y > 0)
                    {
                    }
                }

            }
            int compteur = 0;
            for (var y = NombreNageur * 2; y <= NombreNageur * 2 + Math.Floor((decimal)NombreSpectateur/ LongueurPiscine); ++y)
            {
                for (var x = 0; x < LongueurPiscine; ++x)
                {
                    yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                        ["type"] = "bord",
                        ["nom"] = Coordonnées(x, y),
                        ["x"] = x.ToString(),
                        ["y"] = y.ToString()
                    });
                    if (NombreSpectateur < compteur++)
                    {
                        yield return new Readed(ESimulationObjectType.Personnage, new Dictionary<string, string> {
                            ["nom"] = Guid.NewGuid().ToString(),
                            ["type"] = "spectateur",
                            ["at"] = Coordonnées(x, y),
                        });
                    }
                }
            }
        }

        public IFabriqueSimulation FabriqueSimulation()
            => new FabriqueNatation();

    }
}
