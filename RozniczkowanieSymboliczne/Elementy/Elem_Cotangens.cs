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
            foreach (var dziecko in Dzieci)
            {
                dziecko.WyliczPochodna(identPoKtorymPochodniujemy);
            }
        }
    }
}
