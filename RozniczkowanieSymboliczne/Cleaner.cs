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
            string wczesniejszePorzadkowanie = "";
            string aktualnePorzadkowanie = wyrazenie;
            while (!wczesniejszePorzadkowanie.Equals(aktualnePorzadkowanie))
            {
                wczesniejszePorzadkowanie = aktualnePorzadkowanie;
                Skaner skaner = new Skaner(ZamienZnakiNaJeden(aktualnePorzadkowanie), Mode.Line);
                Element uporzadkowany = new Elem_Plus(null);
                List<Token> tokenyWyrazenia = skaner.GetAllTokens();
                tokenyWyrazenia.Remove(tokenyWyrazenia[tokenyWyrazenia.Count - 1]);
                uporzadkowany.Dzieci.Add(GeneratorKodu.wygenerujElement(tokenyWyrazenia));
                PorzadkujElement(uporzadkowany);
                if (uporzadkowany.Dzieci[0].GetType() == typeof(Elem_Nawias)) aktualnePorzadkowanie = uporzadkowany.Dzieci[0].Dzieci[0].Wyrazenie;
                aktualnePorzadkowanie = uporzadkowany.Dzieci[0].Wyrazenie;
            }
            return aktualnePorzadkowanie;
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
                if (dziecko.GetType() == typeof(Elem_Podstawowy)) tempDzieci.Add(dziecko);
                else if (dziecko.GetType() == typeof(Elem_Plus)) tempDzieci.Add(porzadkujPlus(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Razy)) tempDzieci.Add(porzadkujRazy(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Dzielenie)) tempDzieci.Add(porzadkujDzielenie(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Potega)) tempDzieci.Add(porzadkujPotega(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Sinus) || dziecko.GetType() == typeof(Elem_Cosinus) || dziecko.GetType() == typeof(Elem_Tangens)
                    || dziecko.GetType() == typeof(Elem_Cotangens) || dziecko.GetType() == typeof(Elem_Exponenta)
                    || dziecko.GetType() == typeof(Elem_Pierwiastek)) tempDzieci.Add(porzadkujJednoargumentowe(dziecko));
                else if (dziecko.GetType() == typeof(Elem_Logarytm)) tempDzieci.Add(porzadkujLogarytm(dziecko));
                else tempDzieci.Add(dziecko);
            }

            element.Dzieci = tempDzieci;
            element.GenerujTokenyNaPodstawieElementów();
            element.Wyrazenie = GeneratorKodu.stworzStringZTokenów(element.Tokeny);
        }

        /// <summary>
        /// Porządkowanie logarytmu
        /// </summary>
        /// <param name="dziecko"></param>
        /// <returns></returns>
        private static Element porzadkujLogarytm(Element element)
        {
            if(element.Dzieci[0].GetType() == typeof(Elem_Podstawowy) && element.Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba 
                && element.Dzieci[1].GetType() == typeof(Elem_Podstawowy) && element.Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Log(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[1].Tokeny[0]), GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            //Ewentualne dodanie log(e,liczba)
            return element;
        }

        /// <summary>
        /// Porządkowanie jednoargumentowe
        /// </summary>
        /// <param name="dziecko"></param>
        /// <returns></returns>
        private static Element porzadkujJednoargumentowe(Element element)
        {
            if (element.Dzieci[0].GetType() != typeof(Elem_Podstawowy) || element.Dzieci[0].Tokeny[0].Nazwa != TokenName.liczba) return element;
            if (element.GetType() == typeof(Elem_Sinus)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Sin(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            if (element.GetType() == typeof(Elem_Cosinus)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Cos(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            if (element.GetType() == typeof(Elem_Tangens)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Tan(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            if (element.GetType() == typeof(Elem_Cotangens)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(1/Math.Tan(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            if (element.GetType() == typeof(Elem_Exponenta)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Exp(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            if (element.GetType() == typeof(Elem_Pierwiastek)) return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(Math.Sqrt(GeneratorKodu.zwrocDoubleZTokenu(element.Dzieci[0].Tokeny[0]))), 0, 0) });
            return element;
        }

        /// <summary>
        /// Porządkowanie potęg
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Element porzadkujPotega(Element element)
        {
            //return element;
            List<Token> tempTokenyPodstawa = new List<Token>();
            List<Token> tempTokenyPotega = new List<Token>();

            for (int i = 0; i < 2; i++)
            {
                if (element.Dzieci[i].GetType() == typeof(Elem_Nawias) && element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Podstawowy))
                {
                    if (i == 0) tempTokenyPodstawa.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                    else tempTokenyPotega.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                }
                else
                {
                    if (i == 0) tempTokenyPodstawa.AddRange(element.Dzieci[i].Tokeny);
                    else tempTokenyPotega.AddRange(element.Dzieci[i].Tokeny);
                }
            }

            //zwracanie
            if (tempTokenyPodstawa.Count == 1 && tempTokenyPodstawa[0].Nazwa == TokenName.liczba && tempTokenyPotega.Count == 1 && tempTokenyPotega[0].Nazwa == TokenName.liczba)
            {
                double wartosc = Math.Pow(GeneratorKodu.zwrocDoubleZTokenu(tempTokenyPodstawa[0]), GeneratorKodu.zwrocDoubleZTokenu(tempTokenyPotega[0]));
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(wartosc), 0, 0) });
            }
            else if (tempTokenyPotega.Count == 1 && tempTokenyPotega[0].Nazwa == TokenName.liczba && tempTokenyPotega[0].Wartosc == "1")
                return GeneratorKodu.wygenerujElement(tempTokenyPodstawa);
            else if (tempTokenyPotega.Count == 1 && tempTokenyPotega[0].Nazwa == TokenName.liczba && tempTokenyPotega[0].Wartosc == "0")
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, "0", 0, 0) });
            else if (tempTokenyPodstawa.Count == 1 && tempTokenyPodstawa[0].Nazwa == TokenName.liczba && tempTokenyPodstawa[0].Wartosc == "1")
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, "1", 0, 0) });
            else if (tempTokenyPodstawa.Count == 1 && tempTokenyPodstawa[0].Nazwa == TokenName.liczba && tempTokenyPodstawa[0].Wartosc == "0")
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, "0", 0, 0) });
            else
            {
                tempTokenyPodstawa.Add(new Token(TokenName.opPotega, "^", 0, 0));
                tempTokenyPodstawa.AddRange(tempTokenyPotega);
            }

            return GeneratorKodu.wygenerujElement(tempTokenyPodstawa);

        }

        /// <summary>
        /// Porządkowanie dzieleń
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Element porzadkujDzielenie(Element element)
        {
            //return element;
            List<Token> tempTokenyLewe = new List<Token>();
            List<Token> tempTokenyPrawe = new List<Token>();
            
            for (int i = 0; i < 2; i++)
            {
                if (element.Dzieci[i].GetType() == typeof(Elem_Nawias) && (element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Podstawowy)
                //|| element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Razy) 
                || element.Dzieci[i].Dzieci[0].GetType() ==  typeof(Elem_Dzielenie)
                || element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Potega)))
                {
                    if (i == 0) tempTokenyLewe.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                    else tempTokenyPrawe.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                }
                else
                {
                    if (i == 0) tempTokenyLewe.AddRange(element.Dzieci[i].Tokeny);
                    else tempTokenyPrawe.AddRange(element.Dzieci[i].Tokeny);
                }
            }

            //Zwracanie
            //Jeżeli sama liczba
            if (tempTokenyLewe.Count == 1 && tempTokenyLewe[0].Nazwa == TokenName.liczba && tempTokenyPrawe.Count == 1 && tempTokenyPrawe[0].Nazwa == TokenName.liczba)
            {
                double wartosc = GeneratorKodu.zwrocDoubleZTokenu(tempTokenyLewe[0]) / GeneratorKodu.zwrocDoubleZTokenu(tempTokenyPrawe[0]);
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(wartosc), 0, 0) });
            }
            //Jeżeli pierwsze zero
            else if (tempTokenyLewe.Count == 1 && tempTokenyLewe[0].Nazwa == TokenName.liczba && tempTokenyLewe[0].Wartosc.Equals("0"))
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, "0", 0, 0) });
            //Jeżeli drugie jeden
            else if (tempTokenyPrawe.Count == 1 && tempTokenyPrawe[0].Nazwa == TokenName.liczba && tempTokenyPrawe[0].Wartosc.Equals("1"))
                return GeneratorKodu.wygenerujElement(tempTokenyLewe);
            //Jeżeli inne
            else
            {
                tempTokenyLewe.Add(new Token(TokenName.opDzielenie, "/", 0, 0));
                tempTokenyLewe.AddRange(tempTokenyPrawe);
            }

            return grupujMnozeniaiDzielenia(GeneratorKodu.wygenerujElement(tempTokenyLewe));
        }

        /// <summary>
        /// Porządkowanie mnożeń
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Element porzadkujRazy(Element element)
        {
            //return element;
            List<Token> tempTokenyLewe = new List<Token>();
            List<Token> tempTokenyPrawe = new List<Token>();

            for (int i = 0; i < 2; i++)
            {
                if (element.Dzieci[i].GetType() == typeof(Elem_Nawias) && (element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Podstawowy)
                || element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Razy) || element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Dzielenie)
                || element.Dzieci[i].Dzieci[0].GetType() == typeof(Elem_Potega)))
                {
                    if(i == 0) tempTokenyLewe.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                    else tempTokenyPrawe.AddRange(element.Dzieci[i].Dzieci[0].Tokeny);
                }
                else
                {
                    if (i == 0) tempTokenyLewe.AddRange(element.Dzieci[i].Tokeny);
                    else tempTokenyPrawe.AddRange(element.Dzieci[i].Tokeny);
                }
            }

            //Zwracanie
            //Jeżeli sama liczba
            if (tempTokenyLewe.Count == 1 && tempTokenyLewe[0].Nazwa == TokenName.liczba && tempTokenyPrawe.Count == 1 && tempTokenyPrawe[0].Nazwa == TokenName.liczba)
            {
                double wartosc = GeneratorKodu.zwrocDoubleZTokenu(tempTokenyLewe[0]) * GeneratorKodu.zwrocDoubleZTokenu(tempTokenyPrawe[0]);
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, GeneratorKodu.doubleToString(wartosc), 0, 0) });
            }
            //Jeżeli któreś zero
            else if (tempTokenyLewe.Count == 1 && tempTokenyLewe[0].Nazwa == TokenName.liczba && tempTokenyLewe[0].Wartosc.Equals("0")
                || tempTokenyPrawe.Count == 1 && tempTokenyPrawe[0].Nazwa == TokenName.liczba && tempTokenyPrawe[0].Wartosc.Equals("0"))
                return new Elem_Podstawowy(new List<Token>() { new Token(TokenName.liczba, "0", 0, 0) });
            //Jeżeli pierwsze jeden
            else if (tempTokenyLewe.Count == 1 && tempTokenyLewe[0].Nazwa == TokenName.liczba && tempTokenyLewe[0].Wartosc.Equals("1"))
                return GeneratorKodu.wygenerujElement(tempTokenyPrawe);
            //Jeżeli drugie jeden
            else if (tempTokenyPrawe.Count == 1 && tempTokenyPrawe[0].Nazwa == TokenName.liczba && tempTokenyPrawe[0].Wartosc.Equals("1"))
                return GeneratorKodu.wygenerujElement(tempTokenyLewe);
            else
            {
                tempTokenyLewe.Add(new Token(TokenName.opMnozenie, "*", 0,0));
                tempTokenyLewe.AddRange(tempTokenyPrawe);

                //Grupowanie
                return grupujMnozeniaiDzielenia(GeneratorKodu.wygenerujElement(tempTokenyLewe));
            }
        }

        /// <summary>
        /// Funkcja grupujaca mnożenia i dzielenia
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Element grupujMnozeniaiDzielenia(Element element)
        {
            Dictionary<string, double> grupy = new Dictionary<string, double>();
            double wyrazWolny = 1;

            Element elementTymczasowy = element;
            while (elementTymczasowy.GetType() == typeof(Elem_Razy) || elementTymczasowy.GetType() == typeof(Elem_Dzielenie))
            {
                //Drugie dziecko zawsze będzie czymś innym niż mnożenie, czy dzielenie dlatego od razu dodajemy je do grup
                //Jeżeli drugie dziecko to potęga
                if (elementTymczasowy.Dzieci[1].GetType() == typeof(Elem_Potega) && elementTymczasowy.Dzieci[1].Dzieci[1].GetType() == typeof(Elem_Podstawowy) && elementTymczasowy.Dzieci[1].Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                {
                    //Gdy istnieje już z grupach
                    if (grupy.ContainsKey(elementTymczasowy.Dzieci[1].Dzieci[0].Wyrazenie))
                    {
                        if (elementTymczasowy.GetType() == typeof(Elem_Razy)) grupy[elementTymczasowy.Dzieci[1].Dzieci[0].Wyrazenie] += GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Dzieci[1].Tokeny[0]);
                        else grupy[elementTymczasowy.Dzieci[1].Dzieci[0].Wyrazenie] -= GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Dzieci[1].Tokeny[0]);
                    }
                    else
                    {
                        if (elementTymczasowy.GetType() == typeof(Elem_Razy)) grupy.Add(elementTymczasowy.Dzieci[1].Dzieci[0].Wyrazenie, GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Dzieci[1].Tokeny[0]));
                        else grupy.Add(elementTymczasowy.Dzieci[1].Dzieci[0].Wyrazenie, -1 * GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Dzieci[1].Tokeny[0]));
                    }
                }
                //Jeżeli pojedyncza liczba
                else if (elementTymczasowy.Dzieci[1].GetType() == typeof(Elem_Podstawowy) && elementTymczasowy.Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                {
                    if (elementTymczasowy.GetType() == typeof(Elem_Razy)) wyrazWolny *= GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Tokeny[0]);
                    else wyrazWolny /= GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[1].Tokeny[0]);
                }
                //Jeżeli liczba ujemna w nawiasie
                else if (elementTymczasowy.Dzieci[1].GetType() == typeof(Elem_Nawias) && elementTymczasowy.Dzieci[1].Dzieci[0].GetType() == typeof(Elem_Plus)
                    && elementTymczasowy.Dzieci[1].Dzieci[0].Dzieci.Count == 1 && elementTymczasowy.Dzieci[1].Dzieci[0].Dzieci[0].GetType() == typeof(Elem_Podstawowy)
                    && elementTymczasowy.Dzieci[1].Dzieci[0].Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba) 
                {
                    Elem_Plus temp = (Elem_Plus)elementTymczasowy.Dzieci[1].Dzieci[0];
                    if (elementTymczasowy.GetType() == typeof(Elem_Razy)) wyrazWolny *= GeneratorKodu.zwrocDoubleZTokenu(temp.Dzieci[0].Tokeny[0]);
                    else wyrazWolny /= GeneratorKodu.zwrocDoubleZTokenu(temp.Dzieci[0].Tokeny[0]);
                    if (temp.operatory.Count != 0 && temp.operatory[0].Equals("-")) wyrazWolny *= -1;
                }
                //Jeżeli coś innego
                else
                {
                    if (grupy.ContainsKey(elementTymczasowy.Dzieci[1].Wyrazenie))
                    {
                        if (elementTymczasowy.GetType() == typeof(Elem_Razy)) grupy[elementTymczasowy.Dzieci[1].Wyrazenie] += 1;
                        else grupy[elementTymczasowy.Dzieci[1].Wyrazenie] -= 1;
                    }
                    else
                    {
                        if (elementTymczasowy.GetType() == typeof(Elem_Razy)) grupy.Add(elementTymczasowy.Dzieci[1].Wyrazenie, 1);
                        else grupy.Add(elementTymczasowy.Dzieci[1].Wyrazenie, -1);
                    }
                }

                //Jeżeli pierwsze dziecko nie jest mnożeniem lub dzieleniem to dodajemy pierwszy człon jako mnożenie
                if (elementTymczasowy.Dzieci[0].GetType() != typeof(Elem_Razy) && elementTymczasowy.Dzieci[0].GetType() != typeof(Elem_Dzielenie))
                {
                    if (elementTymczasowy.Dzieci[0].GetType() == typeof(Elem_Potega) && elementTymczasowy.Dzieci[0].Dzieci[1].GetType() == typeof(Elem_Podstawowy) && elementTymczasowy.Dzieci[0].Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        //Gdy istnieje już z grupach
                        if (grupy.ContainsKey(elementTymczasowy.Dzieci[0].Dzieci[0].Wyrazenie)) grupy[elementTymczasowy.Dzieci[0].Dzieci[0].Wyrazenie] += GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[0].Dzieci[1].Tokeny[0]);
                        else grupy.Add(elementTymczasowy.Dzieci[0].Dzieci[0].Wyrazenie, GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[0].Dzieci[1].Tokeny[0]));
                    }
                    //Jeżeli pojedyncza liczba
                    else if (elementTymczasowy.Dzieci[0].GetType() == typeof(Elem_Podstawowy) && elementTymczasowy.Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba)
                        wyrazWolny *= GeneratorKodu.zwrocDoubleZTokenu(elementTymczasowy.Dzieci[0].Tokeny[0]);
                    //Jeżeli liczba ujemna w nawiasie
                    else if (elementTymczasowy.Dzieci[0].GetType() == typeof(Elem_Nawias) && elementTymczasowy.Dzieci[0].Dzieci[0].GetType() == typeof(Elem_Plus)
                        && elementTymczasowy.Dzieci[0].Dzieci[0].Dzieci.Count == 1 && elementTymczasowy.Dzieci[0].Dzieci[0].Dzieci[0].GetType() == typeof(Elem_Podstawowy)
                        && elementTymczasowy.Dzieci[0].Dzieci[0].Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        Elem_Plus temp = (Elem_Plus)elementTymczasowy.Dzieci[0].Dzieci[0];
                        wyrazWolny *= GeneratorKodu.zwrocDoubleZTokenu(temp.Dzieci[0].Tokeny[0]);
                        if (temp.operatory.Count != 0 && temp.operatory[0].Equals("-")) wyrazWolny *= -1;
                    }
                    //Jeżeli coś innego
                    else
                    {
                        if (grupy.ContainsKey(elementTymczasowy.Dzieci[0].Wyrazenie)) grupy[elementTymczasowy.Dzieci[0].Wyrazenie] += 1;
                        else grupy.Add(elementTymczasowy.Dzieci[0].Wyrazenie, 1);
                    }
                }
                elementTymczasowy = elementTymczasowy.Dzieci[0];
            }

            List<Token> noweTokeny = new List<Token>();
            if(wyrazWolny != 1) grupy.Add(GeneratorKodu.doubleToString(wyrazWolny), 1);
            foreach (var rejestr in grupy.OrderBy(key => key.Key))
            {
                Skaner skaner = new Skaner(rejestr.Key, Mode.Line);
                List<Token> tokenyKeya = skaner.GetAllTokens();
                tokenyKeya.Remove(tokenyKeya[tokenyKeya.Count - 1]);

                if (noweTokeny.Count != 0) noweTokeny.Add(new Token(TokenName.opMnozenie, "*", 0, 0));

                if (rejestr.Value != 0 && rejestr.Value != 1)
                {
                    if (rejestr.Value > 0)
                    {
                        noweTokeny.AddRange(tokenyKeya);
                        noweTokeny.Add(new Token(TokenName.opPotega, "^", 0, 0));
                        noweTokeny.Add(new Token(TokenName.liczba, GeneratorKodu.doubleToString(rejestr.Value), 0, 0));
                    }
                    else
                    {
                        double value = -1 * rejestr.Value;
                        noweTokeny.Add(new Token(TokenName.liczba, "1", 0, 0));
                        noweTokeny.Add(new Token(TokenName.opDzielenie, "/", 0, 0));
                        noweTokeny.AddRange(tokenyKeya);
                        if (value != 1)
                        {
                            noweTokeny.Add(new Token(TokenName.opPotega, "^", 0, 0));
                            noweTokeny.Add(new Token(TokenName.liczba, GeneratorKodu.doubleToString(value), 0, 0));
                        }
                    }
                }
                else if (rejestr.Value == 0) noweTokeny.Add(new Token(TokenName.liczba, "1", 0, 0));
                else if (rejestr.Value == 1) noweTokeny.AddRange(tokenyKeya);
            }

            return GeneratorKodu.wygenerujElement(noweTokeny);
        }

        /// <summary>
        /// Porządkowanie dodawań
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static Element porzadkujPlus(Element element)
        {
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
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.Add(item.Tokeny[0]);
                        actualOperatorIndex++;
                    }
                }
                //nawiasy
                else if (item.GetType() == typeof(Elem_Nawias))
                {
                    //Gdy tylko element podstawowy w nawiasie
                    if (item.Dzieci[0].GetType() == typeof(Elem_Podstawowy))
                    {
                        if (item.Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba)
                        {
                            if (actualOperatorIndex - 1 < 0 || operatory[actualOperatorIndex - 1].Equals("+")) wyraz_wolny += GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[0].Tokeny[0]);
                            else wyraz_wolny -= GeneratorKodu.zwrocDoubleZTokenu(item.Dzieci[0].Tokeny[0]);
                        }
                        else
                        {
                            if (tempTokeny.Count != 0 && actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                            else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                            tempTokeny.Add(item.Dzieci[0].Tokeny[0]);
                        }
                        actualOperatorIndex++;
                    }
                    //gdy inny plus to można złączyć
                    else if (item.Dzieci[0].GetType() == typeof(Elem_Plus))
                    {
                        bool minusPrzed = false;
                        if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) minusPrzed = true;

                        int operatoryIndex = 0;
                        Elem_Plus plusWNawiasie = (Elem_Plus)item.Dzieci[0];
                        if (plusWNawiasie.Dzieci.Count == plusWNawiasie.operatory.Count) operatoryIndex++;
                        foreach (var dziecko in plusWNawiasie.Dzieci)
                        {
                            if (minusPrzed)
                            {
                                if (operatoryIndex - 1 >= 0 && plusWNawiasie.operatory[operatoryIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                                else tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                            }
                            else
                            {
                                if (operatoryIndex - 1 >= 0 && plusWNawiasie.operatory[operatoryIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                                else tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                            }
                            tempTokeny.AddRange(dziecko.Tokeny);
                            operatoryIndex++;
                        }
                        actualOperatorIndex++;
                    }
                    else
                    {
                        if (tempTokeny.Count != 0 && actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        tempTokeny.AddRange(item.Dzieci[0].Tokeny);
                        actualOperatorIndex++;
                    }
                }
                //inne
                else
                {
                    if (tempTokeny.Count != 0 && actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("+")) tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                    else if (actualOperatorIndex - 1 >= 0 && operatory[actualOperatorIndex - 1].Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                    tempTokeny.AddRange(item.Tokeny);
                    actualOperatorIndex++;
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
                if (wyraz_wolny != 0)
                {
                    if (znak_wyrazu_wolnego.Equals("-")) tempTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                    else tempTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                    tempTokeny.Add(new Token(TokenName.liczba, GeneratorKodu.doubleToString(wyraz_wolny), 0, 0));
                }

                //grupowanie
                Elem_Plus tempPlus = new Elem_Plus(tempTokeny);
                Dictionary<string, double> grupy = new Dictionary<string, double>();
                int operatoryIndex = 0;
                if (tempPlus.operatory.Count == tempPlus.Dzieci.Count) operatoryIndex++;
                //Zliczenie ilości występowania 
                foreach (var dziecko in tempPlus.Dzieci)
                {
                    //Jeżeli mnożenie gdzie jeden z czynników to liczba to dodajemy do naszej listy drugi czynnik z multiplikatorem równym liczbie
                    if (dziecko.GetType() == typeof(Elem_Razy) && dziecko.Dzieci[0].GetType() == typeof(Elem_Podstawowy) && dziecko.Dzieci[0].Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        if (grupy.ContainsKey(dziecko.Dzieci[1].Wyrazenie))
                            grupy[dziecko.Dzieci[1].Wyrazenie] = (operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("+")) ? grupy[dziecko.Dzieci[1].Wyrazenie] += GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[0].Tokeny[0]) : grupy[dziecko.Dzieci[1].Wyrazenie] -= GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[0].Tokeny[0]);
                        else if (operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("-")) grupy.Add(dziecko.Dzieci[1].Wyrazenie, -1*GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[0].Tokeny[0]));
                        else grupy.Add(dziecko.Dzieci[1].Wyrazenie, GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[0].Tokeny[0]));
                    }
                    else if (dziecko.GetType() == typeof(Elem_Razy) && dziecko.Dzieci[1].GetType() == typeof(Elem_Podstawowy) && dziecko.Dzieci[1].Tokeny[0].Nazwa == TokenName.liczba)
                    {
                        if (grupy.ContainsKey(dziecko.Dzieci[0].Wyrazenie))
                            grupy[dziecko.Dzieci[0].Wyrazenie] = (operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("+")) ? grupy[dziecko.Dzieci[0].Wyrazenie] += GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[1].Tokeny[0]) : grupy[dziecko.Dzieci[0].Wyrazenie] -= GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[1].Tokeny[0]);
                        else if(operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("-")) grupy.Add(dziecko.Dzieci[0].Wyrazenie, -1*GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[1].Tokeny[0]));
                        else grupy.Add(dziecko.Dzieci[0].Wyrazenie, GeneratorKodu.zwrocDoubleZTokenu(dziecko.Dzieci[1].Tokeny[0]));
                    }
                    //Wszystki inne przypadki
                    else
                    {
                        if (grupy.ContainsKey(dziecko.Wyrazenie))
                            grupy[dziecko.Wyrazenie] = (operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("+")) ? grupy[dziecko.Wyrazenie] + 1 : grupy[dziecko.Wyrazenie] - 1;
                        else if(operatoryIndex - 1 >= 0 && tempPlus.operatory[operatoryIndex-1].Equals("-")) grupy.Add(dziecko.Wyrazenie, -1);
                        else grupy.Add(dziecko.Wyrazenie, 1);
                    }
                    operatoryIndex++;
                }

                List<Token> noweTokeny = new List<Token>();
                foreach (var rejestr in grupy)
                {
                    if (rejestr.Value != 0)
                    {
                        Skaner tempSkaner = new Skaner(rejestr.Key, Mode.Line);
                        if (rejestr.Value < 0) noweTokeny.Add(new Token(TokenName.opMinus, "-", 0, 0));
                        else if (noweTokeny.Count != 0) noweTokeny.Add(new Token(TokenName.opPlus, "+", 0, 0));
                        double value = rejestr.Value < 0 ? -rejestr.Value : rejestr.Value;
                        if (value != 1)
                        {
                            noweTokeny.Add(new Token(TokenName.liczba, GeneratorKodu.doubleToString(value), 0, 0));
                            noweTokeny.Add(new Token(TokenName.opMnozenie, "*", 0, 0));
                        }
                        List<Token> tokenyZSkanera = tempSkaner.GetAllTokens();
                        tokenyZSkanera.Remove(tokenyZSkanera[tokenyZSkanera.Count - 1]);
                        noweTokeny.AddRange(tokenyZSkanera);
                    }
                }
                if(noweTokeny.Count == 0) noweTokeny.Add(new Token(TokenName.liczba, "0",0,0));
                return GeneratorKodu.wygenerujElement(noweTokeny);
            }
        }
    }
}
