using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{

    public class Renteserver : IRenteserver
    {
        public event EventHandler<RenteEventArgs> RenteUpdateEvent;
        public double rente { get; set; }
        public Renteserver()
        {
            SetRente(0.1);
        }
        public void SetRente(double nyRente)
        {
            rente = nyRente;
            OnRenteUpdate();
        }
        protected virtual void OnRenteUpdate()
        {
            RenteUpdateEvent?.Invoke(this, new RenteEventArgs() { Rente=rente});
        }
    }
}
