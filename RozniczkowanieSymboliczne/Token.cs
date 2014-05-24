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
        przecinek, Lnawias, Pnawias, hash,
        sinFun, cosFun, tgFun, ctgFun, logFun, expFun,
        ident, liczba, 
        forSem, endSem, dwukropek, opRowne, nowaLinia
    }; 

    /// <summary>
    /// Struktura tokenu
    /// </summary>
    class Token : ICloneable
    {
        public TokenName Nazwa { set; get; }
        public string Wartosc { set; get; }
        public int Linia { set; get; }
        public int Znak { set; get; }

        public Token(TokenName _tokenName, string _wartosc, int _linia, int _znak)
        {
            Nazwa = _tokenName;
            Wartosc = _wartosc;
            Linia = _linia;
            Znak = _znak;
        }

        public object Clone()
        {
            return new Token(Nazwa,Wartosc,Linia,Znak);
        }
    }
}
