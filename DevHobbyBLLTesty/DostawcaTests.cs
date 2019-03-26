using DevHobby.BLL;
using DevHobby.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod()]
        public void ZlozZamowienieTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 15");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15);

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienie3parametryTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 15\r\nData dostawy: 2019-04-22");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2019, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)));

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        public void ZlozZamowienie4parametryTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Zamowienie z DevHobby.pl\r\nProdukt: Informatyka - 1\r\nIlość: 15\r\nData dostawy: 2019-04-22\r\nInstrukcje: testowe instrukcje");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, new DateTimeOffset(2019, 4, 22, 0, 0, 0, new TimeSpan(8, 0, 0)), "testowe instrukcje");

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ZlozZamowienie_NullProdukt_ExcepitonTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(null, 15);

            // Assert (potwierdz test)
            // oczekiwany wyjatek
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZlozZamowienie_Ilosc_ExcepitonTest()
        {
            // Arrange (zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 0);

            // Assert (potwierdz test)
            // oczekiwany wyjatek
        }

        [TestMethod()]
        public void ZlozZamowienie_DolaczAdresTest()
        {
            // Arrange(zaranżuj test)
            var dostawca = new Dostawca();
            var produkt = new Produkt(1, "Biurko", "opis");
            var wartoscOczekiwana = new WynikOperacji(true, "Tekst zamówienia Dołączamy adres");

            //ACT (działaj)
            var wartoscAktualna = dostawca.ZlozZamowienie(produkt, 15, Dostawca.DolaczAdres.Tak, Dostawca.WyslijKopie.Nie);

            // Assert (potwierdz test)
            Assert.AreEqual(wartoscOczekiwana.Sukces, wartoscAktualna.Sukces);
            Assert.AreEqual(wartoscOczekiwana.Wiadomosc, wartoscAktualna.Wiadomosc);
        }
    }
}