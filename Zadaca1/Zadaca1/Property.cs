using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    interface Property
    {
        String Ime { get; set; }
        String Prezime { get; set; }
        Datum DatumRodjenja { get; set; }
    }
}
