using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevHobby.BLL.Tests
{
    [TestClass()]
    public class ProduktTests
    {
        [TestMethod()]
        public void PowiedzWitajTest()
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.ProduktId = 1;
            produkt.NazwaProduktu = "Biurko";
            produkt.Opis = "Czerwone biurko";
            produkt.DostawcaProduktu.NazwaFirmy = "DevHobby";
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko Dostępny od : ";

            //ACT (działaj)
            var aktualna = produkt.PowiedzWitaj();

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_SparametryzowanyKonstruktorTest()  
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt(1,"Biurko", "Czerwone biurko");          
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko Dostępny od : ";

            //ACT (działaj)
            var aktualna = produkt.PowiedzWitaj();

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void PowiedzWitaj_InicjalizatorObiektuTest() 
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt
            {
                ProduktId = 1,
                NazwaProduktu = "Biurko",
                Opis = "Czerwone biurko"
            };

            var oczekiwana = "Witaj Biurko (1): Czerwone biurko Dostępny od : ";

            //ACT (działaj)
            var aktualna = produkt.PowiedzWitaj();

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void Produkt_NullTest() 
        {
            // Arrange (zaranżuj test)
            Produkt produkt = null;

            string oczekiwana = null;

            //ACT (działaj)
            var aktualna = produkt?.DostawcaProduktu?.NazwaFirmy;

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void Konwersja_CaliNaMetrTest() 
        {
            // Arrange (zaranżuj test)
            var oczekiwana = 194.35;

            //ACT (działaj)
            var aktualna = 5 * Produkt.CaliNaMetr;

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void MinimalnaCena_DomyslnaTest() 
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            var oczekiwana = 10.50m;

            //ACT (działaj)
            var aktualna = produkt.MinimalnaCena;

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void MinimalnaCena_KrzesloTest() 
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt(1, "Krzesło obrotowe", "opis");
            var oczekiwana = 120.99m;

            //ACT (działaj)
            var aktualna = produkt.MinimalnaCena;

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }

        [TestMethod()]
        public void NazwaProduktu_FormatTest() 
        {
            // Arrange (zaranżuj test)
            var produkt = new Produkt();
            produkt.NazwaProduktu = "  Krzesło obrotowe  ";
            var oczekiwana = "Krzesło obrotowe";

            //ACT (działaj)
            var aktualna = produkt.NazwaProduktu;

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}