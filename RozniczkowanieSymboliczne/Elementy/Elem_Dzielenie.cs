﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Dzielenie : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        private List<string> operatory = new List<string>();

        public Elem_Dzielenie(List<Token> _tokeny)
        {
            Tokeny = _tokeny;
            Wyrazenie = GeneratorKodu.stworzStringZTokenów(Tokeny);
            rozbijNaDzieci();
        }

        /// <summary>
        /// Tworzy listę dzieci
        /// </summary>
        public void rozbijNaDzieci()
        {
            Dzieci = new List<Element>();
            int actualTokenIndex = Tokeny.Count - 1;
            List<Token> dziecko = new List<Token>();
            int ileNawiasow = 0;
            while (Tokeny[actualTokenIndex].Nazwa != TokenName.opDzielenie || ileNawiasow != 0)
            {
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) ileNawiasow--;
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) ileNawiasow++;
                dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex--;
            }
            actualTokenIndex--;
            dziecko.Reverse();
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
            dziecko = new List<Token>();
            while (actualTokenIndex >= 0)
            {
                dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex--;
            }
            dziecko.Reverse();
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
            Dzieci.Reverse();
        }

        /// <summary>
        /// Wylicza pochodną
        /// </summary>
        public void WyliczPochodna(string identPoKtorymPochodniujemy)
        {
            foreach (var dziecko in Dzieci)
               dziecko.WyliczPochodna(identPoKtorymPochodniujemy);

            Pochodna += "(" + Dzieci[0].Wyrazenie + "*" + Dzieci[1].Pochodna + "-" + Dzieci[0].Pochodna + "*" + Dzieci[1].Wyrazenie +")/(" +Dzieci[0].Wyrazenie+"*"+Dzieci[1].Wyrazenie+ ")";
                //x*2/4*x | x*2 | (x*0+1*2) / 4 | (x*2)*0 - (x*0+1*2)*4)/(x*2)*4 |

            //Dzieci[0].WyliczPochodna(identPoKtorymPochodniujemy);
            //Pochodna += "cos(";
            //if (Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Dzieci[0].Wyrazenie;
            //else Pochodna += Dzieci[0].Wyrazenie;
            //Pochodna += ")*";
            //if (Dzieci[0].GetType() == typeof(Elem_Podstawowy) || Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Pochodna;
            //else Pochodna += "(" + Dzieci[0].Pochodna + ")";
        }
    }
}
