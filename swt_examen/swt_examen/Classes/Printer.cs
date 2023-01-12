using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen.Classes
{
    //Printer is not defined to do anything other than to 'print' a single document
    //This 'printing' will be done using the console.writeout, just like display does it
    //as it's just proof of concept
    public class Printer : Interfaces.IPrinter
    {
        public void UdskriveLåneDokument(double beløb, int varighed, double ydelse)
        {
            Console.WriteLine("Legal Document: Sign to accept loan of " +
                ""+beløb+", paid over "+varighed+" months, " +
                "monthly payment: "+ydelse+"\n");
        }
    }
}
