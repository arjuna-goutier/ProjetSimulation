using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatternProject.Zone;
using SimulationPersonnage.Zone;

namespace SimulationPersonnage
{
    internal class ComportementNage : IComportementDeplace
    {
        private int nombreTour;
        private bool isAllée = true;
        public ComportementNage(int nombreTour)
        {
            this.nombreTour = nombreTour;
        }

        public void Deplace(Personnage personnage)
        {
            var nageur = (Nageur) personnage;//seul les nageur nagent
            var vitesse = nageur.Vitesse;

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var i in Enumerable.Range(0, vitesse))
                if (AvenceUneCase(nageur) == false)
                    return;
            Console.WriteLine($"{nageur} : {nageur.Position}");
        }

        private bool AvenceUneCase(Nageur nageur)
        {
            var current = (ZonePiscine)nageur.Position;
            var possibles = current.ZoneLimitrophe
                .OfType<ZonePiscine>();
            var next = isAllée 
                ? possibles.MaxBy(zone => zone.Numero)
                : possibles.MinBy(zone => zone.Numero);
            if ((isAllée && next.Numero < current.Numero) || (!isAllée && next.Numero > current.Numero))
            {
                isAllée = !isAllée;
                if (--nombreTour == 0)
                {
                    nageur.Arriver();
                    return false;
                }
            }
            nageur.Position = next;
            return true;
        }
    }

    static class EnumerableExtensions
    {
        public static T MaxBy<T, U>(this IEnumerable<T> source, Func<T, U> selector)
          where U : IComparable<U>
        {
            if (source == null) throw new ArgumentNullException("source");
            var first = true;
            var maxObj = default(T);
            var maxKey = default(U);
            foreach (var item in source)
            {
                if (first)
                {
                    maxObj = item;
                    maxKey = selector(maxObj);
                    first = false;
                }
                else
                {
                    var currentKey = selector(item);
                    if (currentKey.CompareTo(maxKey) > 0)
                    {
                        maxKey = currentKey;
                        maxObj = item;
                    }
                }
            }
            if (first) throw new InvalidOperationException("Sequence is empty.");
            return maxObj;
        }
        public static T MinBy<T, U>(this IEnumerable<T> source, Func<T, U> selector)
          where U : IComparable<U>
        {
            if (source == null) throw new ArgumentNullException("source");
            var minObj = default(T);
            var minKey = default(U);
            foreach (var item in source)
            {
                var currentKey = selector(item);
                if (minKey?.Equals(default(U)) ?? false || currentKey.CompareTo(minKey) < 0)
                {
                    minKey = currentKey;
                    minObj = item;
                }
            }
            return minObj;
        }
    }
}