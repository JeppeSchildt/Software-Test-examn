using swt_examen.Classes;
using swt_examen.Interfaces;
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
        public bool Godkendt { get; set; } //Repræsenterer om lånet er godkendt
        private double Udgifter;
        public double RådighedsBeløb { get; set; }
        public double MånedligPris { get; set; }
        private IBeregnYdelser _beregnYdelser;
        private IPrinter _printer;
        private IDisplay _display;
        private IKontoServer _kontoServer;
        public GodkendLån(IBeregnYdelser beregnYdelser,IPrinter printer, IDisplay display, IKontoServer kontoServer,double size=0, int months=0, double income=0, double expen=0)
        {
            _beregnYdelser = beregnYdelser;
            _printer = printer;
            _display = display;
            _kontoServer = kontoServer;
            Godkendt = false;

            //Tilføj værdier for det givne lån
            if (size != 0 && months != 0 && income != 0)
            {
                Størrelse = size;
                Varighed = months;
                Indtægt = income;
                Udgifter = expen;
                RådighedsBeløb = income - expen;
            } else
            {
                PopulateRandom();
                Console.WriteLine("Populated loan approval using randomized values");
            }
      
        }
        public void PopulateRandom() { //Would get info from customer, populating w/ dummy values
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
            månedligYdelse();
            if (RådighedsBeløb*0.1 >= MånedligPris)
            {
                _display.VisLånGodkendt(MånedligPris);
                Godkendt = true;
                return true;
            }
            else
            {
                _display.VisYdelseForStor(MånedligPris);
                Godkendt = false;
                return false;
            }
        }
        public void UdskriveLåneDokument()
        {
            _printer.UdskriveLåneDokument(Størrelse, Varighed,MånedligPris);
        }
        public void FrigivLån(int Kontonummer)
        {
            if (Godkendt)
            {
                //Userinput abstracted away - just assume they want the loan
                _kontoServer.BogførBeløb(Størrelse, Kontonummer);
            }

        }
    }
}
