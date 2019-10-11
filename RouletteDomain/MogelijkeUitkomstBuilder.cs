using System;
using System.Collections.Generic;

namespace RouletteDomain
{
    public class MogelijkeUitkomstBuilder
    {
        private List<MogelijkeUitkomst> list { get; set; }
        private List<int> tteEerste { get; set; }
        private List<int> tteTweede { get; set; }
        private List<int> tteDerde { get; set; }

        public static List<MogelijkeUitkomst> Build()
        {
            MogelijkeUitkomst zwart = new MogelijkeUitkomst("zwart");
            zwart.isRood = false;
            zwart.isNul = false;

            MogelijkeUitkomst rood = new MogelijkeUitkomst("rood");
            rood.isRood = true;
            rood.isNul = false;

            list.Add(rood);
            list.Add(zwart);

            MogelijkeUitkomst even = new MogelijkeUitkomst("even");
            even.isRood = true;
            even.even = true;
            even.isNul = false;

            MogelijkeUitkomst oneven = new MogelijkeUitkomst("oneven");
            oneven.isRood = false;
            oneven.even = false;
            oneven.isNul = false;

            list.Add(even);
            list.Add(oneven);

            MogelijkeUitkomst eersteTwaalf = new MogelijkeUitkomst("eersteTwaalf");
            eersteTwaalf.eersteTwaalf = true;
            eersteTwaalf.tweedeTwaalf = false;
            eersteTwaalf.derdeTwaalf = false;
            eersteTwaalf.eenToAchttien = true;
            eersteTwaalf.negentienTozesendertig = false;
            eersteTwaalf.isNul = false;

            MogelijkeUitkomst tweedeTwaalf = new MogelijkeUitkomst("tweedeTwaalf");
            tweedeTwaalf.eersteTwaalf = false;
            tweedeTwaalf.tweedeTwaalf = true;
            tweedeTwaalf.derdeTwaalf = false;
            tweedeTwaalf.isNul = false;

            MogelijkeUitkomst derdeTwaalf = new MogelijkeUitkomst("derdeTwaalf");
            derdeTwaalf.eersteTwaalf = false;
            derdeTwaalf.tweedeTwaalf = false;
            derdeTwaalf.derdeTwaalf = true;
            derdeTwaalf.eenToAchttien = false;
            derdeTwaalf.negentienTozesendertig = true;
            derdeTwaalf.isNul = false;

            list.Add(eersteTwaalf);
            list.Add(tweedeTwaalf);
            list.Add(derdeTwaalf);

            MogelijkeUitkomst tweeTotEenEerste = new MogelijkeUitkomst("tweeTotEenEerste");
            tweeTotEenEerste.tweeToEenEerste = true;
            tweeTotEenEerste.tweeToEenTweede = false;
            tweeTotEenEerste.tweeToEenDerde = false;
            tweeTotEenEerste.isNul = false;

            MogelijkeUitkomst tweeTotEenTweede = new MogelijkeUitkomst("tweeTotEenTweede");
            tweeTotEenTweede.tweeToEenEerste = false;
            tweeTotEenTweede.tweeToEenTweede = true;
            tweeTotEenTweede.tweeToEenDerde = false;
            tweeTotEenTweede.isNul = false;

            MogelijkeUitkomst tweeTotEenDerde = new MogelijkeUitkomst("tweeTotEenDerde");
            tweeTotEenDerde.tweeToEenEerste = false;
            tweeTotEenDerde.tweeToEenTweede = true;
            tweeTotEenDerde.tweeToEenDerde = false;
            tweeTotEenDerde.isNul = false;

            list.Add(tweeTotEenEerste);
            list.Add(tweeTotEenTweede);
            list.Add(tweeTotEenDerde);

            //getallen invoegen
            for (int i = 0; i < 37; i++)
            {
                string letter="";

                if (i == 0) {
                    letter = "";
                }
                else if (i % 2 == 0) {
                    letter = "R";
                }
                else if (i % 2 == 1)
                {
                    letter = "Z";
                }

                string uitgekomenWaarde = letter + i;

                MogelijkeUitkomst temp = new MogelijkeUitkomst(uitgekomenWaarde);
                temp.nummerWaarde = i;

                if(letter == "Z")
                {
                    temp.isRood = false;
                }
                else if(letter == "R")
                {
                    temp.isRood = true;
                }
                else
                {
                    temp.isNul = true;
                }

                if(i % 2 == 0)
                {
                    temp.even = true;
                } 
                else if(i % 2 == 1)
                {
                    temp.even = false;
                }

                if(i > 0 && i <= 12)
                {
                    temp.eersteTwaalf = true;
                    temp.tweedeTwaalf = false;
                    temp.derdeTwaalf = false;
                }
                else if(i > 12 && i <= 24)
                {
                    temp.eersteTwaalf = false;
                    temp.tweedeTwaalf = true;
                    temp.derdeTwaalf = false;
                }
                else if(i > 24 && i <= 36)
                {
                    temp.eersteTwaalf = false;
                    temp.tweedeTwaalf = false;
                    temp.derdeTwaalf = true;
                }

                if(i > 0 && i >= 18)
                {
                    temp.eenToAchttien = true;
                    temp.negentienTozesendertig = false;
                } 
                else if(i > 18 && i <= 36)
                {
                    temp.eenToAchttien = false;
                    temp.negentienTozesendertig = true;
                }

                for (int j = 1; j < 35; j+= 3)
                {
                    tteEerste.Add(j);
                }

                for (int k = 2; k < 36; k+= 3)
                {
                    tteTweede.Add(k);
                }

                for (int l = 3; l < 37; l+= 3)
                {
                    tteDerde.Add(l);
                }

                if (tteEerste.Contains(i))
                {
                    temp.tweeToEenEerste = true;
                    temp.tweeToEenTweede = false;
                    temp.tweeToEenDerde = false;
                }
                else if (tteTweede.Contains(i))
                {
                    temp.tweeToEenEerste = false;
                    temp.tweeToEenTweede = true;
                    temp.tweeToEenDerde = false;
                }
                else if (tteDerde.Contains(i))
                {
                    temp.tweeToEenEerste = false;
                    temp.tweeToEenTweede = false;
                    temp.tweeToEenDerde = true;
                }

                list.Add(temp);

            }
            return this.list;
        }
    }
}