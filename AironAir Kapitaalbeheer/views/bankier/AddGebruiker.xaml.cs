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
    /// Interaction logic for AddGebruiker.xaml
    /// </summary>
    public partial class AddGebruiker : UserControl, ISwitchable
    {
        private Gebruiker gebr = new Gebruiker();

        public AddGebruiker()
        {
            InitializeComponent();
        }

        private void Button_Click_toevoegen(object sender, RoutedEventArgs e)
        {
            gebr.VolNaam = vn.Text;
            gebr.Email = em.Text;
            gebr.TelNR = int.Parse(tn.Text);
            gebr.RekNR = rn.Text;
            gebr.pinCodeHash = pc.Text;
            bool newBool = jr.IsChecked.HasValue ? jr.IsChecked.Value : false;
            gebr.IsJongerenRekening = newBool;
            try
            {
                new MedewerkerFunctions().addGebruiker(gebr.VolNaam, gebr.Email, gebr.TelNR, gebr.RekNR, gebr.pinCodeHash, gebr.IsJongerenRekening);
                MessageBox.Show("Gebruiker succesvol toegevoegd!");
                Switcher.Switch(new MainMedewerker());
            }
            catch
            {
                MessageBox.Show("Kon gebruiker niet toevoegen, probeer het later opnieuw of wijzig je input.", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_genpin(object sender, RoutedEventArgs e)
        {
            Random _random = new Random();
            int randnr = _random.Next(0, 9999);
            pc.Text = randnr.ToString("D4");
        }

        private void Button_Click_genrn(object sender, RoutedEventArgs e)
        {
            rn.Text = new MedewerkerFunctions().genRekNR();

        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMedewerker());
        }
    }
}
