using System;

namespace swt_examen
{
    public class BeregnYdelser : IBeregnYdelser
    {
        public double AktuelRente { get; set; }
        private IDisplay _display;
        private IRenteserver _renteserver;
        
        //public event EventHandler<RenteEventArgs> RenteUpdateEvent;

        //public double _renteEvent { get; set; }


        public BeregnYdelser(IDisplay display,IRenteserver renteserver)
        {
            _display = display;
            _renteserver = renteserver;
            _renteserver.RenteUpdateEvent += HandleRenteEvent;
            AktuelRente = _renteserver.rente; //Need to pull initial value, as the event happens before instantiating handler

        }
        
        public void HandleRenteEvent(object sender, RenteEventArgs e)
        {
            AktuelRente = e.Rente;
             //Print til display?
            //string message = "Rent updated to: " + AktuelRente;
            _display.UpdateRent(AktuelRente);
        }

        // Denne metode er implementeret, men skal testes
        // Den bruger annuitetsformlen
        public double BeregnYdelse(double beløb, int varighed)
        {
            double ydelse = double.MaxValue;

            if (varighed >= 1 && varighed <= 120)
            {
                if (AktuelRente == 0)
                {
                    ydelse = beløb / varighed;
                }
                else
                {
                    ydelse = beløb * AktuelRente / (1 - Math.Pow((1 + AktuelRente), -varighed));
                }
            }

            return ydelse;
        }
    }
}