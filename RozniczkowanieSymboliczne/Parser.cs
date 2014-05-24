using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    class Parser
    {
        private List<Token> tokeny;
        private int actualTokenIndex = 0;
        private int tokenyLength = 0;

        public Parser(List<Token> _tokeny)
        {
            tokeny = _tokeny;
            tokenyLength = tokeny.Count;
        }

        public bool Parse()
        {
            while(actualTokenIndex < tokenyLength)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.forSem) sprawdz_petle();
                else sprawdz_linie();
            }
            return true;
        }

        private void sprawdz_petle()
        {
            //for, ident, rowne, liczba, dwukropek, liczba
            if (actualTokenIndex + 6 < tokenyLength && tokeny[actualTokenIndex+1].Nazwa == TokenName.ident 
                && tokeny[actualTokenIndex + 2].Nazwa == TokenName.opRowne && tokeny[actualTokenIndex+3].Nazwa == TokenName.liczba
                && tokeny[actualTokenIndex+4].Nazwa == TokenName.dwukropek && tokeny[actualTokenIndex+5].Nazwa == TokenName.liczba)
            {
                actualTokenIndex += 6;

                //dodatkowa precyzja
                if (tokeny[actualTokenIndex].Nazwa == TokenName.dwukropek)
                {
                    actualTokenIndex++;
                    if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.liczba) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Błąd konstrukcji pętli!");
                }

                //newline
                if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Po for umieszczaj nową linię!");

                //end
                while (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa != TokenName.endSem) sprawdz_linie();

                if (actualTokenIndex == tokenyLength) throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak instrukcji End!");
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.endSem) actualTokenIndex++;
                
                //newline
                if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Wyrażenia rozdzielaj nową linią!");
            }
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Błąd konstrukcji pętli!");
        }

        private void sprawdz_linie()
        {
            if (tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
            else
            {
                if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.hash)
                {
                    actualTokenIndex++;
                    if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.ident) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Podaj zmienną po której różniczkować!");
                }

                sprawdz_wyrazenie();
                //newline
                if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Wyrażenia rozdzielaj nową linią!");
            }
        }

        private void sprawdz_wyrazenie()
        {
            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.opMinus) actualTokenIndex++;
            sprawdz_skladnik();
            while (actualTokenIndex < tokenyLength && (tokeny[actualTokenIndex].Nazwa == TokenName.opMinus | tokeny[actualTokenIndex].Nazwa == TokenName.opPlus))
            {
                actualTokenIndex++;
                sprawdz_skladnik();
            }
        }

        private void sprawdz_skladnik()
        {
            sprawdz_czynnik();
            while (actualTokenIndex < tokenyLength && (tokeny[actualTokenIndex].Nazwa == TokenName.opMnozenie | tokeny[actualTokenIndex].Nazwa == TokenName.opDzielenie))
            {
                actualTokenIndex++;
                sprawdz_czynnik();
            }
        }

        private void sprawdz_czynnik()
        {
            if (actualTokenIndex < tokenyLength)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.liczba || tokeny[actualTokenIndex].Nazwa == TokenName.ident) actualTokenIndex++;
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias)
                {
                    actualTokenIndex++;
                    sprawdz_wyrazenie();
                    if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak zamknięcia nawiasu ')' !");
                }
                else sprawdz_funkcja();
            }
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak czynnika!");

            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.opPotega)
            {
                actualTokenIndex++;
                sprawdz_czynnik();
            }
        }

        private void sprawdz_funkcja()
        {
            if (actualTokenIndex < tokenyLength)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.logFun) sprawdz_logarytm();
                else if (tokeny[actualTokenIndex].Nazwa == TokenName.sinFun ||
                        tokeny[actualTokenIndex].Nazwa == TokenName.cosFun ||
                        tokeny[actualTokenIndex].Nazwa == TokenName.tgFun ||
                        tokeny[actualTokenIndex].Nazwa == TokenName.ctgFun ||
                        tokeny[actualTokenIndex].Nazwa == TokenName.expFun) sprawdz_jednoargumentowe();
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Powinien wystąpić czynnik, a jest: "+tokeny[actualTokenIndex].Wartosc+"!");
            }
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak czynnika!");
        }

        private void sprawdz_jednoargumentowe()
        {
            actualTokenIndex++;
            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) actualTokenIndex++;
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak otwarcia nawiasu funkcji: "+tokeny[actualTokenIndex-1].Wartosc+" !");

            sprawdz_wyrazenie();

            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) actualTokenIndex++;
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak zamknięcia nawiasu ')' !");
        }

        private void sprawdz_logarytm()
        {
            actualTokenIndex++;
            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.Lnawias) actualTokenIndex++;
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak otwarcia nawiasu funkcji: " + tokeny[actualTokenIndex - 1].Wartosc + " !");

            sprawdz_wyrazenie();

            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.przecinek) actualTokenIndex++;
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak przecinka między wyrażeniami funkcji 'log' !");
            
            sprawdz_wyrazenie();

            if (actualTokenIndex < tokenyLength && tokeny[actualTokenIndex].Nazwa == TokenName.Pnawias) actualTokenIndex++;
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak zamknięcia nawiasu ')' !");
        }
    }
}
