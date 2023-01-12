using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{

    public interface IBeregnYdelser
    {
        double AktuelRente { get; set; }
        double BeregnYdelse(double beløb, int varighed);
    }
}
