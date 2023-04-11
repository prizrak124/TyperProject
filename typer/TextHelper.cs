using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer
{
    public static class TextHelper
    {
        private static char _Dq = '\"';
        private static char _Sq = '\'';

        public static char GetSymbol(char symbol)
        {
            if ( (symbol >= 8216 && symbol <= 8219)||
                 (symbol == 8242 || symbol == 8245) ) return _Sq;

            else if ( (symbol >= 8220 && symbol <= 8223)||
                      (symbol == 8243 || symbol == 8246) ) return _Dq;
            
            else return symbol;
           
        }
    }
}
