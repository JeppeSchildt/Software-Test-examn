using NSubstitute;
using swt_examen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class TestRenteserver
    {
        private IRenteserver _uut;
        private IBeregnYdelser _beregnYdelse;
        private IDisplay _display;
        [SetUp]
        public void Setup()
        {
            _beregnYdelse = Substitute.For<IBeregnYdelser>();
            _display = Substitute.For<IDisplay>();  
            _uut = new Renteserver(); 
        }
        [Test]
        public void StartRente_Test()
        {
            Assert.That(_uut.rente, Is.EqualTo(0.1));
        }
    }
}
