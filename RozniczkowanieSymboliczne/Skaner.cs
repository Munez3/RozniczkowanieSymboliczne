using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    /// <summary>
    /// Tryb danych skanera
    /// </summary>
    public enum Mode { Line, Programmer, File};

    class Skaner
    {
        private string textToParse;
        private int actualTokenIndex = 0;
        private int linia = 0;
        private int znak = 0;

        public Skaner(string textOrFileName, Mode mode)
        {
            if (mode != Mode.File) textToParse = textOrFileName;
            else textToParse = LoadStringFromFile(textOrFileName);
        }

        /// <summary>
        /// Zwraca kolejny token.
        /// Jeżeli zwróci null to nie ma już tokenów
        /// </summary>
        /// <returns>Token ewentualnie null</returns>
        public Token GetNextToken()
        {
            //Białe znaki
            while (actualTokenIndex < textToParse.Length && Char.IsWhiteSpace(textToParse[actualTokenIndex]))
            {
                if (textToParse[actualTokenIndex] == '\n') { linia++; znak = 0; }
                else znak++;
                actualTokenIndex++;
            }

            if (actualTokenIndex != textToParse.Length)
            {
                //Jednoelementowe
                if (textToParse[actualTokenIndex] == '-') { actualTokenIndex++; znak++; return new Token(TokenName.opMinus, "-"); }
                if (textToParse[actualTokenIndex] == '+') { actualTokenIndex++; znak++; return new Token(TokenName.opPlus, "+"); }
                if (textToParse[actualTokenIndex] == '*') { actualTokenIndex++; znak++; return new Token(TokenName.opMnozenie, "*"); }
                if (textToParse[actualTokenIndex] == '/') { actualTokenIndex++; znak++; return new Token(TokenName.opDzielenie, "/"); }
                if (textToParse[actualTokenIndex] == '^') { actualTokenIndex++; znak++; return new Token(TokenName.opPotega, "^"); }
                if (textToParse[actualTokenIndex] == ',') { actualTokenIndex++; znak++; return new Token(TokenName.przecinek, ","); }
                if (textToParse[actualTokenIndex] == ':') { actualTokenIndex++; znak++; return new Token(TokenName.dwukropek, ":"); }
                if (textToParse[actualTokenIndex] == '(') { actualTokenIndex++; znak++; return new Token(TokenName.Lnawias, "("); }
                if (textToParse[actualTokenIndex] == ')') { actualTokenIndex++; znak++; return new Token(TokenName.Pnawias, ")"); }

                //liczba
                if(Char.IsNumber(textToParse[actualTokenIndex]))
                {
                    string wartosc = "";
                    byte iloscKropek = 0;
                    while (actualTokenIndex < textToParse.Length && (Char.IsNumber(textToParse[actualTokenIndex]) || textToParse[actualTokenIndex] == '.'))
                    {
                        if (textToParse[actualTokenIndex] == '.')
                        {
                            iloscKropek++;
                            if (iloscKropek > 1) throw new Exception("("+linia+":"+znak+") Nieprawidłowa liczba!");
                        }
                        wartosc += textToParse[actualTokenIndex];
                        actualTokenIndex++; znak++;
                    }

                    return new Token(TokenName.liczba, wartosc);
                }

                //ident, for, begin, end, funkcje
                if(Char.IsLetter(textToParse[actualTokenIndex]))
                {
                    string wartosc = "";

                    //TODO

                    return new Token(TokenName.ident, wartosc);
                }

                throw new Exception("(" + linia + ":" + znak + ") Nieobługiwany znak: '"+textToParse[actualTokenIndex]+"' !");

            }

            return null;
        }

        /// <summary>
        /// Zwraca wszystkie tokeny
        /// </summary>
        /// <returns>Lista tokenów</returns>
        public List<Token> GetAllTokens()
        {
            actualTokenIndex = 0; linia = 0; znak = 0;
            List<Token> tokens = new List<Token>();
            Token token;
            while ((token = GetNextToken()) != null)
                tokens.Add(token);

            return tokens;
        }

        /// <summary>
        /// Odczyt string z pliku
        /// </summary>
        /// <param name="fileName">Nazwa pliku</param>
        /// <returns>Zawatrość pliku w string</returns>
        private string LoadStringFromFile(string fileName)
        {
            string zawartosc = "";
            StreamReader sr = new StreamReader(fileName);
            zawartosc = sr.ReadToEnd();
            sr.Close();
            return zawartosc;
        }
    }
}
