using System;
using System.Data.SqlClient;

namespace DefaultClasses
{
    public class DBConnection
    {
        protected SqlConnectionStringBuilder DataBaseInfo { get; }
        public string Error { get; set; }

        public DBConnection()
        {
            DataBaseInfo = new SqlConnectionStringBuilder();

            DataBaseInfo.DataSource = "goksite.database.windows.net";
            DataBaseInfo.UserID = "GOKSERVER";
            DataBaseInfo.Password = "BAZandpoort1920";
            DataBaseInfo.InitialCatalog = "GOK";
        }

        public void RegistreerGebruiker(
            string naam,
            string email,
            string wachtwoord,
            string gebruikersNaam,
            int nieuwsbrief,
            int notificaties)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "INSERT INTO Gebruikers(Gebruikersnaam, Naam, Email, Wachtwoord, Saldo, DailyGiftDatum, Admin, Nieuwsbrief, Notificaties) " +
                        "VALUES('" + gebruikersNaam + "', '" + naam + "', '" + email + "','" + Encryption.EncryptString(wachtwoord) + "', 100, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', 0, " + nieuwsbrief + ", " + notificaties + ");";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        //Logger
                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }
        }

        public Gebruiker LogGebruikerIn(string gebruikersNaam, string wachtwoord)
        {
            Gebruiker gebruiker = new Gebruiker();
            var temp = Encryption.EncryptString(wachtwoord);

            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "SELECT Spelersnummer, Gebruikersnaam, Naam, Email, Wachtwoord, Saldo, DailyGiftDatum, Admin, Nieuwsbrief, Notificaties FROM Gebruikers WHERE Gebruikersnaam = '" + gebruikersNaam + "' AND Wachtwoord = '" + Encryption.EncryptString(wachtwoord) + "';";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gebruiker.Spelersnummer = reader.GetInt32(0);
                                gebruiker.Gebruikersnaam = reader.GetString(1);
                                gebruiker.Naam = reader.GetString(2);
                                gebruiker.Email = reader.GetString(3);
                                gebruiker.Wachtwoord = reader.GetString(4);
                                gebruiker.Saldo = reader.GetInt32(5);
                                gebruiker.DailyGiftDatum = reader.GetDateTime(6);
                                gebruiker.Admin = reader.GetInt32(7);
                                gebruiker.Nieuwsbrief = reader.GetInt32(8);
                                gebruiker.Notificaties = reader.GetInt32(9);
                            }
                        }
                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
                gebruiker = null;
            }

            return gebruiker;
        }

        public void UpdateGebruiker(Gebruiker gebruiker)
        {

            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "UPDATE Gebruikers SET Gebruikersnaam ='" + gebruiker.Gebruikersnaam + "', Naam ='" + gebruiker.Naam + "', Email ='" + gebruiker.Email + "', Wachtwoord ='" + Encryption.EncryptString(gebruiker.Wachtwoord) +"', Saldo =" + gebruiker.Saldo + ", DailyGiftDatum ='" + gebruiker.DailyGiftDatum + "', Admin = " + gebruiker.Admin + ", Nieuwsbrief = " + gebruiker.Nieuwsbrief + ", Notificaties = " + gebruiker.Notificaties + "WHERE Spelersnummer = " + gebruiker.Spelersnummer + ";";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        //Logger
                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }

        }
    }
}
