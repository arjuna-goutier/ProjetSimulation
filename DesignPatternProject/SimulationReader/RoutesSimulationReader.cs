using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SimulationPersonnage;
using SimulationPersonnage.Fabrique;

namespace DesignPatternProject.SimulationReader
{
    public class RoutesSimulationReader:ISimulationReader
    {
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public int NombreEntreeSortie { get; set; }
        public int NombreVehicule { get; set; }
        public int RetardMaximum { get; set; }
        private static readonly Random Random = new Random();

        public IEnumerable<IReaded> GetElements()
        {
            var entrees = new HashSet<Coordonées>();
            var routes = new HashSet<Coordonées>();
            yield return new Readed(ESimulationObjectType.Simulation, new Dictionary<string, string>());
            for (var i = 0; i < NombreEntreeSortie; ++i)
            {
                Coordonées coordonnees;

                while (entrees.Contains(coordonnees = BordAleatoir(Longueur, Largeur))) {}

                entrees.Add(coordonnees);
                routes.Add(coordonnees);

                yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                    ["type"] = "entree",
                    ["nom"] = $"({coordonnees.X},{coordonnees.Y})",
                    ["x"] = coordonnees.X.ToString(),
                    ["y"] = coordonnees.Y.ToString()
                });
                
            }
            foreach (var entree in entrees)
            {
                foreach (var sortie in entrees.SkipWhile(sortie => entree.Equals(sortie)).Skip(1))
                {
                    foreach (var coordonnee in PathTo(entree, sortie))
                    {
                        if (!routes.Add(coordonnee)) continue;
                        yield return new Readed(ESimulationObjectType.Zone, new Dictionary<string, string>
                        {
                            ["type"] = "route",
                            ["nom"] = $"({coordonnee.X},{coordonnee.Y})",
                            ["x"] = coordonnee.X.ToString(),
                            ["y"] = coordonnee.Y.ToString()
                        });
                    }
                }
            }

            var batiments = from x in Enumerable.Range(0, Longueur)
                            from y in Enumerable.Range(0, Largeur)
                            where !routes.Contains(new Coordonées(x, y))
                            select new Readed(ESimulationObjectType.Zone, new Dictionary<string, string> {
                                ["type"] = "batiment",
                                ["nom"] = $"({x},{y})",
                                ["x"] = x.ToString(),
                                ["y"] = y.ToString()
                            });
            foreach (var batiment in batiments)
                yield return batiment;
            var a_routes = entrees.ToArray();
            foreach (var _ in Enumerable.Range(0, NombreVehicule))
            {
                var entree = a_routes[Random.Next(a_routes.Length)];
                yield return new Readed(ESimulationObjectType.Personnage, new Dictionary<string, string> {
                    ["type"] = "voiture",
                    ["nom"] = Guid.NewGuid().ToString(),
                    ["at"] = $"({entree.X},{entree.Y})"
                });
            }

            foreach (var coordonéese in routes)
            {
                var voisins = coordonéese.Voisins.Where(z => routes.Contains(z)).ToArray();
                if (voisins.Length >= 3)
                {
                    foreach (var voisin in voisins)
                    {
                        yield return new Readed(ESimulationObjectType.Personnage, new Dictionary<string, string> {
                            ["type"] = "feuTricolor",
                            ["nom"] = Guid.NewGuid().ToString(),
                            ["at"] = $"({voisin.X},{voisin.Y})"
                        });
                    }
                }
            }
        }
        /*
        public static IEnumerable<Coordonées> PathTo(Coordonées From, Coordonées To)
        {
            if (From.X == To.X)
            {
                foreach (var value in AllBetween(From.Y, To.Y))
                    yield return new Coordonées(From.X, value);
                yield break;
            }
            if (From.Y == To.Y)
            {
                foreach (var value in AllBetween(From.X, To.X))
                    yield return new Coordonées(From.Y, value);
                yield break;
            }
            var horizontal = From.X == 0 || To.X == 0;  //si un des endroits est a 
            if (horizontal)
            {
                var tournantIndex = Random.Next(1, Math.Max(From.X, To.X));
                var maxX = Math.Max(From.X, From.X);
                for (var x = 0; x < maxX; x++)
                {
                    yield return new Coordonées(x, );
                }
                yield break;
            }
            else
            {
                var tournantIndex = Random.Next(1, Math.Max(From.Y, From.Y));
                yield break;
            }
        }
        */

        private IEnumerable<Coordonées> PathTo(Coordonées From, Coordonées To)
        {
            var iFrom = Interieur(Longueur, Largeur, From);
            var iTo = Interieur(Longueur, Largeur, To);
            if (From.X == To.X || From.Y == To.Y) // dans le cas des lignes droites
                return From.Trait(To);

            var fromHorizontal = From.X == 0 || From.X == Longueur - 1;
            var toHorizontal = From.Y == 0 || From.Y == Largeur - 1;
            if (fromHorizontal ^ toHorizontal)
            {
                var tournant = new Coordonées(fromHorizontal ? iTo.X : iFrom.X, fromHorizontal ? iFrom.Y : iTo.Y);
                return new HashSet<Coordonées>(iFrom.Trait(tournant).Concat(tournant.Trait(iTo)));
            }

            Coordonées tournant1;
            Coordonées tournant2;
            if (fromHorizontal && toHorizontal)
            {
                var tournantIndex = Random.Next(1, Largeur - 1);
                tournant1 = new Coordonées(tournantIndex, From.Y);
                tournant2 = new Coordonées(tournantIndex, To.Y);
            }
            else
            {
                var tournantIndex = Random.Next(1, Longueur - 1);
                tournant1 = new Coordonées(From.X, tournantIndex);
                tournant2 = new Coordonées(To.X, tournantIndex);
            }
            return
                new HashSet<Coordonées>(iFrom.Trait(tournant1).Concat(tournant1.Trait(tournant2)).Concat(tournant2.Trait(iTo)));
        }

        private IEnumerable<T> ToSet<T>(IEnumerable<T> source)
        {
            var valeures = new HashSet<T>();
            foreach (var val in source)
                valeures.Add(val);
            return new HashSet<T>();
        }

        private static EInclinaison GetInclinaison(EDirection direction)
            => direction == EDirection.Bas || direction == EDirection.Haut
                ? EInclinaison.Vertical 
                : EInclinaison.Horizontal;
        public static Coordonées Interieur(int longueur, int largeur, Coordonées coordonnees)
        {
            if(coordonnees.X == 0) 
                return coordonnees.Droite;
            if (coordonnees.Y == 0)
                return coordonnees.Bas;
            if (coordonnees.X == largeur - 1)
                return coordonnees.Gauche;
            if (coordonnees.Y == longueur - 1)
                return coordonnees.Haut;
            throw new Exception("coordonnées incorect");
        }


        public static bool IsBord(int longueur, int largeur, Coordonées coordonnées) 
            => coordonnées.X == longueur - 1
            || coordonnées.X == 0
            || coordonnées.Y == largeur - 1
            || coordonnées.Y == 0;

        public static Coordonées BordAleatoir(int longueur, int largeur)
        {
            var values = Enum.GetValues(typeof(EDirection));

            switch ((EDirection) values.GetValue(Random.Next(values.Length)))
            {
                case EDirection.Droite:
                    return new Coordonées(0, Random.Next(1, longueur - 2));
                case EDirection.Gauche:
                    return new Coordonées(longueur - 1, Random.Next(1, longueur - 2));
                case EDirection.Haut:
                    return new Coordonées(Random.Next(1, longueur - 2), 0);
                case EDirection.Bas:
                    return new Coordonées(Random.Next(1, longueur - 2), largeur - 1);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public IFabriqueSimulation FabriqueSimulation()
            => new FabriqueTraficRoutier();
    }

    public enum EInclinaison
    {
        Vertical,
        Horizontal
    }
    public enum EDirection
    {
        Droite,
        Gauche,
        Haut,
        Bas
    }
    public struct Coordonées
    {
        public Coordonées(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        public Coordonées Haut
            => new Coordonées(X, Y - 1);
        public Coordonées Bas
            => new Coordonées(X, Y + 1);
        public Coordonées Gauche
            => new Coordonées(X - 1, Y);
        public Coordonées Droite
            => new Coordonées(X + 1, Y);

        public IEnumerable<Coordonées> Trait(Coordonées destination)
        {
            var x = X;
            var y = Y;
            if (X == destination.X)
                return  from i in Between(Y, destination.Y)
                        select new Coordonées(x, i);
            if (Y == destination.Y)
                return from i in Between(X, destination.Y)
                       select new Coordonées(i, y);
            throw  new Exception("");
        }

        public IEnumerable<Coordonées> Voisins
            => new[] { Gauche, Droite, Haut, Bas };
        public IEnumerable<int> Between(int x, int y)
        {
            var max = Math.Max(x,y);
            var min = Math.Min(x,y);
            for (var i = min; i <= max; ++i)
                yield return i;
        }

        //donne la direction a prendre pour aller vers le point
        public EDirection DirectionTo(Coordonées to)
        {
            if(X < to.X)
                return EDirection.Gauche;
            if (X > to.X)
                return EDirection.Droite;
            if (Y < to.Y)
                return EDirection.Haut;
            if (Y > to.Y)
                return EDirection.Bas;
            throw new Exception("meme point");
        }

        public int Inclinaison(EInclinaison inclinaison)
        {
            switch (inclinaison)
            {
                case EInclinaison.Vertical:
                    return Y;
                case EInclinaison.Horizontal:
                    return X;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inclinaison), inclinaison, null);
            }
        }

        public Coordonées GoTo(EDirection direction)
        {
            switch (direction)
            {
                case EDirection.Droite:
                    return Droite;
                case EDirection.Gauche:
                    return Gauche;
                case EDirection.Haut:
                    return Haut;
                case EDirection.Bas:
                    return Bas;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public Coordonées GetDirection(Coordonées next) => new Coordonées();

        public override int GetHashCode()
        {
            return X*11 + Y*13;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Coordonées == false)
                return false;
            var that = (Coordonées) obj;
            return this.X == that.X && this.Y == that.Y;
        }
    }
}
