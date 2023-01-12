using swt_examen.Interfaces;
using swt_examen.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    //Did not find it neccessary to test this class, as the implementation of it is not neccessary
    //to solve the tasks given. 
    internal class TestKontoServer
    {
        private IKontoServer _uut;   
        [SetUp]
        public void Setup()
        {
            _uut = new KontoServer();
        }
        [Test]
        public void BogførBeløb()
        {
            Assert.That(_uut.BogførBeløb(default,default), Is.True);
        }
    }
}
