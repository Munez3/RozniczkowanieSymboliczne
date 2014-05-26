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
            Skaner skaner = new Skaner(wyrazenie, Mode.Line);
            Element uporzadkowany = new Elem_Plus(null);
            uporzadkowany.Dzieci.Add(GeneratorKodu.wygenerujElement(skaner.GetAllTokens()));
            PorzadkujElement(uporzadkowany);
            return uporzadkowany.Wyrazenie;
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
                else if (dziecko.GetType() == typeof(Elem_Plus)) { }
                else if (dziecko.GetType() == typeof(Elem_Razy)) { }
                else if (dziecko.GetType() == typeof(Elem_Potega)) { }
                else { }
            }
        }
    }
}
