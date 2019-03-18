using DevHobby.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Tests 
{
    [TestClass]
    public class DostawcaTests
    {
        [TestMethod]
        public void WyslijEmailWitamy_PrawidlowaNazwaFirmy_Sukces() 
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "DevHobby";
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj DevHobby";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_PustaNazwaFirmy_Sukces() 
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = "";
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }

        [TestMethod]
        public void WyslijEmailWitamy_NullNazwaFirmy_Sukces() 
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            dostawca.NazwaFirmy = null;
            var wartoscOczekiwana = "Wiadomość wysłana: Witaj";

            //ACT (działaj)
            var wartoscAktualna = dostawca.WyslijEmailWitamy("Wiadomość testowa");

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana, wartoscAktualna);
        }
    }
}