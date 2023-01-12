using NSubstitute;
using swt_examen;
using swt_examen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class TestGodkendLån
    {
        private IGodkendLån _uut;
        private IDisplay _display;
        private IKontoServer _kontoServer;
        private IPrinter _printer;
        private IBeregnYdelser _beregnYdelser;
        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _kontoServer = Substitute.For<IKontoServer>();
            _printer = Substitute.For<IPrinter>();
            _beregnYdelser = Substitute.For<IBeregnYdelser>();
            _uut = new GodkendLån(_beregnYdelser,_printer,_display,_kontoServer);
        }


        //Dokumentationen specificerer at den månedelige ydelse maks må være 10%. Laver derved BVA omkring dette punkt

        //Månedelig pris, rådighedsbeløb, burde accepteres:
        //9%, burde godkendes
        [TestCase(900,10000,true)]
        //10%, burde godkendes
        [TestCase(1000,10000,true)]
        //11%, for dyr månedlig ydelse, burde ikke godkendes
        [TestCase(1100,10000,false)]
        public void BoundaryApproval(int rente,int rådighed, Boolean accept) {

            _beregnYdelser.BeregnYdelse(default,default).ReturnsForAnyArgs(rente);
            _uut.MånedligPris = rente;
            _uut.RådighedsBeløb = rådighed;
            Assert.That(_uut.GodkendCheck(), Is.EqualTo(accept));
        }

        [Test]
        public void LåneDokument() {
            _uut.UdskriveLåneDokument();
            _printer.ReceivedWithAnyArgs().UdskriveLåneDokument(default,default,default);
        }
        [Test]
        public void FrigivLån()
        {
            _uut.Godkendt = true;
            _uut.FrigivLån(default);
            _kontoServer.ReceivedWithAnyArgs().BogførBeløb(default, default);

        }
    }
}
