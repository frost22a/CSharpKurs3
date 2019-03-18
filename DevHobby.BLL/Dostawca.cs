using DevHobby.Common;

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
    }
}