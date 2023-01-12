using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    public class RenteEventArgs : EventArgs
    {
        public double Rente { get; set; }
    }
    public interface IRenteserver
    {
        double rente { get; set; }

        event EventHandler<RenteEventArgs> RenteUpdateEvent;
        void SetRente(double nyRente);
    }
}
