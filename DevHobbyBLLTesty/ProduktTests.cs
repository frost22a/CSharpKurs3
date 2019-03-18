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
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko";

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
            var oczekiwana = "Witaj Biurko (1): Czerwone biurko";

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

            var oczekiwana = "Witaj Biurko (1): Czerwone biurko";

            //ACT (działaj)
            var aktualna = produkt.PowiedzWitaj();

            // Assert (potwierdz test)           
            Assert.AreEqual(oczekiwana, aktualna);
        }
    }
}