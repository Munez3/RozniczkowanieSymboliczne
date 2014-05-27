using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Razy : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        private List<string> operatory = new List<string>();

        public Elem_Razy(List<Token> _tokeny)
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
            while (Tokeny[actualTokenIndex].Nazwa != TokenName.opMnozenie || ileNawiasow != 0)
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

            if (Dzieci[0].GetType() == typeof(Elem_Podstawowy) || Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Wyrazenie;
            else Pochodna += "(" + Dzieci[0].Wyrazenie + ")";
            Pochodna += "*";
            if (Dzieci[1].GetType() == typeof(Elem_Podstawowy) || Dzieci[1].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[1].Pochodna;
            else Pochodna += "(" + Dzieci[1].Pochodna + ")";
            Pochodna += "+";
            if (Dzieci[0].GetType() == typeof(Elem_Podstawowy) || Dzieci[0].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[0].Pochodna;
            else Pochodna += "(" + Dzieci[0].Pochodna + ")";
            Pochodna += "*";
            if (Dzieci[1].GetType() == typeof(Elem_Podstawowy) || Dzieci[1].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[1].Wyrazenie;
            else Pochodna += "(" + Dzieci[1].Wyrazenie + ")";
        }
    }
}
