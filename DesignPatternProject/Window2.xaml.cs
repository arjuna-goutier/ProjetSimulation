using SimulationPersonnage.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignPatternProject
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        const int _nombreCase = 10;
        bool isSimulationRunning = false;
        private string selectedSimulation;

        int NbElements { get; set; }

        private SolidColorBrush couleurPraticable;
        private SolidColorBrush couleurImpraticable;
        private SolidColorBrush couleurPerso;

        public Window2(string selectedSimulation)
        {
            this.selectedSimulation = selectedSimulation;
            InitializeComponent();
        }

        private void launcherBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isSimulationRunning)
            {
                isSimulationRunning = true;
                bool emptyTextBoxs = false;

                if (string.IsNullOrWhiteSpace(elementsTextBox.Text))
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
                    NbElements  = int.Parse(elementsTextBox.Text);
                    initialiserPlateau();
                }
            }
        }

        private void showInformationBox()
        {
            MessageBox.Show("Merci de remplir tous les champs", "Simulation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void initialiserPlateau()
        {
            List<List<IZone>> zones = new List<List<IZone>>();

            if (selectedSimulation.Equals("Trafic routier"))
            {
                zones = getRoad();
                couleurPraticable = new SolidColorBrush(Colors.Gray);
                couleurImpraticable = new SolidColorBrush(Colors.LawnGreen);
                couleurPerso = new SolidColorBrush(Colors.Beige);
            }
            else
            {
                zones = getMaze();
                couleurPraticable = new SolidColorBrush(Colors.SandyBrown);
                couleurImpraticable = new SolidColorBrush(Colors.SaddleBrown);
                couleurPerso = new SolidColorBrush(Colors.Beige);
            }

            initialiserGrid();
            fillGrid(zones);
        }

        public void initialiserGrid()
        {
            for (int k = 0; k < _nombreCase; k++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Star);
                PlateauGrid.RowDefinitions.Add(row);
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

                    if (zones[i][j].GetType().Name == "BaseZonePraticable")
                    {
                        if (zones[i][j].Personnages.Any())
                        {
                            Canvas canvas = new Canvas();
                            canvas.Background = couleurPraticable;

                            Ellipse ellipse = new Ellipse();
                            ellipse.Fill = couleurPerso;
                            ellipse.Width = 15;
                            ellipse.Height = 15;

                            Canvas.SetLeft(ellipse, 15);
                            Canvas.SetTop(ellipse, 15);
                            canvas.Children.Add(ellipse);

                            Grid.SetColumn(canvas, j);
                            Grid.SetRow(canvas, i);
                            PlateauGrid.Children.Add(canvas);
                        }
                        else
                        {
                            rectangle.Fill = couleurPraticable;

                            Grid.SetColumn(rectangle, j);
                            Grid.SetRow(rectangle, i);
                            PlateauGrid.Children.Add(rectangle);
                        }
                    }
                    else
                    {
                        rectangle.Fill = couleurImpraticable;
                        Grid.SetColumn(rectangle, j);
                        Grid.SetRow(rectangle, i);
                        PlateauGrid.Children.Add(rectangle);
                    }
                }
            }
        }

        // Refactor
        public List<List<IZone>> getRoad()
        {
            /*
            FabriqueConcreteZone fabriqueZone = new FabriqueConcreteZone();

            List<IZone> zones = new List<IZone>();
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones1 = new List<IZone>();
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones2 = new List<IZone>();
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));

            List<IZone> zones3 = new List<IZone>();
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones4 = new List<IZone>();
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones5 = new List<IZone>();
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones6 = new List<IZone>();
            zones6.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));

            List<IZone> zones7 = new List<IZone>();
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones8 = new List<IZone>();
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones9 = new List<IZone>();
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<List<IZone>> allZones = new List<List<IZone>>();
            allZones.Add(zones);
            allZones.Add(zones1);
            allZones.Add(zones2);
            allZones.Add(zones3);
            allZones.Add(zones4);
            allZones.Add(zones5);
            allZones.Add(zones6);
            allZones.Add(zones7);
            allZones.Add(zones8);
            allZones.Add(zones9);

            return allZones;
            */
            return null;
        }

        // Refactor
        public List<List<IZone>> getMaze()
        {
            /*
            FabriqueConcreteZone fabriqueZone = new FabriqueConcreteZone();

            List<IZone> zones = new List<IZone>();
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones1 = new List<IZone>();
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones1.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones2 = new List<IZone>();
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones2.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones3 = new List<IZone>();
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones3.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones4 = new List<IZone>();
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones4.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones5 = new List<IZone>();
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones5.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones6 = new List<IZone>();
            zones6.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones6.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones7 = new List<IZone>();
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones7.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones8 = new List<IZone>();
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Patricable", "zone"));
            zones8.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<IZone> zones9 = new List<IZone>();
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));
            zones9.Add(fabriqueZone.CreerZone("Impraticable", "zone"));

            List<List<IZone>> allZones = new List<List<IZone>>();
            allZones.Add(zones);
            allZones.Add(zones1);
            allZones.Add(zones2);
            allZones.Add(zones3);
            allZones.Add(zones4);
            allZones.Add(zones5);
            allZones.Add(zones6);
            allZones.Add(zones7);
            allZones.Add(zones8);
            allZones.Add(zones9);

            return allZones;
            */
            return null;
        }
    }
}
