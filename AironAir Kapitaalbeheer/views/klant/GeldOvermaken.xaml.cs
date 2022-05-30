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
    /// Interaction logic for GeldOvermaken.xaml
    /// </summary>
    public partial class GeldOvermaken : UserControl, ISwitchable
    {
        private int globUID;
        public GeldOvermaken(int UID)
        {
            InitializeComponent();
            globUID = UID;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainKlant(globUID));
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            new GebruikerFunctions().sendTransfer(globUID, em.Text, float.Parse(ww.Text));
            Switcher.Switch(new MainKlant(globUID));
        }
    }
}
