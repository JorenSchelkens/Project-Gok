using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultClasses.Cards
{
    public class CardBuilder
    {
        private static List<string> urls = UrlGenerator.GenerateUrls();

        public static List<Card> BuildCards()
        {
            List<Card> Cards = new List<Card>();

            for (int i = 0; i < 52; i++)
            {

                Card card = new Card();
                var randomGetal = new Random().Next(0, urls.Count);

                card.url = urls[randomGetal];
                card.urlAchterKant = "img/Kaarten/Back/back.png";

                //13

                string waarde = card.url.Substring(13, 2);

                switch (waarde)
                {
                    case "A.":
                        card.waardeBlackjack = 1;
                        card.waardeHogerLager = 14;
                        break;
                    case "2.":
                        card.waardeBlackjack = 2;
                        card.waardeHogerLager = 2;
                        break;
                    case "3.":
                        card.waardeBlackjack = 3;
                        card.waardeHogerLager = 3;
                        break;
                    case "4.":
                        card.waardeBlackjack = 4;
                        card.waardeHogerLager = 4;
                        break;
                    case "5.":
                        card.waardeBlackjack = 5;
                        card.waardeHogerLager = 5;
                        break;
                    case "6.":
                        card.waardeBlackjack = 6;
                        card.waardeHogerLager = 6;
                        break;
                    case "7.":
                        card.waardeBlackjack = 7;
                        card.waardeHogerLager = 7;
                        break;
                    case "8.":
                        card.waardeBlackjack = 8;
                        card.waardeHogerLager = 8;
                        break;
                    case "9.":
                        card.waardeBlackjack = 9;
                        card.waardeHogerLager = 9;
                        break;
                    case "10":
                        card.waardeBlackjack = 10;
                        card.waardeHogerLager = 10;
                        break;
                    case "J.":
                        card.waardeBlackjack = 10;
                        card.waardeHogerLager = 11;
                        break;
                    case "Q.":
                        card.waardeBlackjack = 10;
                        card.waardeHogerLager = 12;
                        break;
                    case "K.":
                        card.waardeBlackjack = 10;
                        card.waardeHogerLager = 13;
                        break;
                }

                Cards.Add(card);

            }

            return Cards;
        }
    }
}
