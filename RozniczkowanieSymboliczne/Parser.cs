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

        public Parser(List<Token> _tokeny)
        {
            tokeny = _tokeny;
        }

        public bool Parse()
        {
            while(actualTokenIndex < tokeny.Count)
            {
                if (tokeny[actualTokenIndex].Nazwa == TokenName.forSem) sprawdz_petle();
                else
                {
                    sprawdz_wyrazenie();
                    //newline
                    if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Wyrażenia rozdzielaj nową linią!");
                }
            }
            return true;
        }

        private void sprawdz_petle()
        {
            //for, ident, rowne, liczba, dwukropek, liczba
            if (actualTokenIndex + 6 < tokeny.Count && tokeny[actualTokenIndex+1].Nazwa == TokenName.ident 
                && tokeny[actualTokenIndex + 2].Nazwa == TokenName.opRowne && tokeny[actualTokenIndex+3].Nazwa == TokenName.liczba
                && tokeny[actualTokenIndex+4].Nazwa == TokenName.dwukropek && tokeny[actualTokenIndex+5].Nazwa == TokenName.liczba)
            {
                actualTokenIndex += 6;

                //dodatkowa precyzja
                if (tokeny[actualTokenIndex].Nazwa == TokenName.dwukropek)
                {
                    actualTokenIndex++;
                    if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.liczba) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Błąd konstrukcji pętli!");
                }

                //opcjonalne newline
                if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;

                //begin
                if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.beginSem) actualTokenIndex++;
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak instrukcji Begin!");

                //end
                while (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa != TokenName.endSem)
                {
                    sprawdz_wyrazenie();
                    //newline
                    if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                    else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Wyrażenia rozdzielaj nową linią!");
                }
                if (actualTokenIndex == tokeny.Count) throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Brak instrukcji End!");

                //newline
                if (actualTokenIndex < tokeny.Count && tokeny[actualTokenIndex].Nazwa == TokenName.nowaLinia) actualTokenIndex++;
                else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Wyrażenia rozdzielaj nową linią!");
            }
            else throw new Exception("(" + tokeny[actualTokenIndex - 1].Linia + ":" + tokeny[actualTokenIndex - 1].Znak + ") Błąd konstrukcji pętli!");
        }

        private void sprawdz_wyrazenie()
        {
            //TODO
        }
    }
}
