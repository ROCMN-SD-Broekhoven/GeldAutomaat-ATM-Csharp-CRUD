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
    /// Interaction logic for LoginKlant.xaml
    /// </summary>
    public partial class LoginKlant : UserControl, ISwitchable
    {
        private int globUID;
        public LoginKlant()
        {
            InitializeComponent();

        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            GebruikerFunctions gbf = new GebruikerFunctions();
            if (gbf.loginGB(em.Text, ww.Text) == true)
            {
                globUID = new MedewerkerFunctions().getUIDbyRekNR(em.Text);
                Switcher.Switch(new MainKlant(globUID));
            }
            else
            {
                MessageBox.Show("Login informatie niet correct.", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Window.GetWindow(this).Close();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
    }
}
