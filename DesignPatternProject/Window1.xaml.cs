using SimulationPersonnage.Zone;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DesignPatternProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        const int _nombreCase = 20;
        bool isSimulationRunning = false;

        int NageursNb { get; set; }
        int ToursNb { get; set; }

        public Window1()
        {
            InitializeComponent();
        }

        private void launcherBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isSimulationRunning)
            {
                isSimulationRunning = true;
                bool emptyTextBoxs = false;

                if (string.IsNullOrWhiteSpace(nageurTextBox.Text) || string.IsNullOrWhiteSpace(toursTextBox.Text))
                {
                    emptyTextBoxs = true;
                }

                if (emptyTextBoxs == true)
                {
                    showInformationBox();
                    return;
                }
                else
                {
                    NageursNb = int.Parse(nageurTextBox.Text);
                    ToursNb = int.Parse(toursTextBox.Text);
                    initialiserPiscine();
                }
            }
        }

        private void showInformationBox()
        {
            MessageBox.Show("Merci de remplir tous les champs", "Simulation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void initialiserPiscine()
        {
            List<List<IZone>> zones = new List<List<IZone>>();
            zones = initialiserZones();

            initialiserGrid();
            fillGrid(zones);
        }

        public List<List<IZone>> initialiserZones()
        {
            FabriqueConcreteZone fabriqueZone = new FabriqueConcreteZone();
            List<List<IZone>> zones = new List<List<IZone>>();

            for (int i = 0; i < NageursNb; i++)
            {
                List<IZone> listeZonePraticable = new List<IZone>();
                for (int j = 0; j < _nombreCase; j++)
                {
                    listeZonePraticable.Add(fabriqueZone.CreerZone("Patricable", "zone" + j));
                }
                zones.Add(listeZonePraticable);

                if (i != NageursNb - 1)
                {
                    List<IZone> listeZoneImpraticable = new List<IZone>();
                    for (int j = 0; j < _nombreCase; j++)
                    {
                        listeZoneImpraticable.Add(fabriqueZone.CreerZone("Impraticable", "zone" + j));
                    }
                    zones.Add(listeZoneImpraticable);
                }
            }

            SimulationPersonnage.Personnage p = new SimulationPersonnage.Ninja("Pierre", new SimulationPersonnage.Organisation("gg"));

            zones[0][17].AjouterPersonnage(p);

            return zones;
        }

        public void initialiserGrid()
        {
            for (int k = 0; k < NageursNb; k++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                PlateauGrid.RowDefinitions.Add(row);

                if (k != NageursNb - 1)
                {
                    RowDefinition row2 = new RowDefinition();
                    row2.Height = new GridLength(0.2, GridUnitType.Star);
                    PlateauGrid.RowDefinitions.Add(row2);
                }
            }

            for (int l = 0; l < _nombreCase; l++)
            {
                PlateauGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void fillGrid(List<List<IZone>> zones)
        {
            for (int i = 0; i < zones.Count; i++)
            {
                for (int j = 0; j < zones[i].Count; j++)
                {
                    Rectangle rectangle = new Rectangle();

                    if (zones[i][j].GetType().Name == "ZonePraticable")
                    {
                        if (!zones[i][j].isPersonnagesEmtpy())
                        {
                            Canvas canvas = new Canvas();
                            canvas.Background = new SolidColorBrush(Colors.Aquamarine);

                            Ellipse ellipse = new Ellipse();
                            ellipse.Fill = new SolidColorBrush(Colors.Beige);
                            ellipse.Width = 15;
                            ellipse.Height = 15;

                            Canvas.SetLeft(ellipse, 15);
                            Canvas.SetTop(ellipse, 15);
                            canvas.Children.Add(ellipse);

                            Grid.SetColumn(canvas, j);
                            Grid.SetRow(canvas, i);
                            PlateauGrid.Children.Add(canvas);
                        } else
                        {
                            rectangle.Fill = new SolidColorBrush(Colors.Aquamarine);

                            Grid.SetColumn(rectangle, j);
                            Grid.SetRow(rectangle, i);
                            PlateauGrid.Children.Add(rectangle);
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            rectangle.Fill = new SolidColorBrush(Colors.DimGray);

                            Grid.SetColumn(rectangle, j);
                            Grid.SetRow(rectangle, i);
                            PlateauGrid.Children.Add(rectangle);
                        } else
                        {
                            rectangle.Fill = new SolidColorBrush(Colors.Salmon);

                            Grid.SetColumn(rectangle, j);
                            Grid.SetRow(rectangle, i);
                            PlateauGrid.Children.Add(rectangle);
                        }
                    }
                }
            }
        }
    }
}