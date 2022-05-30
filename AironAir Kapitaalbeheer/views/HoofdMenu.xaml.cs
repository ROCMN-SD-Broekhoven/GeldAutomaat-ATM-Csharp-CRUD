using AironAir_Kapitaalbeheer.views.bankier;
using AironAir_Kapitaalbeheer.views.klant;
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
    /// Interaction logic for HoofdMenu.xaml
    /// </summary>
    public partial class HoofdMenu : Window
    {
        public HoofdMenu(bool klant)
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            if(klant == true)
            {
                Switcher.Switch(new LoginKlant());
            }
            else
            {
                Switcher.Switch(new Login());
            }
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }
}
