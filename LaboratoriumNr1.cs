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
    public partial class LaboratoriumNr1 : Form
    {
        // deklaracja stałych
        const int Margines = 10;
        const int PromieńOA = 5; // promien obiektu animowanego :D
        const float DGprzedziałuX = float.MinValue;
        const float GGprzedziałuX = float.MaxValue;
        Graphics Rysownica;
        Pen PióroXY, PióroLiniiToru;
        float[,] TWS;
        int IndexPOA; // index połozenia obiektu animacji
        int MaxIndexPOA;
        public float Xd, Xg;
        float H;
        int LiczbaPrzedziałówH;
        static LaboratoriumNr1 UchwytFormularza;
        // deklaracja stalych 
        public LaboratoriumNr1()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Left + Margines,
                Screen.PrimaryScreen.Bounds.Top + Margines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.7F);
            this.StartPosition = FormStartPosition.Manual;
            UchwytFormularza = this;
            this.MinimizeBox = false;
            // deklaracja pióra
            PióroLiniiToru = new Pen(Color.Black, 1.5F);
            // ustawienie linii kropkowej
            PióroLiniiToru.DashStyle = DashStyle.Dot;
            // wsptepne sformatowanie kontrolki PictureBox
            pbRysownica.BackColor = Color.LightGreen;
            pbRysownica.BorderStyle = BorderStyle.Fixed3D;
            // pobranie Bitmapy i podpięcie jej pod kontrolke PicureBox
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            // utworzenie egzemplarza powierzchni graficznej na Bitmapie
            Rysownica = Graphics.FromImage(pbRysownica.Image);
            PióroXY = new Pen(Color.Blue, 0.5F);
            PióroXY.StartCap = LineCap.Flat;
            PióroXY.EndCap = LineCap.ArrowAnchor;
            // ustalenie dużych grotów linii
            AdjustableArrowCap dużeGrotyStrzałek = new AdjustableArrowCap(3, 5);
            PióroXY.StartCap = LineCap.Square;
            PióroXY.CustomEndCap = dużeGrotyStrzałek;
            PióroLiniiToru = new Pen(Color.Black, 1.5F);
            PióroLiniiToru.DashStyle = DashStyle.Dot;
        }
        private void LaboratoriumNr1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy chcesz zamknąć bieżący formularz"
            + "i powrócić do formularza głównego?" + "(Możesz utracić danę o ile ich nie zapiszesz!)",
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
                MessageBox.Show("Awaria: Ktoś usunął egzemplarz formularza głównego",
                    this.Text, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // zamknięcie wszystkich formularzy i wąątków
                Application.ExitThread();
            }
            else
                // usunięcie zdarzenia zamkniecia formularza
                e.Cancel = true;
        }
         private void pbRysownica_Paint(object sender, PaintEventArgs e)
        {
            // dodatkowe zabezpiecnzie gdy TWS jest puste
            if (TWS is null)
                return;
            // wymazanie obrazu animacji
            Rysownica.Clear(Color.LightSeaGreen);
            // wykreślenie osi Y
            Rysownica.DrawLine(PióroXY,
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymin),
                PrzeliczanieWspółrzędnych.WspX(0),
                PrzeliczanieWspółrzędnych.WspY(PrzeliczanieWspółrzędnych.Ymax));
            //wykreślenie osi X
            Rysownica.DrawLine(PióroXY,
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmin),
                PrzeliczanieWspółrzędnych.WspY(0),
                PrzeliczanieWspółrzędnych.WspX(PrzeliczanieWspółrzędnych.Xmax),
                PrzeliczanieWspółrzędnych.WspY(0));
            //wykreślenie linii toru
            for (int j = 0; j < TWS.GetLength(0)-1; j++)
                Rysownica.DrawLine(PióroLiniiToru,
                    PrzeliczanieWspółrzędnych.WspX(TWS[j, 0]),
                    PrzeliczanieWspółrzędnych.WspY(TWS[j, 1]),
                    PrzeliczanieWspółrzędnych.WspX(TWS[j+1, 0]),
                    PrzeliczanieWspółrzędnych.WspY(TWS[j+1, 1]));
            // wykreślenie Obiektu Animowanego w nowym położeniu okreslonym przez IndexPOA
            Rysownica.FillEllipse(Brushes.Pink,
                PrzeliczanieWspółrzędnych.WspX(TWS[IndexPOA, 0]) - PromieńOA,
                PrzeliczanieWspółrzędnych.WspY(TWS[IndexPOA, 1]) - PromieńOA,
                2 * PromieńOA, 2 * PromieńOA);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        // deklaracje metod pomocniczych 
        void TablicowanieWartościSzeregu (float [,] TWS, float Xd, float Xg, float H)
        {
            // deklaracje pomocnicze
            float X;
            int i; // licznik podprzedziałów 'h'
            for (X = Xd, i = 0; i < TWS.GetLength(0); X = Xd + i * H, i++)
            {
                // wpisanie do i-tego wiersza TWS wartości X oraz wartości szeregu (x)
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczenieWartościSzeregu(X);
            }
        }
        float ObliczenieWartościSzeregu (float X)
        {
            /* w0 - wartość poczatkowa = ?
             * wK - wartość końcowa = wK-1 * R
             * s(x) = E (-1)^k ((x^2k+1)/(2k+1)!)
             * w0 = X
             * r = wK / wK-1 = (-1)^k* ((x^2k+1)/(2k+1)!) //
             *                  (-1)^k-1* ((x^2k-1)+1 / ((2k-1)+1)!)
             *                  (-1)* ((2k-1)!)/(2k+1)!  x^(2k-1)
             *                  wK = wK-1 * (-1) * (x^2)/(2k(2k+1))
             */
            // deklaracje pomocnicze
            const float Eps = 0.0000001F;
            int k;
            float w, S;
            // ustalenie początkowego stanu obliczeń
            k = 0;
            w = 1;
            S = w;
            // itereacyjne obliczanie sumy wyrazów szeregu
            while (Math.Abs(w) > Eps)
            {
                // zwiększenie licznika wyrazów szeregu
                k++;
                // obliczenie wartości końcowej k-tego wyrazu wartości szeregu
                w = w * ((-1.0F) * X * X) /(float)(2 * k * (2 * k + 1));
                // obliczenie sumy k wyrazów
                S = S + w;
            }
            // zwrotne przekazanie wyników obliczeń
            return S;
        }
        bool PobierzDaneWejściowe(out float Xd, out float Xg, out float H)
        {
            // zwrotne przekazanie true gdy nie bylo bledu
            // pomocnicze przekazanie tzw. wartosci technicznych dla parametrow wyjsciowych
            Xd = Xg = H = 0.0F;
            if (!float.TryParse(txtXd.Text, out Xd))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(txtXd, "ERROR: w podanym zapisie wartości " +
                    "wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie czy Xd mieści się w przedziale zbieżności szeregu
            if ((Xd < DGprzedziałuX) || (Xd > GGprzedziałuX))
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(txtXd, "ERROR: w zapisie wartości Xd, wystąpił " +
                    "niedozwolony znak");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(txtXg.Text, out Xg))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(txtXg, "ERROR: w podanym zapisie wartości " +
                    "wystąpił niedozwolony znak");
                // przerwanie pobierania danych
                return false;
            }
            // sprawdzenie czy Xg mieści się w przedziale zbieżności szeregu
            if ((Xg < DGprzedziałuX) || (Xg > GGprzedziałuX))
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(txtXg, "ERROR: w zapisie wartości Xg, wystąpił " +
                    "niedozwolony znak");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // sprawdzenie tzw. warunku wejsciowego (logicznego) nakładanego na granicę przedziału
            // zmiany wartości zmiennej X 
            if (Xd > Xg)
            {
                // sygnalizacja błędu, zapalenie kontrolki error provider
                errorProvider1.SetError(txtXg, "ERROR: nie jest spełniony " +
                    "tzw. warunek wejściowy nałożony na granicę " +
                    "zmian wartości zmiennej X");
                // przerywamy dalsze pobieranie danych wejsciowych
                return false;
            }
            // pobranie H
            if (!float.TryParse(txtH.Text, out H))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(txtH, "ERROR: w podanym zapisie wartości " +
                    "przyrostu H wystąpił niedozwolony znak! ");
                // przerwanie pobierania danych
                return false;
            }
            if ((H < 0.0F) || (H  > 1.0F))
            {
                // sygnalizacja błedu 
                errorProvider1.SetError(txtH, "ERROR: Podana wartość przyrostu H " +
                    "nie spełnia warunku wejściowego!: " + 
                    "0 < H < 1 ");
                // przerwanie pobierania danych
                return false;
            }
            // zwrotne przekazanie wartości 'true' gdy nie było błędów
            return true;
        }
        private void btnAnimacja_Click(object sender, EventArgs e)
        {
            // zgaszenie kontrolkiu error provider
            errorProvider1.Dispose();
            // pobranie danych z formularza txtXd, txtXg, txtH :D
            if (!PobierzDaneWejściowe(out Xd, out Xg, out H))
            {
                // sygnaizacaj błedu
                errorProvider1.SetError(txtXd, "ERROR: wystąpił niedozwolony" +
                    "znak w podanej wartości Xd");
                return;
            }
            LiczbaPrzedziałówH = (int)((Xg - Xd) / H) + 1;
            // utowrzenie TWS
            TWS = new float[LiczbaPrzedziałówH, 2]; // (liczba wierszy oraz liczba kolumn)
            // tablicowanie wartości szeregu
            TablicowanieWartościSzeregu(TWS, Xd, Xg, H); // wywołanie metody
            // ustalenie początkowego położenia OA (obiektu animacji)
            IndexPOA = 0;
            // ustalnie koncowego polozenia OA (Obiektu Animacji)
            MaxIndexPOA = TWS.GetLength(0) - 1; // 0 liczba wierszy// 1 liczba kolumn
            // uruchomienie zegara
            timer1.Enabled = true;
            // ustalenie stanu braku aktywnosci przycisku animacji
            btnAnimacja.Enabled = false;

        }
        private void LaboratoriumNr1_Load(object sender, EventArgs e)
        {
            // lokalizacja i zwymiarowanie kontrolki PictureBox
            pbRysownica.Location = new Point(this.Left + 10, this.Top + 90);
            pbRysownica.Width = (int)(this.Width * 0.75F);
            pbRysownica.Height = (int)(this.Height * 0.7F);
            // lokalizacja przycisku poleceń btnAnimacja
            btnAnimacja.Location = new Point(pbRysownica.Left +
                pbRysownica.Width + Margines, pbRysownica.Top);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //deklaracje obslugi dzialania zegarka
            // sprawdzenie czy obiekt animowany doszedł do prawej krawędzi p[owierzchni graficznej
            if (IndexPOA >= MaxIndexPOA)
                // przestawienie Obiektu Animowanego na początek linii toru
                IndexPOA = 0;
            else
                IndexPOA++;
            // teraz musi nastąpić odrysowanie obrazu poa na bitmapie
            pbRysownica.Refresh();
        }
        // deklaracja klasy statycznej ktora bedzie udostepniala metody ...
        // WspX(...) - wspolrzedna X
        // WspY(...) - wpsolrzedna Y
        static class PrzeliczanieWspółrzędnych
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
            static PrzeliczanieWspółrzędnych()
            {
                // określenie rozmiarów powierzchni rzeczywistej 
                Xmin = UchwytFormularza.Xd;
                Xmax = UchwytFormularza.Xg;
                Ymin = EkstremumSzeregu.MinSX(UchwytFormularza.TWS);
                Ymax = EkstremumSzeregu.MaxSX(UchwytFormularza.TWS);
                // wyznacznenie rozmiaru powierzchni graficznej na formularzu (kontrolka PictureBox)
                Xe_min = Margines;
                Xe_max = UchwytFormularza.pbRysownica.Width - (Margines + Margines);
                Ye_min = Margines;
                Ye_max = UchwytFormularza.pbRysownica.Height - (Margines + Margines);
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
        } // koniec deklaracji klasy statycznej 
    }
}

