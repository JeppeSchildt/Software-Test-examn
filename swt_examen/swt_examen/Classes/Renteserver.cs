using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{

    internal class Renteserver : IRenteserver
    {
        public event EventHandler<RenteEventArgs> RenteUpdateEvent;
        public double rente;
        public Renteserver()
        {
            rente = 0.1; 
        }
        public void SetRente(double nyRente)
        {
            rente = nyRente;
            OnRenteUpdate();
        }
        protected virtual void OnRenteUpdate()
        {
            RenteUpdateEvent?.Invoke(this, new RenteEventArgs());
        }
    }
}
