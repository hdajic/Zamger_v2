using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca17198
{
    interface IProperty
    {
        String Ime { get; set; }
        String Prezime { get; set; }
        DateTime DatumRodjenja { get; set; }
    }
}
