using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer.Classes.Entiteiten
{
    internal class Medewerker
    {
        public int MID { get; set; }
        public string VolNaam { get; set; } = "";
        public string Email { get; set; } = "";
        public string WachtwoordHash { get; set; } = "";
    }
}
