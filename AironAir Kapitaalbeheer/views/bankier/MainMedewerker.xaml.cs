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
    /// Interaction logic for MainMedewerker.xaml
    /// </summary>
    public partial class MainMedewerker : UserControl, ISwitchable
    {
        public MainMedewerker()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
        }

        private void Button_Click_SN(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ZoekResultatenNaam(zt.Text));
        }

        private void Button_Click_SRN(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ZoekResultatenRekNR(zt.Text));
        }

        private void Button_Click_GT(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AddGebruiker());
        }
    }
}
