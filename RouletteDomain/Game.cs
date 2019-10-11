using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteDomain
{
    public class Game
    {
        public int muntenIngezet { get; set; }
        public MogelijkeUitkomst opgegeveUitkomst { get; set; }
        public List<MogelijkeUitkomst> mogelijkeUitkomsten { get; set; }
        public MogelijkeUitkomst uitkomst { get; set; }
        // juiste gok maken 
        public Game(string opgegeveTitel, int muntenIngezet)
        {
            this.muntenIngezet = muntenIngezet;

            mogelijkeUitkomsten = MogelijkeUitkomstBuilder.Build();
            opgegeveUitkomst = mogelijkeUitkomsten.Where(v => v.titel == opgegeveTitel).First();
            //mogelijkuitkomsten genereren
            //op basis van titel naar opgegeveuitkomst zoeken
        }
        public int controleerKleur()
        {
            return 0;
        }
    }
}
