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

            return null;
        }

        /// <summary>
        /// Zwraca wszystkie tokeny
        /// </summary>
        /// <returns>Lista tokenów</returns>
        public List<Token> GetAllTokens()
        {
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
