using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    public interface IDisplay
    {
        void UpdateRent(double rent);
        void Print(string message);
        void VisLånGodkendt(double ydelse);
        void VisYdelseForStor(double ydelse);
    }
}
