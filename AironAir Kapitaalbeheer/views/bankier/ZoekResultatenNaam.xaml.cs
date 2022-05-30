using AironAir_Kapitaalbeheer.Classes;
using AironAir_Kapitaalbeheer.Classes.Entiteiten;
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

namespace AironAir_Kapitaalbeheer.views.bankier
{
    /// <summary>
    /// Interaction logic for ZoekResultatenNaam.xaml
    /// </summary>
    public partial class ZoekResultatenNaam : UserControl, ISwitchable
    {
        private Gebruiker[] gebr = new Gebruiker[0];
        public ZoekResultatenNaam(string naam)
        {
            InitializeComponent();
            gebr = new MedewerkerFunctions().getGebArrByName(naam);
            foreach (Gebruiker bruik in gebr )
            {
                cb1.Items.Add(bruik.GID + ": " + bruik.VolNaam + " | " + bruik.RekNR);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMedewerker());
        }

        private void Button_Click_V(object sender, RoutedEventArgs e)
        {
            string item = cb1.Text;
            string[] words = item.Split(":");
            item = words[0];
            int UID = int.Parse(item);
            new MedewerkerFunctions().remGebruiker(UID);
            MessageBox.Show("Gebruiker succesvol verwijderd!");
            Switcher.Switch(new MainMedewerker());
        }

        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            string item = cb1.Text;
            string[] words = item.Split(":");
            item = words[0];
            int UID = int.Parse(item);
            Switcher.Switch(new BewerkGebruiker(new MedewerkerFunctions().getGebruiker(UID)));
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
