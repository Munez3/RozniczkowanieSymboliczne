using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Logarytm : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        public Elem_Logarytm(List<Token> _tokeny)
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
            int actualTokenIndex = 2;
            int iloscLogarytmow = 1;
            while (iloscLogarytmow != 0)
            {
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.przecinek) iloscLogarytmow--;
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.logFun) iloscLogarytmow++;
                if(iloscLogarytmow != 0) dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex++;
            }
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
            dziecko = new List<Token>();
            int liczbaNawiasow = 1;
            while(liczbaNawiasow != 0)
            {
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                if(liczbaNawiasow != 0) dziecko.Add(Tokeny[actualTokenIndex]);
                actualTokenIndex++;
            }
            Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
        }

        /// <summary>
        /// Wylicza pochodną
        /// </summary>
        public void WyliczPochodna(string identPoKtorymPochodniujemy)
        {
            Dzieci[0].Pochodna = "0";
            Dzieci[1].WyliczPochodna(identPoKtorymPochodniujemy);

            Pochodna += "(1/(";
            if (Dzieci[1].GetType() == typeof(Elem_Podstawowy)) Pochodna += Dzieci[1].Wyrazenie;
            else Pochodna += "("+Dzieci[1].Wyrazenie+")";
            Pochodna += "*log(e,"+Dzieci[0].Wyrazenie+")))*";
            if (Dzieci[1].GetType() == typeof(Elem_Podstawowy) || Dzieci[1].GetType() == typeof(Elem_Nawias)) Pochodna += Dzieci[1].Pochodna;
            else Pochodna += "(" + Dzieci[1].Pochodna + ")";
        }

        /// <summary>
        /// Generuje listę tokenów na podstawie elementów
        /// </summary>
        /// <param name="list">Lista dzieci</param>
        public void GenerujTokenyNaPodstawieElementów()
        {
            Tokeny = new List<Token>();
            Tokeny.Add(new Token(TokenName.logFun, "log", 0, 0));
            Tokeny.Add(new Token(TokenName.Lnawias, "(", 0, 0));
            Tokeny.AddRange(Dzieci[0].Tokeny);
            Tokeny.Add(new Token(TokenName.przecinek,",",0,0));
            Tokeny.AddRange(Dzieci[1].Tokeny);
            Tokeny.Add(new Token(TokenName.Pnawias, ")", 0, 0));
        }
    }
}
