using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace ProjectNR1_Rynkiewicz63305
{
    public partial class ProjektNr1_Rynkiewicz63305 : Form
    {
        // ---------------------------------deklaracja stałych
        const int drMargines = 10;
        const int drPromieńOA = 5; // promien obiektu animowanego :D
        const float drDGprzedziałuX = float.MinValue;
        const float drGGprzedziałuX = float.MaxValue;
        Graphics drRysownica;
        Pen drPióroXY, drPióroLiniiToru;
        float[,] drTWS;
        int drIndexPOA; // index połozenia obiektu animacji
        int drMaxIndexPOA;
        public float drXd, drXg;
        public float drH;
        int drLiczbaPrzedziałówH;
        static ProjektNr1_Rynkiewicz63305 drUchwytFormularza;

        // deklaracja stałych----------------------------------
        public ProjektNr1_Rynkiewicz63305()
        {
            InitializeComponent();
            drUchwytFormularza = this;
            drPióroLiniiToru = new Pen(Color.Black, 1.5F);
            // ustawienie linii kropkowej
            drPióroLiniiToru.DashStyle = DashStyle.Dot;
            // wsptepne sformatowanie kontrolki PictureBox
            drpbRysownica.BackColor = Color.LightGreen;
            drpbRysownica.BorderStyle = BorderStyle.Fixed3D;
            // pobranie Bitmapy i podpięcie jej pod kontrolke PicureBox
            drpbRysownica.Image = new Bitmap(drpbRysownica.Width, drpbRysownica.Height);
            // utworzenie egzemplarza powierzchni graficznej na Bitmapie
            drRysownica = Graphics.FromImage(drpbRysownica.Image);
            drPióroXY = new Pen(Color.Blue, 0.5F);
            drPióroXY.StartCap = LineCap.Flat;
            drPióroXY.EndCap = LineCap.ArrowAnchor;
            // ustalenie dużych grotów linii
            AdjustableArrowCap dużeGrotyStrzałek = new AdjustableArrowCap(3, 5);
            drPióroXY.StartCap = LineCap.Square;
            drPióroXY.CustomEndCap = dużeGrotyStrzałek;
            drPióroLiniiToru = new Pen(Color.Black, 1.5F);
            drPióroLiniiToru.DashStyle = DashStyle.Dot;
        }
        private void drpbRysownica_Paint(object sender, PaintEventArgs e)
        {
            // dodatkowe zabezpiecnzie gdy TWS jest puste
            if (drTWS is null)
                return;
            // wymazanie obrazu animacji
            drRysownica.Clear(Color.LightSeaGreen);
            // wykreślenie osi Y
            drRysownica.DrawLine(drPióroXY,
                drPrzeliczanieWspółrzędnych.WspX(0),
                drPrzeliczanieWspółrzędnych.WspY(drPrzeliczanieWspółrzędnych.Ymin),
                drPrzeliczanieWspółrzędnych.WspX(0),
                drPrzeliczanieWspółrzędnych.WspY(drPrzeliczanieWspółrzędnych.Ymax));
            //wykreślenie osi X
            drRysownica.DrawLine(drPióroXY,
                drPrzeliczanieWspółrzędnych.WspX(drPrzeliczanieWspółrzędnych.Xmin),
                drPrzeliczanieWspółrzędnych.WspY(0),
                drPrzeliczanieWspółrzędnych.WspX(drPrzeliczanieWspółrzędnych.Xmax),
                drPrzeliczanieWspółrzędnych.WspY(0));
            //wykreślenie linii toru
            for (int j = 0; j < drTWS.GetLength(0) - 1; j++)
                drRysownica.DrawLine(drPióroLiniiToru,
                    drPrzeliczanieWspółrzędnych.WspX(drTWS[j, 0]),
                    drPrzeliczanieWspółrzędnych.WspY(drTWS[j, 1]),
                    drPrzeliczanieWspółrzędnych.WspX(drTWS[j + 1, 0]),
                    drPrzeliczanieWspółrzędnych.WspY(drTWS[j + 1, 1]));
            // wykreślenie Obiektu Animowanego w nowym położeniu okreslonym przez IndexPOA
            drRysownica.FillEllipse(Brushes.Pink,
                drPrzeliczanieWspółrzędnych.WspX(drTWS[drIndexPOA, 0]) - drPromieńOA,
                drPrzeliczanieWspółrzędnych.WspY(drTWS[drIndexPOA, 1]) - drPromieńOA,
                2 * drPromieńOA, 2 * drPromieńOA);
        }
        void drTablicowanieWartościSzeregu(float[,] drTWS, float drXd, float drXg, float  drH)
        {
            // deklaracje pomocnicze
            float X;
            int i; // licznik podprzedziałów 'h'
            for (X = drXd, i = 0; i < drTWS.GetLength(0); X = drXd + i * drH, i++)
            {
                // wpisanie do i-tego wiersza TWS wartości X oraz wartości szeregu (x)
                drTWS[i, 0] = X;
                drTWS[i, 1] = drObliczenieWartościSzeregu(X);
            }
        }
        float drObliczenieWartościSzeregu(float X)
        {
           // w0 - wartość poczatkowa = ?
             //* wK - wartość końcowa = wK-1 * R

            const float Eps = 0.00000001F;
            int k;
            float w, S;
            // ustalenie początkowego stanu obliczeń
            k = 0;
            w = 1.0f;
            S = w;
            // itereacyjne obliczanie sumy wyrazów szeregu
            while (Math.Abs(w) > Eps)
            {
                // zwiększenie licznika wyrazów szeregu
                k++;
                // obliczenie wartości końcowej k-tego wyrazu wartości szeregu
                w = w * (((1 + (1/k))* (1+ (1/ k))*
                    (1 + (1 / k))* (1+ (1/ k))*
                    (1 + (1 / k)))*(((X + 5)* (X + 5)))) / (float)(k * (1 + (1 / k)));
                // obliczenie sumy k wyrazów
                S = S + w;
            }
            // zwrotne przekazanie wyników obliczeń
            return S;
        }
        bool drPobierzDaneWejściowe(out float drXd, out float drXg, out float drH)
        {
            // zwrotne przekazanie true gdy nie bylo bledu
            // pomocnicze przekazanie tzw. wartosci technicznych dla parametrow wyjsciowych
            drXg = drH = 0.0F;
            if (!float.TryParse(drtxtXd.Text, out drXd))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(drtxtXd, "ERROR: w podanym zapisie wartości " +
                    "wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie czy Xd mieści się w przedziale zbieżności szeregu
            if ((drXd < drDGprzedziałuX) || (drXd > drGGprzedziałuX))
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(drtxtXd, "ERROR: w zapisie wartości Xd, wystąpił " +
                    "niedozwolony znak");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(drtxtXg.Text, out drXg))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(drtxtXg, "ERROR: w podanym zapisie wartości " +
                    "wystąpił niedozwolony znak ");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie czy Xg mieści się w przedziale zbieżności szeregu
            if ((drXg < drDGprzedziałuX) || (drXg > drGGprzedziałuX))
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(drtxtXg, "ERROR: w zapisie wartości Xg, wystąpił " +
                    "niedozwolony znak ");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // sprawdzenie tzw. warunku wejsciowego (logicznego) nakładanego na granicę przedziału
            // zmiany wartości zmiennej X 
            if (drXd > drXg)
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(drtxtXg, "ERROR: nie jest spełniony " +
                    "tzw. warunek wejściowy nałożony na granicę " +
                    "zmian wartości zmiennej X ");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // pobranie H
            if (!float.TryParse(drtxtH.Text, out drH))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(drtxtH, "ERROR: w podanym zapisie wartości " +
                    "przyrostu H wystąpił niedozwolony znak! ");
                // przerwanie pobierania danych
                return false;
            }
            if ((drH < 0.0F) || (drH > 1.0F))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(drtxtH, "ERROR: Podana wartość przyrostu H " +
                    "nie spełnia warunku wejściowego!: " +
                    "0 < H < 1 ");
                // przerwanie pobierania danych
                return false;
            }
            // zwrotne przekazanie wartości 'true' gdy nie było błędów
            return true;
        }
        private void drbtnAnimacja_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolkiu error provider
            errorProvider1.Dispose();
            // pobranie danych z formularza txtXd, txtXg, txtH :D
            if (!drPobierzDaneWejściowe(out drXd, out drXg, out drH))
            {
                // sygnaizacaj błedu
                errorProvider1.SetError(drtxtXd, "ERROR: wystąpił niedozwolony " +
                    "znak w podanej wartości Xd ");
                return;
            }
            drLiczbaPrzedziałówH = (int)((drXg - drXd) / drH) + 1;
            // utowrzenie TWS
            drTWS = new float[drLiczbaPrzedziałówH, 2]; // (liczba wierszy oraz liczba kolumn)
            // tablicowanie wartości szeregu
            drTablicowanieWartościSzeregu(drTWS, drXd, drXg, drH); // wywołanie metody
            // ustalenie początkowego położenia OA (obiektu animacji)
            drIndexPOA = 0;
            // ustalnie koncowego polozenia OA (Obiektu Animacji)
            drMaxIndexPOA = drTWS.GetLength(0) - 1; // 0 liczba wierszy// 1 liczba kolumn
            // uruchomienie zegara
            timer1.Enabled = true;
            // ustalenie stanu braku aktywnosci przycisku animacji
            drbtnAnimacja.Enabled = false;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //deklaracje obslugi dzialania zegarka
            // sprawdzenie czy obiekt animowany doszedł do prawej krawędzi p[owierzchni graficznej
            if (drIndexPOA >= drMaxIndexPOA)
                // przestawienie Obiektu Animowanego na początek linii toru
                drIndexPOA = 0;
            else
                drIndexPOA++;
            // teraz musi nastąpić odrysowanie obrazu poa na bitmapie
            drpbRysownica.Refresh();
        }
        private void ProjektNr1_Rynkiewicz63305_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy chcesz zamknąć bieżący formularz "
            + "i powrócić do formularza głównego? " + "(Możesz utracić danę o ile ich nie zapiszesz!) ",
            this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // sprawdzenie odpowiedzi użytkowika
            if (OknoMessage == DialogResult.Yes)
            {
                // odszukanie formularza w kolekcji openForms
                foreach (Form Formularz in Application.OpenForms)
                    if (Formularz.Name == "Kokpit_Rynkiewicz63305")
                    {
                        this.Hide();
                        Formularz.Show();
                        //zakończenie obsługi zadrzenia
                        return;
                    }
                MessageBox.Show("Awaria: Ktoś usunął egzemplarz formularza głównego ",
                    this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // zamknięcie wszystkich formularzy i wąątków
                Application.ExitThread();
            }
            else
                // usunięcie zdarzenia zamkniecia formularza
                e.Cancel = true;
        }

        private void drbtnReset_Click(object sender, EventArgs e)
        {
            drtxtXd.Clear();
            drtxtXg.Clear();
            drtxtH.Clear();
            // wyczyszczenie i odblokowanie pól
            drtxtXd.Enabled = true;
            drtxtXg.Enabled = true;
            drtxtH.Enabled = true;

            // Odkrycie przycisków dla tablicy TWS i wykresu graficznego
            drbtnWizualizacjaTabelaryczna.Enabled = true;
            drbtnWizualizacjaGraficzna.Enabled = true;
            // ukrycie Tablicy TWS i Wykresu szeregu
            //---------------------------------------------------------------------------------------
            //drdataGridView1.Visible = false;
            //drchtWykresSzeregu.Visible = false;
            //---------------------------------------------------------------------------------------
            // zgaszenie kontrolki errorProvider1
            errorProvider1.Dispose();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        static class drPrzeliczanieWspółrzędnych
        {
            // deklaracja zmiennych przechowujących wartości
            // wspolczynników skali po osi X i Y oraz przesunięcia wzdłuż
            // osi X i osi Y
            static float Sx, Sy;
            static float Dx, Dy;
            // deklaracja zmiennych opisujących rozmiar powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            // deklaracja właściwości opisujacych rozmiar powierzchni rzeczywisitej
            static public float Xmin
            {
                get;
                private set;
            }
            static public float Xmax
            {
                get;
                private set;
            }
            static public float Ymin
            {
                get;
                private set;
            }
            static public float Ymax
            {
                get;
                private set;
            }
            // wyznaczenie rozmiarów i współczynników 
            // deklaracja konstruktora klasy statycznej
            static drPrzeliczanieWspółrzędnych()
            {
                // określenie rozmiarów powierzchni rzeczywistej 
                Xmin = drUchwytFormularza.drXd;
                Xmax = drUchwytFormularza.drXg;
                Ymin = EkstremumSzeregu.drMinSX(drUchwytFormularza.drTWS);
                Ymax = EkstremumSzeregu.drMaxSX(drUchwytFormularza.drTWS);
                // wyznacznenie rozmiaru powierzchni graficznej na formularzu (kontrolka PictureBox)
                Xe_min = drMargines;
                Xe_max = drUchwytFormularza.drpbRysownica.Width - (drMargines + drMargines);
                Ye_min = drMargines;
                Ye_max = drUchwytFormularza.drpbRysownica.Height - (drMargines + drMargines);
                // wyznaczenie wspolczynników skali Sx i Sy:
                Sx = (Xe_max - Xe_min) / (Xmax - Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax - Ymin);
                // oblicznenie przesunięć 
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sy;
                // koniec deklaracji 
            } // deklaracja publicznych metod WspX i WspY
            public static int WspX(float X)
            {
                return (int)(Sx * X + Dx);
            }
            public static int WspY(float Y)
            {
                return (int)(Sy * Y + Dy);
            }
        }
    }
}

