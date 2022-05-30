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
    /// Interaction logic for ZoekResultatenRekNR.xaml
    /// </summary>
    public partial class ZoekResultatenRekNR : UserControl
    {
        Gebruiker geb = new Gebruiker();

        public ZoekResultatenRekNR(string rekNR)
        {
            InitializeComponent();
            MedewerkerFunctions mw = new MedewerkerFunctions();
            GebruikerFunctions gebf = new GebruikerFunctions();
            int uid = mw.getUIDbyRekNR(rekNR);
            geb = mw.getGebruiker(uid);
            nam.Content = "Naam: " + geb.VolNaam;
            sld.Content = "Saldo: " + gebf.getSaldo(uid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMedewerker());
        }

        private void Button_Click_bew(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new BewerkGebruiker(geb));
        }

        private void Button_Click_V(object sender, RoutedEventArgs e)
        {
            new MedewerkerFunctions().remGebruiker(geb.GID);
            MessageBox.Show("Gebruiker succesvol verwijderd!");
            Switcher.Switch(new MainMedewerker());
        }
    }
}
