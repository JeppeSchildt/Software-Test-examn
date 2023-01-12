using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen.Interfaces
{
    public interface IPrinter
    {
        void UdskriveLåneDokument(double beløb, int varighed, double ydelse);
    }
}
