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
        event EventHandler<RenteEventArgs> RenteUpdateEvent;
        void SetRente(double nyRente);
    }
}
