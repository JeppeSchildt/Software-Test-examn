using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using swt_examen;


//test event

namespace Tests
{
    internal class TestBeregnYdelser
    {
        private IDisplay _display;
        private IRenteserver _renteServer;
        private IBeregnYdelser _uut;


        [SetUp]
        public void Setup()
        {
            _renteServer = Substitute.For<IRenteserver>();
            _display = Substitute.For<IDisplay>();
            _uut = new BeregnYdelser(_display,_renteServer);
        }

        [Test]
        //Checks if initial value of rent is correct
        public void DefaultValue_Test()
        {
            Assert.That(_uut.AktuelRente, Is.EqualTo(_renteServer.rente));
        }

        [Test]
        //Checks if event handler updates rent properly
        public void OnRentUpdate_Test()
        {

            _renteServer.RenteUpdateEvent += Raise.EventWith(this, new RenteEventArgs() { Rente = 0.1 });
            Assert.That(_uut.AktuelRente, Is.EqualTo(0.1));
        }

        //Using testcases from task description
        [TestCase(10000,0.015,60,253.93)] 
        [TestCase(50000,0.0025,120,482.80)]
        [TestCase(100000,0.005,120,1110.21)]
        public void CorrectMonthly_Test(double size, double rent, int months,double answer)
        {
            _renteServer.RenteUpdateEvent += Raise.EventWith(this, new RenteEventArgs() { Rente = rent });

            double value = _uut.BeregnYdelse(size, months);
            Assert.That(Math.Round(value,2), Is.EqualTo(answer));
        }

        [TestCase(0)]
        [TestCase(121)]
        public void OutOfBoundaryMonthly_Test(int months)
        {
            _renteServer.RenteUpdateEvent += Raise.EventWith(this, new RenteEventArgs() { Rente = 0.015 });
            
            //According to implementation, if months are without bounds, monthly payment is max size of 'double'
            Assert.That(_uut.BeregnYdelse(10000, months), Is.EqualTo(Double.MaxValue));

        }
        [TestCase(1)]
        [TestCase(120)]
        public void OnBoundaryMonthly_Test(int months)
        {
            _renteServer.RenteUpdateEvent += Raise.EventWith(this, new RenteEventArgs() { Rente = 0.015 });

            //According to implementation, if months are without bounds, monthly payment is max size of 'double'
            Assert.That(_uut.BeregnYdelse(10000, months), Is.LessThan(Double.MaxValue));

        }
        [Test]
        public void NoRentCalculation()
        {
            _renteServer.RenteUpdateEvent += Raise.EventWith(this, new RenteEventArgs() { Rente = 0 });
            Assert.That(_uut.BeregnYdelse(10000, 10), Is.EqualTo(10000 / 10));
        }
    }
}
