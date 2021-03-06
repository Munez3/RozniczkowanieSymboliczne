﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Potega : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        public Elem_Potega(List<Token> _tokeny)
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
            int actualTokenIndex = 0, tokenyLength = Tokeny.Count;
            List<Token> dziecko = new List<Token>();
            int ileNawiasow = 0;
            while (Tokeny[actualTokenIndex].Nazwa != TokenName.opPotega || ileNawiasow != 0)
            {
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) ileNawiasow--;
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) ileNawiasow++;
                dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex++;
            }
            actualTokenIndex++;
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
            dziecko = new List<Token>();
            while (actualTokenIndex < tokenyLength)
            {
                dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex++;
            }
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
        }

        /// <summary>
        /// Wylicza pochodną
        /// </summary>
        public void WyliczPochodna(string identPoKtorymPochodniujemy)
        {
            foreach (var dziecko in Dzieci)
                dziecko.WyliczPochodna(identPoKtorymPochodniujemy);

            Pochodna += "(" + Wyrazenie + ")*(" + Dzieci[1].Pochodna + "*log(e," + Dzieci[0].Wyrazenie + ")+" + Dzieci[1].Wyrazenie + "*(" + Dzieci[0].Pochodna + "/" + Dzieci[0].Wyrazenie + "))";
        }

        /// <summary>
        /// Generuje listę tokenów na podstawie elementów
        /// </summary>
        /// <param name="list">Lista dzieci</param>
        public void GenerujTokenyNaPodstawieElementów()
        {
            Tokeny = new List<Token>();
            Tokeny.AddRange(Dzieci[0].Tokeny);
            Tokeny.Add(new Token(TokenName.opPotega, "^", 0, 0));
            Tokeny.AddRange(Dzieci[1].Tokeny);
        }
    }
}
