using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Cosinus : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        public Elem_Cosinus(List<Token> _tokeny)
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
            Pochodna += "-sin(";
            if (Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Dzieci[0].Wyrazenie;
            else Pochodna += Dzieci[0].Wyrazenie;
            Pochodna += ")*";
            if (Dzieci[0].GetType() == typeof(Elem_Podstawowy) || Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Pochodna;
            else Pochodna += "(" + Dzieci[0].Pochodna + ")";
        }
    }
}
