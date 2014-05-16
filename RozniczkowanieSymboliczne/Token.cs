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
        sinFun, cosFun, tgFun, ctgFun, logFun,
        ident, liczba
    }; 

    /// <summary>
    /// Struktura tokenu
    /// </summary>
    class Token
    {
        TokenName Nazwa { set; get; }
        String Wartosc { set; get; }
    }
}
