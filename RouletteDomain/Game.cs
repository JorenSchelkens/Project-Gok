using System;
using System.Collections.Generic;
using System.Linq;

namespace RouletteDomain
{
    public class Game
    {
        public List<int> muntenIngezet { get; set; }
        public List<MogelijkeUitkomst> opgegeveUitkomsten { get; set; } = new List<MogelijkeUitkomst>();
        public List<MogelijkeUitkomst> mogelijkeUitkomsten { get; set; }
        public MogelijkeUitkomst uitkomst { get; set; }
        // juiste gok maken 
        public Game(List<string> opgegeveTitles, List<int> muntenIngezet)
        {
            this.muntenIngezet = muntenIngezet;

            mogelijkeUitkomsten = MogelijkeUitkomstBuilder.Build();

            foreach(var titel in opgegeveTitles)
            {
                MogelijkeUitkomst temp = mogelijkeUitkomsten.Where(v => v.titel == titel).First();
                opgegeveUitkomsten.Add(temp);
            }
        }

        public int StartSpel()
        {
            var random = new Random();
            var randomGetal = random.Next(12, 49);

            uitkomst = mogelijkeUitkomsten[randomGetal];

            for (int i = 0; i < opgegeveUitkomsten.Count; i++)
            {
                Controleer(i);
            }
            return muntenIngezet.Sum();

        }

        public bool Controleer(int i)
        {
            if (opgegeveUitkomsten[i].nummerWaarde == uitkomst.nummerWaarde) {
                muntenIngezet[i] = muntenIngezet[i] * 36;
                return true;
            }
            if (opgegeveUitkomsten[i].isNul == true && uitkomst.isNul == true) {
                muntenIngezet[i] = muntenIngezet[i] * 36;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "rood" && opgegeveUitkomsten[i].isRood == uitkomst.isRood) {
                muntenIngezet[i] = muntenIngezet[i]*2;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "zwart" && opgegeveUitkomsten[i].isRood == uitkomst.isRood)
            {
                muntenIngezet[i] = muntenIngezet[i] * 2;
                return true;
            }
            if(opgegeveUitkomsten[i].titel=="even"&& opgegeveUitkomsten[i].even == uitkomst.even)
            {
                muntenIngezet[i] = muntenIngezet[i] * 2;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "oneven" && opgegeveUitkomsten[i].even == uitkomst.even)
            {
                muntenIngezet[i] = muntenIngezet[i] * 2;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "eersteTwaalf" && opgegeveUitkomsten[i].eersteTwaalf == uitkomst.eersteTwaalf) {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "tweedeTwaalf" && opgegeveUitkomsten[i].tweedeTwaalf == uitkomst.tweedeTwaalf)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "derdeTwaalf" && opgegeveUitkomsten[i].derdeTwaalf == uitkomst.derdeTwaalf)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "tweeTotEenEerste" && opgegeveUitkomsten[i].tweeToEenEerste == uitkomst.tweeToEenEerste)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "tweeTotEenTweede" && opgegeveUitkomsten[i].tweeToEenTweede == uitkomst.tweeToEenTweede)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "tweeTotEenDerde" && opgegeveUitkomsten[i].tweeToEenDerde == uitkomst.tweeToEenDerde)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "eenTotAchttien" && opgegeveUitkomsten[i].eenToAchttien == uitkomst.eenToAchttien)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            if (opgegeveUitkomsten[i].titel == "eenTotAchttien" && opgegeveUitkomsten[i].negentienTozesendertig == uitkomst.negentienTozesendertig)
            {
                muntenIngezet[i] = muntenIngezet[i] * 3;
                return true;
            }
            muntenIngezet[i] = 0;           
            return false;
        }
        
    }
}
