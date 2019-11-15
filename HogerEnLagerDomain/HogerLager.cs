using System;
using System.Collections.Generic;

namespace HogerLagerDomain
{

    public class HogerLager
    {

        public Random random = new Random();

        public List<DefaultClasses.Cards.Card> cards = DefaultClasses.Cards.CardBuilder.BuildCards();
        public DefaultClasses.Cards.Card spelerKaart { get; set; }
        public DefaultClasses.Cards.Card computerKaart { get; set; }

        private int ingezetteWaarde { get; set; }
        public string resultaat { get; set; }

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
            int randomComputerKaart = random.Next(0, cards.Count);
            computerKaart = cards[randomComputerKaart];
        }

        public int bepaalWinnaar()
        {

            if (spelerKaart.waardeHogerLager > computerKaart.waardeHogerLager)
            {
                resultaat = "Je hebt gewonnen";
                return ingezetteWaarde;
            }
            else
            {
                resultaat = "Je hebt verloren";
                return (-ingezetteWaarde);
            }

        }
    }
}
