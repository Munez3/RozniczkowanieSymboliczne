using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    /// <summary>
    /// Tryb wyników generatora kodu
    /// </summary>
    public enum GeneratorMode { Normal, Debug };

    /// <summary>
    /// Generator kodu
    /// </summary>
    class GeneratorKodu
    {
        private List<Token> wszystkieTokeny;
        private List<string> wyniki;
        private List<string> wynikiDebug;

        public GeneratorKodu(List<Token> tokeny)
        {
            this.wszystkieTokeny = tokeny;
            wyniki = new List<string>();
            wynikiDebug = new List<string>();
            List<List<Token>> wyrazenia = rozbijNaWyrażenia(tokeny);
            foreach (var wyrazenie in wyrazenia)
                zpochodniujWyrażenie(wyrazenie);
        }

        /// <summary>
        /// Zwraca wszystkie wyniki w stringu oddzielając je nową linią
        /// </summary>
        /// <returns></returns>
        public string WyswietlWyniki(GeneratorMode mode)
        {
            string wszystko = "";
            if (mode == GeneratorMode.Normal)
            {
                foreach (var wynik in wyniki)
                    wszystko += wynik + '\n';
            }
            else
            {
                foreach (var wynikDebug in wynikiDebug)
                    wszystko += wynikDebug + '\n';
            }
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
                    poczatek = zwrocDoubleZTokenu(tokeny[actualTokenIndex]); actualTokenIndex += 2;
                    koniec = zwrocDoubleZTokenu(tokeny[actualTokenIndex]); actualTokenIndex++;
                    if (tokeny[actualTokenIndex].Nazwa == TokenName.dwukropek)
                    {
                        actualTokenIndex++;
                        precyzja = zwrocDoubleZTokenu(tokeny[actualTokenIndex]); 
                        actualTokenIndex++; 
                    }

                    List<List<Token>> lista = new List<List<Token>>();

                    while (tokeny[actualTokenIndex].Nazwa != TokenName.endforSem)
                    {
                        List<Token> temp = new List<Token>();
                        while (tokeny[actualTokenIndex].Nazwa != TokenName.nowaLinia)
                        {
                            temp.Add((Token)tokeny[actualTokenIndex].Clone());
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
                                if (token.Nazwa == TokenName.ident && token.Wartosc == zmienna) tempList.Add(new Token(TokenName.liczba, doubleToString(i)+"",token.Linia,token.Znak));
                                else tempList.Add((Token)token.Clone());
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
            Element mainElement;
            string identPoKtorymPochodniujemy = "x";
            if (tokeny.Count >= 2 && tokeny[0].Nazwa == TokenName.hash)
            {
                identPoKtorymPochodniujemy = tokeny[1].Wartosc;
                List<Token> tempTokeny = new List<Token>();
                for (int i = 2; i < tokeny.Count; i++)
                    tempTokeny.Add(tokeny[i]);
                mainElement = wygenerujElement(tempTokeny);
            }
            else mainElement = wygenerujElement(tokeny);

            if (mainElement != null)
            {
                mainElement.WyliczPochodna(identPoKtorymPochodniujemy);
                wyniki.Add(Cleaner.PorzadkujWyrazenie(mainElement.Pochodna));
                wynikiDebug.Add(Cleaner.PorzadkujWyrazenie(mainElement.Pochodna) + "\n" + mainElement.Pochodna + "\n\n");
            }
        }

        /// <summary>
        /// Zwraca Element odpowiedniego rodzaju na podstawie tokenów
        /// </summary>
        /// <param name="tokeny"></param>
        /// <returns></returns>
        public static Element wygenerujElement(List<Token> tokeny)
        {
            if (tokeny.Count == 0 || (tokeny.Count == 1 && tokeny[0].Nazwa == TokenName.nowaLinia)) return null;
            int control = -1; //0 - Podstawowy, 1-7 - funkcje, 20-nawias, 21 - potega, 22-mnozenie, 23 - dzielenie, 24-dodawanie
            if (tokeny[0].Nazwa == TokenName.opMinus) return new Elem_Plus(tokeny);
            int actualTokenIndex = 0, tokenyLength = tokeny.Count;
            while (actualTokenIndex < tokenyLength && control < 24)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.ident || tokeny[actualTokenIndex].Nazwa == TokenName.liczba)
                {
                    control = (control < 0) ? 0 : control;
                    actualTokenIndex++;
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.opPlus || tokeny[actualTokenIndex].Nazwa == TokenName.opMinus)
                {
                    control = (control < 24) ? 24 : control;
                    actualTokenIndex++;
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.opDzielenie)
                {
                    control = (control < 23) ? 23 : control;
                    actualTokenIndex++;
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.opMnozenie)
                {
                    control = (control < 22 || control == 23) ? 22 : control;
                    actualTokenIndex++;
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.opPotega)
                {
                    control = (control < 21) ? 21 : control;
                    actualTokenIndex++;
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias)
                {
                    actualTokenIndex++;
                    control = (control < 20) ? 20 : control;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.sinFun)
                {
                    control = (control < 1) ? 1 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.cosFun)
                {
                    control = (control < 2) ? 2 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.tgFun)
                {
                    control = (control < 3) ? 3 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.ctgFun)
                {
                    control = (control < 4) ? 4 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.logFun)
                {
                    control = (control < 5) ? 5 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.expFun)
                {
                    control = (control < 6) ? 6 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.sqrtFun)
                {
                    control = (control < 7) ? 7 : control;
                    actualTokenIndex += 2;
                    int liczbaNawiasow = 1;
                    while (liczbaNawiasow != 0)
                    {
                        if (tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) liczbaNawiasow--;
                        else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) liczbaNawiasow++;
                        actualTokenIndex++;
                    }
                }
                else actualTokenIndex++;
            }

            if (control == 0) return new Elem_Podstawowy(tokeny);
            if (control == 1) return new Elem_Sinus(tokeny);
            if (control == 2) return new Elem_Cosinus(tokeny);
            if (control == 3) return new Elem_Tangens(tokeny);
            if (control == 4) return new Elem_Cotangens(tokeny);
            if (control == 5) return new Elem_Logarytm(tokeny);
            if (control == 6) return new Elem_Exponenta(tokeny);
            if (control == 7) return new Elem_Pierwiastek(tokeny);
            if (control == 20) return new Elem_Nawias(tokeny);
            if (control == 21) return new Elem_Potega(tokeny);
            if (control == 22) return new Elem_Razy(tokeny);
            if (control == 23) return new Elem_Dzielenie(tokeny);
            if (control == 24) return new Elem_Plus(tokeny);
            return null;
        }

        /// <summary>
        /// Tworzy string z listy tokenów
        /// </summary>
        /// <param name="tokeny">Lista tokenów</param>
        /// <returns>string reprezentujący wyrażenie</returns>
        public static string stworzStringZTokenów(List<Token> tokeny)
        {
            string temp = "";
            foreach (var token in tokeny)
                temp += token.Wartosc;
            return temp;
        }

        /// <summary>
        /// Zwraca double z tokenu będącego liczbą
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>double</returns>
        public static double zwrocDoubleZTokenu(Token token)
        {
            if (token.Nazwa == TokenName.liczba)
            {
                string temp = "";
                for (int i = 0; i < token.Wartosc.Length; i++)
                    if (token.Wartosc[i] == '.') temp += ',';
                    else temp += token.Wartosc[i];

                return double.Parse(temp);
            }
            else throw new Exception("Nie można zwrócić double z tokenu niebędącego liczbą. Znaleziony token: "+token.Nazwa.ToString());
        }

        /// <summary>
        /// Zamiana doubla na string z '.' zamiast ','
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string doubleToString(double liczba)
        {
            string temp = liczba + "";
            string wynik = "";
            for (int i = 0; i < temp.Length; i++)
                if (temp[i] == ',') wynik += '.';
                else wynik += temp[i];

            return wynik;
        }
    }
}
