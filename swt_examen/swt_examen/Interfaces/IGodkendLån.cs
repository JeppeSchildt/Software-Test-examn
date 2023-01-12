using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    public interface IGodkendLån
    {
        double MånedligPris { get; set; }
        double RådighedsBeløb { get; set; }
        double Størrelse { get; set; }
        int Varighed { get; set; }
        double Indtægt { get; set; }
        bool Godkendt { get; set; }
        bool GodkendCheck(); //Checks if loan can be approved
        void månedligYdelse(); //Calculates montly cost
        void PopulateRandom(); //Populates dummy values
        void UdskriveLåneDokument();
        void FrigivLån(int Kontonummer);


    }
}
