using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozniczkowanieSymboliczne
{
    /// <summary>
    /// Tokeny
    /// </summary>
    public enum TokenName 
    { 
        opMinus, opPlus, opMnozenie, opDzielenie, opPotega, 
        przecinek, Lnawias, Pnawias, 
        sinFun, cosFun, tgFun, ctgFun, logFun, expFun,
        ident, liczba, 
        forSem, beginSem, endSem, dwukropek, opRowne, nowaLinia
    }; 

    /// <summary>
    /// Struktura tokenu
    /// </summary>
    class Token
    {
        public TokenName Nazwa { set; get; }
        public String Wartosc { set; get; }
        public int Linia { set; get; }
        public int Znak { set; get; }

        public Token(TokenName _tokenName, string _wartosc, int _linia, int _znak)
        {
            Nazwa = _tokenName;
            Wartosc = _wartosc;
            Linia = _linia;
            Znak = _znak;
        }
    }
}
