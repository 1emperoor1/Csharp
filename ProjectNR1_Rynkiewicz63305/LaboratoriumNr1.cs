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
        Graphics Rysownica;
        Pen PióroXY = new Pen(Color.Red, 0.5f);
        Pen PióroLiniiToru;
        float[,] TWS;
        int IndexPOA; // index połozenia obiektu animacji
        int MaxIndexPOA;
        float Xd, Xg, H;
        static LaboratoriumNr1 UchwytFormularza;

        public LaboratoriumNr1()
        {
            InitializeComponent();
            UchwytFormularza = this;
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
            for (int j = 0; j < TWS.GetLength(0) - 1; j++)
                Rysownica.DrawLine(PióroLiniiToru,
                    PrzeliczanieWspółrzędnych.WspX(TWS[j, 0]),
                    PrzeliczanieWspółrzędnych.WspY(TWS[j, 1]),
                    PrzeliczanieWspółrzędnych.WspX(TWS[j + 1, 0]),
                    PrzeliczanieWspółrzędnych.WspY(TWS[j + 1, 1]));
            // wykreślenie Obiektu Animowanego w nowym położeniu okreslonym przez IndexPOA
            Rysownica.FillEllipse(Brushes.Pink,
                PrzeliczanieWspółrzędnych.WspX(TWS[IndexPOA, 0]) - PromieńOA,
                PrzeliczanieWspółrzędnych.WspY(TWS[IndexPOA, 1]) - PromieńOA,
                2 * PromieńOA, 2 * PromieńOA);
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

