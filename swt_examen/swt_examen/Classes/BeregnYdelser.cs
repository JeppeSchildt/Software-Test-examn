using System;

namespace swt_examen
{
    public class BeregnYdelser : IBeregnYdelser
    {
        public double AktuelRente { get; private set; }
        private IDisplay _display;
        private IRenteserver _renteserver;
        // Her mangler constructor
        public BeregnYdelser(IDisplay display,IRenteserver renteserver)
        {
            renteserver.RenteUpdateEvent += HandleRenteEvent;
            _display = display;
            _renteserver = renteserver;

        }
        // Her mangler en event handler

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