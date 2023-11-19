using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNR1_Rynkiewicz63305
{
    internal class EkstremumSzeregu
    {
        // deklaracja dwóch metod statycznych 
        public static float MinSX(float[,] TWS)
        {
            // deklaracja pomocnicza, dla pierwszego elementuy, ktorego sie szuka
            float AktualneMin;
            AktualneMin = TWS[0, 1];
            // analiza TWS i szukanie wartości minimalnej S(x)
            for (int i = 0; i < TWS.Length; i++)
                if (AktualneMin > TWS[i, 1])
                    // zostal znaleziomy element mniejszy od aktualnego
                    // przypisanie temu elementowi nowej wartości
                    AktualneMin = TWS[i, 1];
            // zwrotne przekazanie wartości minimalnej szeregu
            return AktualneMin;
        }
        public static float MaxSX(float[,] TWS)
        {
            // deklaracja zmiennych pomocniczych
            float AktualneMax;
            // ustalenie stanu poczatkowego
            AktualneMax = TWS[0, 1];
            // analiza TWS 
            for (int i = 0; i < TWS.Length; i++)
                if (AktualneMax < TWS[i, 1])
                    AktualneMax = TWS[i, 1];
            return AktualneMax;
        }
    }
}
