using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Elem_Plus : Element
    {
        public List<Element> Dzieci { set; get; }
        public List<Token> Tokeny { set; get; }
        public string Wyrazenie { set; get; }
        public string Pochodna { set; get; }

        public List<string> operatory = new List<string>();

        public Elem_Plus(List<Token> _tokeny)
        {
            Dzieci = new List<Element>();
            if (_tokeny != null)
            {
                Tokeny = _tokeny;
                Wyrazenie = GeneratorKodu.stworzStringZTokenów(Tokeny);
                rozbijNaDzieci();
            }
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
                if (Tokeny[actualTokenIndex].Nazwa == TokenName.opMinus || Tokeny[actualTokenIndex].Nazwa == TokenName.opPlus)
                {
                    if (Tokeny[actualTokenIndex].Nazwa == TokenName.opMinus) operatory.Add("-");
                    else operatory.Add("+");
                    if (dziecko.Count != 0) Dzieci.Add(GeneratorKodu.wygenerujElement(dziecko));
                    dziecko = new List<Token>();
                    actualTokenIndex++;
                }
                else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias)
                {
                    int iloscNawiasow = 1;
                    dziecko.Add(Tokeny[actualTokenIndex]);
                    actualTokenIndex++;
                    while (iloscNawiasow != 0)
                    {
                        if (Tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) iloscNawiasow--;
                        else if (Tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) iloscNawiasow++;
                        dziecko.Add(Tokeny[actualTokenIndex]);
                        actualTokenIndex++;
                    }
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
            foreach (Element dziecko in Dzieci)
                dziecko.WyliczPochodna(identPoKtorymPochodniujemy);

            int actualKid = 0, actualOperator = 0, dzieciLength = Dzieci.Count, operatoryLength = operatory.Count;
            if (operatoryLength == dzieciLength) 
            {
                Pochodna += operatory[0];
                actualOperator++;
            }
            
            while(actualKid < dzieciLength)
            {
                Pochodna += Dzieci[actualKid].Pochodna;
                if (actualOperator < operatory.Count)
                {
                    Pochodna += operatory[actualOperator];
                    actualOperator++;
                }
                actualKid++;
            }
        }

        /// <summary>
        /// Generuje listę tokenów na podstawie elementów
        /// </summary>
        /// <param name="list">Lista dzieci</param>
        public void GenerujTokenyNaPodstawieElementów()
        {
            Tokeny = new List<Token>();
            int actualOperatorIndex = 0;
            if (Dzieci.Count == operatory.Count)
            {
                Tokeny.Add(new Token(TokenName.opMinus,"-",0,0));
                actualOperatorIndex++;
            }
            foreach (var dziecko in Dzieci)
            {
                if ((actualOperatorIndex == 1 && Tokeny.Count == 1) || (actualOperatorIndex == 0 && Tokeny.Count == 0)) Tokeny.AddRange(dziecko.Tokeny);
                else
                {
                    if(operatory[actualOperatorIndex].Equals("-")) Tokeny.Add(new Token(TokenName.opMinus,"-",0,0));
                    else Tokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                    Tokeny.AddRange(dziecko.Tokeny);
                }
            }
        }
    }
}
