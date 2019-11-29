using DefaultClasses.DataBase;
using System;
using System.Collections.Generic;
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

                    string sqlCode = "UPDATE Gebruikers SET Gebruikersnaam ='" + gebruiker.Gebruikersnaam + "', Naam ='" + gebruiker.Naam + "', Email ='" + gebruiker.Email + "', Saldo =" + gebruiker.Saldo + ", DailyGiftDatum ='" + gebruiker.DailyGiftDatum.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', Admin = " + gebruiker.Admin + ", Nieuwsbrief = " + gebruiker.Nieuwsbrief + ", Notificaties = " + gebruiker.Notificaties + "WHERE Spelersnummer = " + gebruiker.Spelersnummer + ";";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }

        }
        public void UpdateGebruikerWachtwoord(Gebruiker gebruiker)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "UPDATE Gebruikers SET Wachtwoord ='" + Encryption.EncryptString(gebruiker.Wachtwoord) + "' WHERE Spelersnummer = " + gebruiker.Spelersnummer + ";";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }

        }
        public void RemoveGebruiker(string email)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();
                    string sqlCode = "DELETE FROM Gebruikers WHERE Email = '" + email + "'";
                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }

        }
        public List<Gebruiker> GetAllGebruikers()
        {
            List<Gebruiker> gebruikers = new List<Gebruiker>();

            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();
                    string sqlCode = "SELECT Spelersnummer, Gebruikersnaam, Naam, Email, Wachtwoord, Saldo, DailyGiftDatum, Admin, Nieuwsbrief, Notificaties FROM Gebruikers";
                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Gebruiker tempGebruiker = new Gebruiker();

                                tempGebruiker.Spelersnummer = reader.GetInt32(0);
                                tempGebruiker.Gebruikersnaam = reader.GetString(1);
                                tempGebruiker.Naam = reader.GetString(2);
                                tempGebruiker.Email = reader.GetString(3);
                                tempGebruiker.Wachtwoord = reader.GetString(4);
                                tempGebruiker.Saldo = reader.GetInt32(5);
                                tempGebruiker.DailyGiftDatum = reader.GetDateTime(6);
                                tempGebruiker.Admin = reader.GetInt32(7);
                                tempGebruiker.Nieuwsbrief = reader.GetInt32(8);
                                tempGebruiker.Notificaties = reader.GetInt32(9);

                                gebruikers.Add(tempGebruiker);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Error = e.ToString();
                gebruikers = null;
            }

            return gebruikers;
        }
        public void AddGiftCard(
            string invulcode,
            int usesLeft,
            int kortingProcent,
            int teOntvangenSaldo)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();
                    string sqlCode = "INSERT INTO GiftCards(InvulCode, UsesLeft, KortingProcent, TeOntvangenSaldo) VALUES('" + invulcode + "', " + usesLeft + ", " + kortingProcent + ", " + teOntvangenSaldo + ");";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }
        }

        public GiftCard GetGiftCard(string giftcardCode)
        {
            GiftCard giftCard = new GiftCard();
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "SELECT Nummer, InvulCode, UsesLeft, KortingProcent, TeOntvangenSaldo FROM GiftCards WHERE InvulCode = '" + giftcardCode + "';";
                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                giftCard.Nummer = reader.GetInt32(0);
                                giftCard.InvulCode = reader.GetString(1);
                                giftCard.UsesLeft = reader.GetInt32(2);
                                giftCard.KortingProcent = reader.GetInt32(3);
                                giftCard.TeOntvangenSaldo = reader.GetInt32(4);
                            }
                        }
                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
                giftCard = null;
            }

            return giftCard;
        }
        public void UpdateGiftcard(GiftCard giftCard)
        {
            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();

                    string sqlCode = "UPDATE GiftCards SET UsesLeft = " + (giftCard.UsesLeft - 1) + " WHERE Nummer = " + giftCard.Nummer + ";";

                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                    }

                    connection.Close();
                }

            }
            catch (SqlException e)
            {
                Error = e.ToString();
            }

        }

        public List<GiftCard> GetAllGiftCards()
        {
            List<GiftCard> giftCards = new List<GiftCard>();

            try
            {
                using (var connection = new SqlConnection(DataBaseInfo.ConnectionString))
                {
                    connection.Open();
                    string sqlCode = "SELECT Nummer, InvulCode, UsesLeft, KortingProcent, TeOntvangenSaldo FROM GiftCards";
                    using (var command = new SqlCommand(sqlCode, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                GiftCard tempGiftCard = new GiftCard();

                                tempGiftCard.Nummer = reader.GetInt32(0);
                                tempGiftCard.InvulCode = reader.GetString(1);
                                tempGiftCard.UsesLeft = reader.GetInt32(2);
                                tempGiftCard.KortingProcent = reader.GetInt32(3);
                                tempGiftCard.TeOntvangenSaldo = reader.GetInt32(4);

                                giftCards.Add(tempGiftCard);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Error = e.ToString();
                giftCards = null;
            }

            return giftCards;
        }

    }
}
