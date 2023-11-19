using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNR1_Rynkiewicz63305
{
    internal static class EkstremumSzeregu
    {
        // deklaracja dwóch metod statycznych 
        public static float MinSX(float[,] TWS)
        {
            // deklaracja pomocnicza, dla pierwszego elementuy, ktorego sie szuka
            float AktualneMin;
            AktualneMin = TWS[0, 1];
            // analiza TWS i szukanie wartości minimalnej S(x)
            for (int i = 0; i < TWS.GetLength(0); i++)
                if (AktualneMin > TWS[i, 1])
                    // zostal znaleziomy element mniejszy od aktualnego
                    // przypisanie temu elementowi nowej wartości
                    AktualneMin = TWS[i, 1];
            // zwrotne przekazanie wartości minimalnej szeregu
            return AktualneMin;
        }
        public static float drMinSX(float[,] drTWS)
        {
            // deklaracja pomocnicza, dla pierwszego elementuy, ktorego sie szuka
            float drAktualneMin;
            drAktualneMin = drTWS[0, 1];
            // analiza TWS i szukanie wartości minimalnej S(x)
            for (int i = 0; i < drTWS.GetLength(0); i++)
                if (drAktualneMin > drTWS[i, 1])
                    // zostal znaleziomy element mniejszy od aktualnego
                    // przypisanie temu elementowi nowej wartości
                    drAktualneMin = drTWS[i, 1];
            // zwrotne przekazanie wartości minimalnej szeregu
            return drAktualneMin;
        }
        public static float MaxSX(float[,] TWS)
        {
            // deklaracja zmiennych pomocniczych
            float AktualneMax;
            // ustalenie stanu poczatkowego
            AktualneMax = TWS[0, 1];
            // analiza TWS 
            for (int i = 0; i < TWS.GetLength(0); i++)
                if (AktualneMax < TWS[i, 1])
                    AktualneMax = TWS[i, 1];
            return AktualneMax;
        }
        public static float drMaxSX(float[,] drTWS)
        {
            // deklaracja zmiennych pomocniczych
            float drAktualneMax;
            // ustalenie stanu poczatkowego
            drAktualneMax = drTWS[0, 1];
            // analiza TWS 
            for (int i = 0; i < drTWS.GetLength(0); i++)
                if (drAktualneMax < drTWS[i, 1])
                    drAktualneMax = drTWS[i, 1];
            return drAktualneMax;
        }
    }
}
