using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Cleaner
    {
        /// <summary>
        /// Funkcja porządkująca wyrażenie
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string PorzadkujWyrazenie(string wyrazenie)
        {
            Skaner skaner = new Skaner(ZamienZnakiNaJeden(wyrazenie), Mode.Line);
            Element uporzadkowany = new Elem_Plus(null);
            List<Token> tokenyWyrazenia = skaner.GetAllTokens();
            tokenyWyrazenia.Remove(tokenyWyrazenia[tokenyWyrazenia.Count-1]);
            uporzadkowany.Dzieci.Add(GeneratorKodu.wygenerujElement(tokenyWyrazenia));
            PorzadkujElement(uporzadkowany);
            return uporzadkowany.Dzieci[0].Wyrazenie;
        }

        /// <summary>
        /// Zamienia dwa minusy na plus w stringu itp
        /// </summary>
        /// <param name="wyrazenie"></param>
        /// <returns></returns>
        private static string ZamienZnakiNaJeden(string wyrazenie)
        {
            string temp = "";
            int i=0;
            while(i < wyrazenie.Length)
            {
                if (wyrazenie[i] == '-' || wyrazenie[i] == '+')
                {
                    int ileMinusów = 0;
                    while (i < wyrazenie.Length && (wyrazenie[i] == '-' || wyrazenie[i] == '+'))
                    {
                        if (wyrazenie[i] == '-') ileMinusów++;
                        i++;
                    }
                    if (ileMinusów % 2 == 0) temp += "+";
                    else temp += "-";
                }
                else
                {
                    temp += wyrazenie[i];
                    i++;
                }
            }
            return temp;
        }

        /// <summary>
        /// Porządkuje element i jego dzieci
        /// </summary>
        /// <param name="element"></param>
        private static void PorzadkujElement(Element element)
        {
            if (element.GetType() == typeof(Elem_Podstawowy)) return;
            
            foreach (var dziecko in element.Dzieci)
                PorzadkujElement(dziecko);

            List<Element> tempDzieci = new List<Element>();

            foreach (var dziecko in element.Dzieci)
            {
                //Podstawowy
                if (dziecko.GetType() == typeof(Elem_Podstawowy)) tempDzieci.Add(dziecko);
                //Plus
                else if (dziecko.GetType() == typeof(Elem_Plus)) tempDzieci.Add(porzadkujPlus(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Razy)) tempDzieci.Add(porzadkujRazy(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Potega)) tempDzieci.Add(porzadkujPotega(dziecko));
                else tempDzieci.Add(dziecko);
            }

            element.Dzieci = tempDzieci;
        }

        private static Element porzadkujPotega(Element dziecko)
        {
            return dziecko;
        }

        private static Element porzadkujRazy(Element dziecko)
        {
            return dziecko;
        }

        private static Element porzadkujPlus(Element element)
        {
            //return element;
            List<Token> tempTokeny = new List<Token>();
            double wyraz_wolny = 0;
            List<string> operatory = ((Elem_Plus)element).operatory;
            int operatoryLength = operatory.Count;
            int actualOperatorIndex = 0;
            if (operatoryLength == element.Dzieci.Count) actualOperatorIndex++;

            foreach (var item in element.Dzieci)
            {
                //wyrazy wolne i wolne identy
                if (item.GetType() == typeof(Elem_Podstawowy))
                {
                    //wyrazy
                    if (item.Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        if (actualOperatorIndex - 1 < 0 || operatory[actualOperatorIndex - 1].Equals("+")) wyraz_wolny += GeneratorKodu.zwrocDoubleZTokenu(item.Tokeny[0]);
                        else wyraz_wolny -= GeneratorKodu.zwrocDoubleZTokenu(item.Tokeny[0]);
                        actualOperatorIndex++;
                    }
                    //identy
                    else if (item.Tokeny[0].Nazwa == TokenName.ident)
                    {
                        //TODO
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.Add(item.Tokeny[0]);
                        actualOperatorIndex++;
                    }
                }
                //mnożenia liczb, lub więcej identów
                else if (item.GetType() == typeof(Elem_Razy) &&
                        item.Dzieci[0].GetType() == typeof(Elem_Podstawowy) &&
                        item.Dzieci[1].GetType() == typeof(Elem_Podstawowy))
                {
                    //jeżeli jedno z nich to 0 nie rób nic
                    if (item.Dzieci[0].Tokeny[0].Wartosc.Equals("0") || item.Dzieci[1].Tokeny[0].Wartosc.Equals("0")) { actualOperatorIndex++; }
                    //Jeżeli obie liczby
                    else if (item.Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba && item.Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        if (actualOperatorIndex - 1 < 0 || operatory[actualOperatorIndex - 1].Equals("+")) wyraz_wolny += GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[0].Tokeny[0]) * GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[1].Tokeny[0]);
                        else wyraz_wolny -= GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[0].Tokeny[0]) * GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[1].Tokeny[0]);
                        actualOperatorIndex++;
                    }
                    //oba identy
                    else
                    {
                        //TODO
                    }
                }
                else if (item.GetType() == typeof(Elem_Razy))
                {
                    //jeżeli jedno z nich to jeden
                    if (item.Dzieci[0].Tokeny[0].Wartosc.Equals("1"))
                    {
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.AddRange(item.Dzieci[1].Tokeny);
                        actualOperatorIndex++;
                    }
                    else if (item.Dzieci[1].Tokeny[0].Wartosc.Equals("1"))
                    {
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.AddRange(item.Dzieci[0].Tokeny);
                        actualOperatorIndex++;
                    }
                    else
                    {
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.AddRange(item.Tokeny);
                        actualOperatorIndex++;
                    }
                }
                //nawiasy
                else if (item.GetType() == typeof(Elem_Nawias))
                {
                    if (item.Dzieci[0].GetType() == typeof(Elem_Podstawowy)) tempTokeny.Add(item.Dzieci[0].Tokeny[0]);
                    else if (item.Dzieci[0].GetType() == typeof(Elem_Plus))
                    {
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.AddRange(item.Tokeny);
                        actualOperatorIndex++;
                    }
                }

            }

            //znak wyrazu wolnego
            string znak_wyrazu_wolnego = "+";
            if (wyraz_wolny < 0)
            {
                wyraz_wolny = -wyraz_wolny;
                znak_wyrazu_wolnego = "-";
            }

            //zwracanie dziecka
            if (tempTokeny.Count == 0 && znak_wyrazu_wolnego.Equals("+")) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(wyraz_wolny), 0, 0) });
            else
            {
                if (znak_wyrazu_wolnego.Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                else tempTokeny.Add(new Token(TokenName.opMinus, "+", 0, 0));
                tempTokeny.Add(new Token(TokenName.liczba, GeneratorKodu.doubleToString(wyraz_wolny), 0, 0));
                return new Elem_Plus(tempTokeny);
            }
        }
    }
}
