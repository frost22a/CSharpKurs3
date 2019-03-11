namespace DevHobby.Common
{
    public class EmailSevice
    {

        /// <summary>
        /// Wysyła wiadomosc email.
        /// </summary>
        /// <param name="temat">Temat wiadomosci.</param>
        /// <param name="wiadomosc">Widomosc tekstowa</param>
        /// <param name="odbiorca">Adres email odbiorcy wiadomosci</param>
        /// <returns></returns>
        public string WyslijWiadomosc(string temat, string wiadomosc, string odbiorca)
        {
            // Kod, aby wysłać wiadomosc email


            var potwierdzenie = "Wiadomość wysłana: " + temat;
            var logowanieService = new LogowanieService();
            logowanieService.Logowanie(potwierdzenie);

            return potwierdzenie;
        }
    }
}
