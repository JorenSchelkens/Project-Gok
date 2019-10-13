using System;

namespace DefaultClasses
{
    public class Gebruiker
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

        public void Update(int spelersnummer, string gebruikersnaam, string naam, string email, string wachtwoord, int saldo, DateTime dailyGiftDatum, int admin, int nieuwsbrief, int notificaties)
        {
            Spelersnummer = spelersnummer;
            Gebruikersnaam = gebruikersnaam;
            Naam = naam;
            Email = email;
            Wachtwoord = wachtwoord;
            Saldo = saldo;
            DailyGiftDatum = dailyGiftDatum;
            Admin = admin;
            Nieuwsbrief = nieuwsbrief;
            Notificaties = notificaties;
        }
    }
}