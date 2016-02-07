using SimulationPersonnage.Zone;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.Linq;
using DesignPatternProject.SimulationReader;
using DesignPatternProject.Zone;
using SimulationPersonnage;

namespace DesignPatternProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        const int NombreCase = 20;
        bool isSimulationRunning = false;

        private int NageursNb { get; set; }
        private int ToursNb { get; set; }

        public Window1()
        {
            InitializeComponent();
        }

        private void launcherBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isSimulationRunning)
                return;
            isSimulationRunning = true;
            var emptyTextBoxs = string.IsNullOrWhiteSpace(nageurTextBox.Text) 
                             || string.IsNullOrWhiteSpace(toursTextBox.Text);

            if (emptyTextBoxs)
            {
                ShowInformationBox();
                return;
            }
            NageursNb = int.Parse(nageurTextBox.Text);
            ToursNb = int.Parse(toursTextBox.Text);
            InitialiserPiscine();
        }

        private static void ShowInformationBox() 
            => MessageBox.Show("Merci de remplir tous les champs", "Simulation", MessageBoxButton.OK, MessageBoxImage.Information);

        public void InitialiserPiscine()
        {
            /*
            var zones = InitialiserZones();
            InitialiserGrid();
            FillGrid(zones);
            */
            var reader = new NageSimulationReader {
                LongueurPiscine = NombreCase,
                NombreNageur = NageursNb,
                NombreSpectateur = 0,
                NombreTour = ToursNb
            };
            var generateur = new GenerateurJeu();
            var simulation = generateur.GenererJeux(reader);
            InitialiserGrid();
            //simulation.Simuler();
            FillGrid(simulation.Plateau.Grille);
            simulation.Attach<EndTurnEvent>(e => 
                FillGrid(simulation.Plateau.Grille)
            );
            simulation.Simuler();
        }
        
        public List<List<IZone>> InitialiserZones()
        {
            var fabriqueZone = new FabriqueZoneNatation();
            var zones = new List<List<IZone>>();

            for (var i = 0; i < NageursNb; i++)
            {
                var listeZonePraticable = new List<IZone>();
                for (var j = 0; j < NombreCase; j++)
                {
                    listeZonePraticable.Add(fabriqueZone.CreerZone(new Dictionary<string, string> {
                       ["nom"] = $"({i},{j}",
                       ["x"] = j.ToString(),
                       ["y"] = i.ToString(),
                       ["type"] = "piscine",
                       ["numero"] = j.ToString()
                    }));
                }
                zones.Add(listeZonePraticable);

                if (i == NageursNb - 1)
                    continue;

                var listeZoneImpraticable = new List<IZone>();
                for (var j = 0; j < NombreCase; j++)
                {
                    listeZoneImpraticable.Add(fabriqueZone.CreerZone(new Dictionary<string, string> {
                        ["nom"] = $"({i},{j}",
                        ["x"] = j.ToString(),
                        ["y"] = i.ToString(),
                        ["type"] = "separation"
                    }));
                }
                zones.Add(listeZoneImpraticable);
            }

            return zones;
        }

        public void InitialiserGrid()
        {
            for (var k = 0; k < NageursNb; k++)
            {
                PlateauGrid.RowDefinitions.Add(new RowDefinition {
                    Height = new GridLength(1, GridUnitType.Star)
                });

                if (k == NageursNb - 1) continue;
                /*if (k == NageursNb - 1)
                {
                    PlateauGrid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = new GridLength(0.8, GridUnitType.Star)
                    });
                }*/

                PlateauGrid.RowDefinitions.Add(new RowDefinition {
                    Height = new GridLength(0.2, GridUnitType.Star)
                });
            }

            for (var l = 0; l < NombreCase; l++)
            {
                PlateauGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void FillGrid(IEnumerable<IEnumerable<IZone>> _zones)
        {
            var zones = _zones.Select(l => l.ToList()).ToList();

            for (var i = 0; i < zones.Count; i++)
            {
                for (var j = 0; j < zones[i].Count; j++)
                {
                    var rectangle = new Rectangle();

                    if (zones[i][j] is ZonePiscine)
                    {
                        if (zones[i][j].Personnages.Any())
                        {
                            var canvas = new Canvas {
                                Background = new SolidColorBrush(Colors.Aquamarine)
                            };

                            var ellipse = new Ellipse {
                                Fill = new SolidColorBrush(Colors.Beige),
                                Width = 15,
                                Height = 15
                            };

                            Canvas.SetLeft(ellipse, 15);
                            Canvas.SetTop(ellipse, 15);
                            canvas.Children.Add(ellipse);

                            Grid.SetColumn(canvas, j);
                            Grid.SetRow(canvas, i);
                            PlateauGrid.Children.Add(canvas);
                        }
                        else
                        {
                            rectangle.Fill = new SolidColorBrush(Colors.Aquamarine);

                            Grid.SetColumn(rectangle, j);
                            Grid.SetRow(rectangle, i);
                            PlateauGrid.Children.Add(rectangle);
                        }
                    }
                    else if (zones[i][j] is ZoneSeparation)
                    {
                        rectangle.Fill = new SolidColorBrush(Colors.DimGray);
                        Grid.SetColumn(rectangle, j);
                        Grid.SetRow(rectangle, i);
                        PlateauGrid.Children.Add(rectangle);
                    }
                    else
                    {
                        var canvas = new Canvas {
                            Background = new SolidColorBrush(Colors.LightYellow)
                        };
                        var ellipse = new Ellipse {
                            Fill = new SolidColorBrush(Colors.Green),
                            Width = 15,
                            Height = 15
                        };

                        Canvas.SetLeft(ellipse, 20);
                        Canvas.SetTop(ellipse, 25);
                        canvas.Children.Add(ellipse);

                        Grid.SetColumn(canvas, j);
                        Grid.SetRow(canvas, i);
                        PlateauGrid.Children.Add(canvas);
                    }
                }
            }
        }
    }

    static class EnumerableHelper
    {
        public class IndexValue<TValue>
        {
            public int Index { get; set; }
            public TValue Value { get; set; }
        }
        public static IEnumerable<IndexValue<TValue>> Indexed<TValue>(this IEnumerable<TValue> source)
            => source.Select((x, i) => new IndexValue<TValue> {
                Index = i,
                Value = x
            });
    }
}