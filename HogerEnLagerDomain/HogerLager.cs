using System;
using System.Collections.Generic;

namespace HogerEnLagerDomain
{

    public class HogerLager
    {

        public DefaultClasses.Cards.Card spelerKaart { get; set; }
        public DefaultClasses.Cards.Card computerKaart { get; set; }

        private int ingezetteWaarde { get; set; }

        public Random random = new Random();
        public string resultaat { get; set }
        public List<DefaultClasses.Cards.Card> cards = DefaultClasses.Cards.CardBuilder.BuildCards();

        public HogerLager(int ingezetteWaarde)
        {
            this.ingezetteWaarde = ingezetteWaarde;
        }

        public int StartSpel() {

            genereerSpelerKaart();
            genereerComputerKaart();
            return bepaalWinnaar();

        }
        public void genereerSpelerKaart()
        {
            int randomSpelerKaart = random.Next(0, cards.Count);
            spelerKaart = cards[randomSpelerKaart];
            cards.RemoveAt(randomSpelerKaart);
        }

        public void genereerComputerKaart()
        {
            do
            {
                int randomComputerKaart = random.Next(0, cards.Count);
                computerKaart = cards[randomComputerKaart];
            } while (computerKaart.waardeHogerLager < 9);
        }

        public int bepaalWinnaar()
        {

            if (spelerKaart.waardeHogerLager > computerKaart.waardeHogerLager)
            {
                resultaat = "Je hebt gewonnen";
                return (ingezetteWaarde * 2);
               
            }
            else
            {
                resultaat = "Je hebt verloren";
                return (-ingezetteWaarde);
            }

        }
    }
}
