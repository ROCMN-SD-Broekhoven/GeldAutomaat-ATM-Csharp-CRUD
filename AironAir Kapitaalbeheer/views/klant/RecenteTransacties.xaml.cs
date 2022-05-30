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

namespace AironAir_Kapitaalbeheer.views.klant
{
    /// <summary>
    /// Interaction logic for RecenteTransacties.xaml
    /// </summary>
    public partial class RecenteTransacties : UserControl, ISwitchable
    {
        private int globUID;
        public RecenteTransacties(int UID)
        {
            InitializeComponent();
            globUID = UID;
            Transactie[] transacties = new GebruikerFunctions().get3LaatsteTransacties(globUID);
            tb1.Text = transacties[0].Saldo + " | " + transacties[0].Omschrijving + " | " + transacties[0].DatumTijd;
            tb2.Text = transacties[1].Saldo + " | " + transacties[1].Omschrijving + " | " + transacties[1].DatumTijd;
            tb3.Text = transacties[2].Saldo + " | " + transacties[2].Omschrijving + " | " + transacties[2].DatumTijd;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainKlant(globUID));
        }
    }
}
