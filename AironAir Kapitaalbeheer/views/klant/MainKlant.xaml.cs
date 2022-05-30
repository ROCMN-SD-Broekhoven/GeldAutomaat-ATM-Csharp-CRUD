using AironAir_Kapitaalbeheer.Classes;
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

namespace AironAir_Kapitaalbeheer.views.klant
{
    /// <summary>
    /// Interaction logic for MainKlant.xaml
    /// </summary>
    public partial class MainKlant : UserControl, ISwitchable
    {
        private int globUID = 0;
        public MainKlant(int UID)
        {
            InitializeComponent();
            float Saldo = new GebruikerFunctions().getSaldo(UID);
            sal.Content = "€" + Saldo.ToString("0.00");
            globUID = UID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new LoginKlant());
        }

        private void Button_Click_SN(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GeldOvermaken(globUID));
        }

        private void Button_Click_GT(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GeldStorten(globUID));
        }

        private void Button_Click_SRN(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new GeldOpnemen(globUID));
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_LT(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecenteTransacties(globUID));
        }
    }
}
