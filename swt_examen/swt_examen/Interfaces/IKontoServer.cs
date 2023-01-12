using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen.Interfaces
{
    public interface IKontoServer
    {
        bool BogførBeløb(double beløb, int kontonummer);
    }
}
