using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Cotangens : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        public Elem_Cotangens(List<Token> _tokeny)
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
            List<Token> dziecko = new List<Token>();
            int tokenyLength = Tokeny.Count;
            for (int i = 2; i < tokenyLength - 1; i++)
                dziecko.Add(Tokeny[i]);
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
        }

        /// <summary>
        /// Wylicza pochodną
        /// </summary>
        public void WyliczPochodna(string identPoKtorymPochodniujemy)
        {
            Dzieci[0].WyliczPochodna(identPoKtorymPochodniujemy);
            Pochodna += "(-(1+ctg(";
            if (Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Dzieci[0].Wyrazenie;
            else Pochodna += Dzieci[0].Wyrazenie;
            Pochodna += ")^2))*";
            if (Dzieci[0].GetType() == typeof(Elem_Podstawowy) || Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Pochodna;
            else Pochodna += "(" + Dzieci[0].Pochodna + ")";
        }

        /// <summary>
        /// Generuje listę tokenów na podstawie elementów
        /// </summary>
        /// <param name="list">Lista dzieci</param>
        public void GenerujTokenyNaPodstawieElementów()
        {
            Tokeny = new List<Token>();
            Tokeny.Add(new Token(TokenName.ctgFun, "ctg", 0, 0));
            Tokeny.Add(new Token(TokenName.Lnawias, "(", 0, 0));
            Tokeny.AddRange(Dzieci[0].Tokeny);
            Tokeny.Add(new Token(TokenName.Pnawias, ")", 0, 0));
        }
    }
}
