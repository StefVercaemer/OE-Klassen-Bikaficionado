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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fietsen.Lib.Entities;

namespace Bikaficionado.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FietsWinkel fietsWinkel = new FietsWinkel("Het velootje");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstFietsen.ItemsSource = fietsWinkel.Fietsen;
            //lblTitel.Content = $"{fietsWinkel.Naam} ({fietsWinkel.Fietsen.Count})";
            lblTitel.Content = fietsWinkel;
            //in lblTitel: naam van de winkel en aantal fietsen
            for (int i = 0; i < 5; i++)
            {
                cmbAantalWielen.Items.Add(i);
            }
            
        }

        private void lstFietsen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstFietsen.SelectedItem != null)
            {
                Fiets geselecteerdeFiets = (Fiets)lstFietsen.SelectedItem;
                txtMerk.Text = geselecteerdeFiets.Merk;
                dtpAankoopDatum.SelectedDate = geselecteerdeFiets.AankoopDatum;
                chkElektrisch.IsChecked = geselecteerdeFiets.IsElektrisch;
                cmbAantalWielen.SelectedItem = geselecteerdeFiets.AantalWielen;
                txtSnelheid.Text = geselecteerdeFiets.Snelheid.ToString();
            }
        }


    }
}
