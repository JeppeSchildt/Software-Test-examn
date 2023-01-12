using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swt_examen
{
    public class Display : IDisplay
    {
        public Display() { }
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public void UpdateRent(double rent)
        {
            Console.WriteLine("Rent is updated to: "+rent);
        }
        public void VisYdelseForStor(double ydelse)
        {
            Console.WriteLine("Loan Denied, monthly cost too large, at: " +ydelse);
        }
        public void VisLånGodkendt(double ydelse)
        {
            Console.WriteLine("Loan Approved at monthly cost: "+ydelse);
        }
    }
}
