using AironAir_Kapitaalbeheer.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AironAir_Kapitaalbeheer
{
    internal static class Switcher
    {
        public static HoofdMenu pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
