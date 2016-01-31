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
    /// Logique d'interaction pour InitWindow.xaml
    /// </summary>
    public partial class InitWindow : Window
    {
        public InitWindow()
        {
            InitializeComponent();
        }

        private void initLauncherBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedSimulation = simulationChoix.Text;

            switch (selectedSimulation)
            {
                case "Course de natation":
                    Window1 mainWindow = new Window1();
                    mainWindow.Show();
                    break;
                case "Labyrinthe":
                    Window2 windowL = new Window2(selectedSimulation);
                    windowL.Show();
                    break;
                case "Trafic routier":
                    Window2 windowT = new Window2(selectedSimulation);
                    windowT.Show();
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void parcourirBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            dlg.DefaultExt = ".xml";
            dlg.Filter = "All Files (*.*)|*.*";
            
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                cheminFichier.Text = filename;
                cheminFichier.Focus();
                cheminFichier.Select(cheminFichier.Text.Length, 0);
            }
        }
    }
}
