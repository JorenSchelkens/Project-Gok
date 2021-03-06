﻿using System;
using System.Collections.Generic;

namespace RouletteDomain
{
    public class MogelijkeUitkomstBuilder
    {
        public static List<MogelijkeUitkomst> Build()
        {

            List<MogelijkeUitkomst> list = new List<MogelijkeUitkomst>();
            List<int> tteEerste = new List<int>();
            List<int> tteTweede = new List<int>();
            List<int> tteDerde = new List<int>();

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

            MogelijkeUitkomst eenTotAchttien = new MogelijkeUitkomst("eenTotAchttien");
            eenTotAchttien.eenToAchttien = true;
            eenTotAchttien.negentienTozesendertig = false;
            eenTotAchttien.eersteTwaalf = true;
            eenTotAchttien.derdeTwaalf = false;
            tweeTotEenDerde.isNul = false;

            MogelijkeUitkomst negentienTozesendertig = new MogelijkeUitkomst("eenTotAchttien");
            eenTotAchttien.eenToAchttien = false;
            eenTotAchttien.negentienTozesendertig = true;
            negentienTozesendertig.eersteTwaalf = true;
            negentienTozesendertig.derdeTwaalf = true;
            tweeTotEenDerde.isNul = false;

            //getallen invoegen
            for (int i = 0; i < 37; i++)
            {
                string letter="";

                if (i == 0) 
                {
                    letter = "";
                }
                else if (i == 1 || i == 3 || i == 5 || i == 7 || i == 9 || i == 12 || i == 14 || i == 16 || i == 18 || i == 19 || i == 21 || i == 23 || i == 25 || i == 27 || i == 30 || i == 32 || i == 34 || i == 36) 
                {
                    letter = "R";
                }
                else if (i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 11 || i == 13 || i == 15 || i == 17 || i == 20 || i == 22 || i == 24 || i == 26 || i == 28 || i == 29 || i == 31 || i == 33 || i == 35)
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
            return list;
        }
    }
}