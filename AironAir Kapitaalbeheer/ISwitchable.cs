using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer
{
    internal interface ISwitchable
    {
        void UtilizeState(object state);
    }
}
