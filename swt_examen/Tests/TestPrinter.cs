using swt_examen.Classes;
using swt_examen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class TestPrinter
    {
        private IPrinter _uut;
        private StringWriter sw;
        [SetUp]
        public void Setup()
        {
            _uut = new Printer();
            sw = new StringWriter();
            Console.SetOut(sw);
        }
        [Test]
        public void PrintDocument_Test()
        {
            _uut.UdskriveLåneDokument(10000, 12, 200);

            Assert.That(sw.ToString(), Contains.Substring("Legal Document: Sign to accept loan of 10000, paid over 12 months, monthly payment: 200\n"));

        }
    }

}
