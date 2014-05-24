using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    interface Element
    {
        List<Element> Dzieci { set; get; }
        List<Token> Tokeny { set; get; }
        string Wyrazenie { set; get; }
        string Pochodna { set; get; }

        /// <summary>
        /// Tworzy listę dzieci
        /// </summary>
        void rozbijNaDzieci();

        /// <summary>
        /// Wylicza pochodną
        /// </summary>
        void WyliczPochodna(string identPoKtorymPochodniujemy);
    }
}
