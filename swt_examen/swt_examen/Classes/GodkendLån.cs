using swt_examen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    public class GodkendLån : IGodkendLån
    { //En instans per lån godkendelses request
        private double Størrelse;
        private int Varighed; //I måneder
        private double Indtægt;
        private double Udgifter;
        private double RådighedsBeløb;
        private double MånedligPris;
        private BeregnYdelser _beregnYdelser;
        private Printer _printer;

        public GodkendLån(BeregnYdelser beregnYdelser,Printer printer)
        {
            _beregnYdelser = beregnYdelser;
            _printer = printer;
        }
        public void getInfo() { //Would get info from customer, populating w/ dummy values
            Størrelse = 20000;
            Varighed = 36; //3 år
            Indtægt = 21000;
            Udgifter = 12000;
            RådighedsBeløb = Indtægt - Udgifter;
        }
        public void månedligYdelse()
        {
            MånedligPris=_beregnYdelser.BeregnYdelse(Størrelse,Varighed);
        }
        public bool GodkendCheck()
        {
            return (RådighedsBeløb * 0.1 >= MånedligPris);
        }
        public void UdskriveLåneDokument()
        {
            _printer.UdskriveLåneDokument(Størrelse, Varighed,MånedligPris);
        }
    }
}
