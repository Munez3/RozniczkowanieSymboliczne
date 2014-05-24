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
            int actualTokenIndex = 0, tokenyLength = Tokeny.Count;
            List<Token> dziecko = new List<Token>();
            while (actualTokenIndex < tokenyLength)
            {
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.opMnozenie || Tokeny[actualTokenIndex].Nazwa == TokenName.opDzielenie)
                {
                    if (Tokeny[actualTokenIndex].Nazwa == TokenName.opMnozenie) operatory.Add("*");
                    else operatory.Add("/");
                    if (dziecko.Count != 0) Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
                    dziecko = new List<Token>();
                    actualTokenIndex++;
                }
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias)
                {
                    while (Tokeny[actualTokenIndex].Nazwa != TokenName.Pnawias)
                    {
                        dziecko.Add(Tokeny[actualTokenIndex]);
                        actualTokenIndex++;
                    }
                    dziecko.Add(Tokeny[actualTokenIndex]);
                    actualTokenIndex++;
                }
                else
                {
                    dziecko.Add(Tokeny[actualTokenIndex]);
                    actualTokenIndex++;
                }
            }
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
