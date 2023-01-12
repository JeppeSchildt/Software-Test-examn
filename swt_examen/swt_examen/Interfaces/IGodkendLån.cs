using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    internal interface IGodkendLån
    {
        bool GodkendCheck(); //Checks if loan can be approved
        void månedligYdelse(); //Calculates montly cost
        void getInfo(); //Populates dummy values
    }
}
