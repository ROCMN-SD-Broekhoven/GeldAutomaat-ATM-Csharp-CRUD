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

namespace AironAir_Kapitaalbeheer.views.bankier
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, ISwitchable
    {
        public Login()
        {
            InitializeComponent();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            MedewerkerFunctions mwf = new MedewerkerFunctions();
            if (mwf.loginMW(em.Text, ww.Text) == true)
            {
                Switcher.Switch(new MainMedewerker());
            }
            else
            {
                MessageBox.Show("Login informatie niet correct.", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
