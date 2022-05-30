using AironAir_Kapitaalbeheer.views;
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

namespace AironAir_Kapitaalbeheer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoofdMenu win = new HoofdMenu(true);
            win.Show();
            this.Close();
        }

        private void Button_Click_mwt(object sender, RoutedEventArgs e)
        {
            Medewerker_toevoegen win = new Medewerker_toevoegen();
            win.Show();
            this.Close();
        }

        private void Button_Click_BA(object sender, RoutedEventArgs e)
        {
            HoofdMenu win = new HoofdMenu(false);
            win.Show();
            this.Close(); 
        }
    }
}
