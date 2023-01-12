
using swt_examen;
using swt_examen.Interfaces;
namespace Tests
{
    public class TestDisplay
    {
        private IDisplay _uut;
        private StringWriter sw;

        [SetUp]
        public void Setup()
        {
            _uut = new Display();
            sw = new StringWriter();
            Console.SetOut(sw);
        }

        [Test]
        public void VisYdelseForStor_Print()
        {
            _uut.VisYdelseForStor(200);
            Assert.That(sw.ToString(), Contains.Substring("Loan Denied, monthly cost too large, at: 200"));
        }
        [Test]
        public void VisLånGodkendtPrint_Test ()
        {
            _uut.VisLånGodkendt(200);
            Assert.That(sw.ToString(), Contains.Substring("Loan Approved at monthly cost: 200"));

        }
        [Test]
        public void GenericPrint_Test()
        {
            _uut.Print("String to be printed");
            Assert.That(sw.ToString(), Contains.Substring("String to be printed"));
        }
    }
}