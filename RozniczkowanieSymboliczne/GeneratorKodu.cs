using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class GeneratorKodu
    {
        private List<Token> wszystkieTokeny;
        private List<string> wyniki;

        public GeneratorKodu(List<Token> tokeny)
        {
            this.wszystkieTokeny = tokeny;
            wyniki = new List<string>();
            List<List<Token>> wyrazenia = rozbijNaWyrażenia(tokeny);
            foreach (var wyrazenie in wyrazenia)
                zpochodniujWyrażenie(wyrazenie);
        }

        /// <summary>
        /// Zwraca wszystkie wyniki w stringu oddzielając je nową linią
        /// </summary>
        /// <returns></returns>
        public string WyswietlWyniki()
        {
            string wszystko = "";
            foreach (var wynik in wyniki)
                wszystko += wynik + '\n';
            return wszystko;
        }

        /// <summary>
        /// Rozbija wszystkie tokeny na pojedyncze wyrażenia
        /// </summary>
        /// <param name="tokeny"></param>
        private List<List<Token>> rozbijNaWyrażenia(List<Token> tokeny)
        {
            List<List<Token>> wyrazenia = new List<List<Token>>();
            int actualTokenIndex = 0;
            int tokenyLength = tokeny.Count();
            while (actualTokenIndex < tokenyLength)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.forSem)
                {
                    actualTokenIndex++;
                    string zmienna = "";
                    double poczatek = 0, koniec = 0, precyzja = 1;

                    zmienna = tokeny[actualTokenIndex].Wartosc; actualTokenIndex += 2;
                    poczatek = double.Parse(tokeny[actualTokenIndex].Wartosc); actualTokenIndex += 2;
                    koniec = double.Parse(tokeny[actualTokenIndex].Wartosc); actualTokenIndex += 2;
                    if (tokeny[actualTokenIndex].Nazwa == TokenName.dwukropek)
                        precyzja = double.Parse(tokeny[actualTokenIndex].Wartosc); actualTokenIndex += 2;

                    List<List<Token>> lista = new List<List<Token>>();

                    while (tokeny[actualTokenIndex].Nazwa != TokenName.endSem)
                    {
                        List<Token> temp = new List<Token>();
                        while (tokeny[actualTokenIndex].Nazwa != TokenName.nowaLinia)
                        {
                            temp.Add(tokeny[actualTokenIndex].Clone());
                            actualTokenIndex++;
                        }
                        actualTokenIndex++;
                        lista.Add(temp);
                    }
                    actualTokenIndex++;

                    for (double i = poczatek; i <= koniec; i = i + precyzja)
                    {
                        foreach (var item in lista)
                        {
                            List<Token> tempList = new List<Token>();
                            foreach (var token in item)
                                if (token.Nazwa == TokenName.ident && token.Wartosc == zmienna) tempList.Add(new Token(TokenName.liczba, i+"",token.Linia,token.Znak));
                                else tempList.Add(token.Clone());
                            wyrazenia.Add(tempList);
                        }
                    }
                }
                else
                {
                    List<Token> temp = new List<Token>();
                    while (tokeny[actualTokenIndex].Nazwa != TokenName.nowaLinia)
                    {
                        temp.Add(tokeny[actualTokenIndex]);
                        actualTokenIndex++;
                    }
                    actualTokenIndex++;
                    wyrazenia.Add(temp);
                }
            }
            return wyrazenia;
        }

        /// <summary>
        /// Pochodniuje wyrażenie
        /// </summary>
        /// <param name="tokeny">tokeny wyrażenia</param>
        private void zpochodniujWyrażenie(List<Token> tokeny)
        {
            //TODO
            
            //TEST
                string temp = stworzStringZTokenów(tokeny);
                if(!temp.Equals("")) wyniki.Add(temp);
            //TEST
        }

        /// <summary>
        /// Tworzy string z listy tokenów
        /// </summary>
        /// <param name="tokeny">Lista tokenów</param>
        /// <returns>string reprezentujący wyrażenie</returns>
        private string stworzStringZTokenów(List<Token> tokeny)
        {
            string temp = "";
            foreach (var token in tokeny)
                temp += token.Wartosc;
            return temp;
        }
    }
}
