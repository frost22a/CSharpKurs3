using DevHobby.Common;
using System;

namespace DevHobby.BLL
{
    /// <summary>
    /// Zarzadza dostawcami od których kupujemy nasze produkty.
    /// </summary>
    public class Dostawca
    {
        #region Pola i Własciwosci
        public int DostawcaId { get; set; }
        public string NazwaFirmy { get; set; }
        public string Email { get; set; }
        #endregion

        #region Metody
        /// <summary>
        /// Wysyla wiadomosc email, aby powitac nowego dostawce.
        /// </summary>
        /// <param name="wiadomosc"></param>
        /// <returns></returns>
        public string WyslijEmailWitamy(string wiadomosc)
        {
            var emailService = new EmailSevice();
            var temat = ("Witaj " + this.NazwaFirmy).Trim();
            var potwierdzenie = emailService.WyslijWiadomosc(temat, wiadomosc, this.Email);

            return potwierdzenie;
        }

        /// <summary>
        /// Wysyła zamówienie na produkt do dostawcy
        /// </summary>
        /// <param name="produkt">Produkt do zamówienia.</param>
        /// <param name="ilosc">Ilość produktu do zamówienia.</param>
        /// <returns></returns>
        public WynikOperacji ZlozZamowienie(Produkt produkt, int ilosc)
        {
            if (produkt == null)
                throw new ArgumentNullException(nameof(produkt));
            if (ilosc <= 0)
                throw new ArgumentOutOfRangeException(nameof(ilosc));

            var sukces = false;

            var tekstZamowienia = "Zamowienie z DevHobby.pl" + Environment.NewLine +
                                  "Produkt: " + produkt.KodProduktu + Environment.NewLine +
                                  "Ilość: " + ilosc;

            var emailService = new EmailSevice();
            var potwierdzenie = emailService.WyslijWiadomosc("Nowe zamówienie", tekstZamowienia, this.Email);

            if (potwierdzenie.StartsWith("Wiadomość wysłana: "))
                sukces = true;

            var wynikOperacji = new WynikOperacji(sukces, tekstZamowienia);

            return wynikOperacji;
        }
        #endregion
    }
}