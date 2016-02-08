using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternProject.SimulationReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternProject.SimulationReader;
namespace DesignPatternProject.SimulationReader.Tests
{
    [TestClass()]
    public class RoutesSimulationReaderTests
    {
        [TestMethod()]
        public void GetElementsTest()
        {
            var ok = new RoutesSimulationReader
            {
                Longueur = 10,
                Largeur =  10,
                NombreEntreeSortie =  5,
                NombreVehicule = 10
            };
            foreach (var variable in ok.GetElements())
            {
                Console.WriteLine(variable);
            }
        }

        [TestMethod()]
        public void Interieur_Droite()
        {
            var actual = RoutesSimulationReader.Interieur(5, 5, new Coordonées(4, 2));
            var expected = new Coordonées(3, 2);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void Interieur_Gauche()
        {
            var actual = RoutesSimulationReader.Interieur(5, 5, new Coordonées(0, 3));
            var expected = new Coordonées(1, 3);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void Interieur_Haut()
        {
            var actual = RoutesSimulationReader.Interieur(5, 5, new Coordonées(2, 0));
            var expected = new Coordonées(2, 1);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod()]
        public void Interieur_Bas()
        {
            var actual = RoutesSimulationReader.Interieur(5, 5, new Coordonées(2, 4));
            var expected = new Coordonées(2, 3);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void BordAleatoir()
        {
            foreach (var value in Enumerable.Range(1,10000))
            {
                var ok = RoutesSimulationReader.BordAleatoir(5, 5);
                Assert.IsTrue(RoutesSimulationReader.IsBord(5, 5, ok));
            }
        }
    }
}