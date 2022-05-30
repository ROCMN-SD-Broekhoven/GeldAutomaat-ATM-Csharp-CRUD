using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer.Classes.Entiteiten
{
    public class Gebruiker
    {
        public int GID { get; set; }
        public string VolNaam { get; set; } = "";
        public string Email { get; set; } = "";
        public int TelNR { get; set; }
        public string RekNR { get; set; } = "NL69AIRN";
        public string pinCodeHash { get; set; } = "";
        public bool IsJongerenRekening { get; set; }
    }
}
