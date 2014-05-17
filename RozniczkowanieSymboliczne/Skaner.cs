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
        private int linia = 1;
        private int znak = 1;

        public Skaner(string textOrFileName, Mode mode)
        {
            if (mode != Mode.File) textToParse = textOrFileName+"\n";
            else textToParse = LoadStringFromFile(textOrFileName)+"\n";
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
                if (textToParse[actualTokenIndex] == '\n') 
                { 
                    linia++; znak = 0;
                    actualTokenIndex++;
                    return new Token(TokenName.nowaLinia, "\n", linia, znak);
                }
                else znak++;
                actualTokenIndex++;
            }

            if (actualTokenIndex != textToParse.Length)
            {
                //Jednoelementowe
                if (textToParse[actualTokenIndex] == '-') { actualTokenIndex++; znak++; return new Token(TokenName.opMinus, "-", linia, znak); }
                if (textToParse[actualTokenIndex] == '+') { actualTokenIndex++; znak++; return new Token(TokenName.opPlus, "+", linia, znak); }
                if (textToParse[actualTokenIndex] == '*') { actualTokenIndex++; znak++; return new Token(TokenName.opMnozenie, "*", linia, znak); }
                if (textToParse[actualTokenIndex] == '/') { actualTokenIndex++; znak++; return new Token(TokenName.opDzielenie, "/", linia, znak); }
                if (textToParse[actualTokenIndex] == '^') { actualTokenIndex++; znak++; return new Token(TokenName.opPotega, "^", linia, znak); }
                if (textToParse[actualTokenIndex] == ',') { actualTokenIndex++; znak++; return new Token(TokenName.przecinek, ",", linia, znak); }
                if (textToParse[actualTokenIndex] == ':') { actualTokenIndex++; znak++; return new Token(TokenName.dwukropek, ":", linia, znak); }
                if (textToParse[actualTokenIndex] == '(') { actualTokenIndex++; znak++; return new Token(TokenName.Lnawias, "(", linia, znak); }
                if (textToParse[actualTokenIndex] == ')') { actualTokenIndex++; znak++; return new Token(TokenName.Pnawias, ")", linia, znak); }
                if (textToParse[actualTokenIndex] == '=') { actualTokenIndex++; znak++; return new Token(TokenName.opRowne, "=", linia, znak); }

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
                            if (iloscKropek > 1) throw new Exception("(" + linia + ":" + znak + ") Nieprawidłowa liczba '" + wartosc + textToParse[actualTokenIndex] + "' !");
                        }
                        wartosc += textToParse[actualTokenIndex];
                        actualTokenIndex++; znak++;
                    }
                    if(actualTokenIndex != textToParse.Length && Char.IsLetter(textToParse[actualTokenIndex]))
                        throw new Exception("(" + linia + ":" + znak + ") Nieprawidłowa liczba '"+wartosc+textToParse[actualTokenIndex]+"' !");

                    return new Token(TokenName.liczba, wartosc, linia, znak);
                }

                //ident, for, begin, end, funkcje
                if(Char.IsLetter(textToParse[actualTokenIndex]))
                {
                    //tg
                    if (actualTokenIndex + 1 < textToParse.Length && textToParse.Substring(actualTokenIndex, 2).Equals("tg")
                        && (actualTokenIndex + 2 == textToParse.Length || textToParse[actualTokenIndex + 2] == '('))
                    {
                        actualTokenIndex += 2; znak += 2;
                        return new Token(TokenName.tgFun, "tg", linia, znak);
                    }

                    //dlugosc 3
                    if (actualTokenIndex + 2 < textToParse.Length)
                    {
                        //spacja po nazwie
                        if (actualTokenIndex + 3 == textToParse.Length || Char.IsWhiteSpace(textToParse[actualTokenIndex + 3]))
                        {
                            //for
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("for"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.forSem, "for", linia, znak);
                            }
                            //end
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("end"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.endSem, "end", linia, znak);
                            }
                        }

                        //nawias po nazwie
                        if (actualTokenIndex + 3 == textToParse.Length || textToParse[actualTokenIndex + 3] == '(')
                        {
                            //sin
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("sin"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.sinFun, "sin", linia, znak);
                            }
                            //cos
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("cos"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.cosFun, "cos", linia, znak);
                            }

                            //ctg
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("ctg"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.ctgFun, "ctg", linia, znak);
                            }
                            //log
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("log"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.logFun, "log", linia, znak);
                            }
                            //log
                            if (textToParse.Substring(actualTokenIndex, 3).Equals("exp"))
                            {
                                actualTokenIndex += 3; znak += 3;
                                return new Token(TokenName.expFun, "exp", linia, znak);
                            }
                        }                        
                    }

                    //begin
                    if (actualTokenIndex + 4 < textToParse.Length && textToParse.Substring(actualTokenIndex, 5).Equals("begin")
                        && (actualTokenIndex + 5 == textToParse.Length || Char.IsWhiteSpace(textToParse[actualTokenIndex + 5])))
                    {
                        actualTokenIndex += 5; znak += 5;
                        return new Token(TokenName.beginSem, "begin", linia, znak);
                    }

                    //ident
                    string wartosc = "";
                    while (actualTokenIndex < textToParse.Length && Char.IsLetter(textToParse[actualTokenIndex]))
                    {
                        wartosc += textToParse[actualTokenIndex];
                        actualTokenIndex++; znak++;
                    }
                    if (actualTokenIndex != textToParse.Length)
                    {
                        if (textToParse[actualTokenIndex] == '(') throw new Exception("(" + linia + ":" + znak + ") Nierozpoznana funkcja: '" + wartosc + "' !");
                        if (Char.IsNumber(textToParse[actualTokenIndex])) throw new Exception("(" + linia + ":" + znak + ") Niedozwolony identyfikator: '" + wartosc + textToParse[actualTokenIndex] + "' !");
                    }

                    return new Token(TokenName.ident, wartosc, linia, znak);
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
            actualTokenIndex = 0; linia = 1; znak = 1;
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
