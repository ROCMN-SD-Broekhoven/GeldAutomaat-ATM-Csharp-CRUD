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
using System.Windows.Shapes;

namespace AironAir_Kapitaalbeheer.views
{
    /// <summary>
    /// Interaction logic for Medewerker_toevoegen.xaml
    /// </summary>
    public partial class Medewerker_toevoegen : Window
    {
        public Medewerker_toevoegen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
        private void Button_Click_toevoegen(object sender, RoutedEventArgs e)
        {
            try
            {
                new MedewerkerFunctions().addMedewerker(vn.Text, em.Text, ww.Text);

                MessageBox.Show("Medewerker succesvol toegevoegd!");
            }
            catch
            {
                MessageBox.Show("Kon medewerker niet toevoegen, probeer het later opnieuw.", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
