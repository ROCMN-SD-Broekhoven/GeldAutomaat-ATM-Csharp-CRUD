using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer.Classes.Entiteiten
{
    internal class Transactie
    {
        public int TID { get; set; }
        public int GID { get; set; } = -1;
        public float Saldo { get; set; }
        public string Omschrijving { get; set; } = "";
        public DateTime DatumTijd { get; set; }
    }
}
