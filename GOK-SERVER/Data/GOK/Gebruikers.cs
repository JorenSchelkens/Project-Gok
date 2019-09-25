using System;

namespace GOK_SERVER.Data.GOK
{
    public partial class Gebruikers
    {
        public int Spelersnummer { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public int Saldo { get; set; }
        public DateTime DailyGiftDatum { get; set; }
        public int Admin { get; set; }
        public int Nieuwsbrief { get; set; }
        public int Notificaties { get; set; }
    }
}