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
        // deklaracja stałych
        const int drMargines = 10;
        const int drPromieńOA = 5; // promien obiektu animowanego :D
        Graphics drRysownica;
        Pen drPióroXY = new Pen(Color.Red, 0.5f);
        Pen drPióroLiniiToru;
        float[,] drTWS;
        int drIndexPOA; // index połozenia obiektu animacji
        int drMaxIndexPOA;
        float drXd, drXg, drH;
        static LaboratoriumNr1 drUchwytFormularza;
        public ProjektNr1_Rynkiewicz63305()
        {
            InitializeComponent();
        }

        private void ProjektNr1_Rynkiewicz63305_FormClosing(object sender, FormClosingEventArgs e)
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
                // nie znaleziono takiego formularza - co wtedy?XD
                //else
                //{
                //    Form kokpitNR1 = new kokpitNR1();
                //    kokpitNR1.Show();
                //}
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
        //bool drPobranieDanych(float drXd, float drXg, float drH)
        //{
        //    drXd = drXg = drH = 0.0f;
        //    //if (!drPobranieDanych == true)
        //    if (!float.TryParse(drtxtXd.Text, out drXd))
        //    {
        //        // sygnalizacja błędu, zapalenie kontrolki error provider
        //        errorProvider1.SetError(drtxtXd, "ERROR: w zapisie wartości Xd, wystąpił" +
        //            "niedozwolony znak");
        //        // przerywamy dalsze pobieranie danych wejsciowych
        //        return false;
        //    }
        //    if ((drXd < drdgX) || (drXd > drggX))
        //    {
        //        // sygnalizacja błędu, zapalenie kontrolki error provider
        //        errorProvider1.SetError(drtxtXd, "ERROR: w zapisie wartości Xd, wystąpił" +
        //            "niedozwolony znak");
        //        // przerywamy dalsze pobieranie danych wejsciowych
        //        return false;
        //    }
        //    // pobranie drXg
        //    if (!float.TryParse(drtxtXg.Text, out drXg))
        //    {
        //        // sygnalizacja błędu
        //        errorProvider1.SetError(drtxtXg, "ERROR: w zapisie wartości Xg, wystąpił" +
        //            "niedozwolony znak");
        //        return false;
        //    }
        //    if ((drXg < drdgX) || (drXg > drggX))
        //    {
        //        errorProvider1.SetError(drtxtXg, "ERROR: w zapisie wartości Xg, wystąpił"
        //            + "niedozwolony znak");
        //    }
        //    // pobranie H
        //    if(!float.TryParse(drtxtH.Text, out drH))
        //    {
        //        // sygnalizacja błędu
        //        errorProvider1.SetError(drtxtH, "ERROR: w zapisie wartości Xg, wystąpił" +
        //            "niedozwolony znak");
        //        return false;
        //    }
        //    if (drXd > drXg)
        //    {
        //        // sygnalizacja błędu
        //        errorProvider1.SetError(drtxtXg, "ERROR: podane wartości Xd oraz Xg" +
        //            "zostały wpisane w odwrotnej kolejności: {Xg, Xd}");
        //        return false;
        //    }
        //    // ustawienie stanu braku aktywnosci dla kontrolek TxtXd oraz TxtXg
        //    // brak możliwości modyfikacji wprowadzonych danych
        //    drtxtXd.Enabled = false;
        //    drtxtXg.Enabled = false;
        //    // ustalenie wartości zmiany, który nie może być = 0 lub ujemny, oraz nie może byc wiekszy
        //    // od rożnicy obu granic szeregu
        //    if (!float.TryParse(drtxtH.Text, out drH))
        //    {
        //        errorProvider1.SetError(drtxtH, "ERROR: W zapisie przyrostu zmiennej przyrostu h" +
        //            "wystapił niedozwolony znak");
        //        // przerywamy dalsze pobieranie danych wejsciowych
        //        return false;
        //    }
        //    // sprawdzenie czy H jesty cyfrą
        //    if ((drH <= 0.0f) || (drH >= drXg - drXd))
        //    { // wyswietlenie bledu
        //        errorProvider1.SetError(drtxtH, "ERROR: Podana wartośc H nie spełnia" +
        //            "warunku wyjściowego: H musi być większe od 0 i musi być mniejsze" +
        //            "szerokości przedziału");
        //    }
        //    // jeśli wszystko jest G - ustawiamy stan braku aktywności dla kontolki txtH
        //    drtxtH.Enabled = false;
        //    // zwrotne przekazanie informacji o braku błędów
        //    return true;
        //}
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //void drPrzekazanieWynikówDoDGV(float[,] drTWS, DataGridView drdgvTWS)
        //{
        //    // wyczyszczenie kontrolki datagridview
        //    drdgvTWS.Rows.Clear(); // szczotka XD 
        //    // wpisanie kolejno wierszy z tablicy TWS do kontrolki dgvTWS
        //    for (int i = 0; i < drTWS.GetLength(0); i++)
        //    {
        //        // dodanie nowego wiersza dla wpisania i-tego wiersza tablicy TWS 
        //        drdgvTWS.Rows.Add();
        //        // wpisanie i-tego wiersza tablicy TWS do i-tego wiersza kontrolki dgvTWS
        //        drdgvTWS.Rows[i].Cells[0].Value = string.Format("{0:0.00}", drTWS[i, 0]);
        //        drdgvTWS.Rows[i].Cells[1].Value = string.Format("{0:0.000}", drTWS[i, 1]);
        //        drdgvTWS.Rows[i].Cells[2].Value = string.Format("{0}", (ushort)drTWS[i, 2]);
        //    }
        //}
        //private void drbtnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        //{
        //    // wyświetlenie kontrolki dgv 
        //    drdgvTWS.Visible = true;
        //    // zgaszenie kontrolki errorProvider
        //    errorProvider1.Dispose();
        //    float drXd, drXg, drH;
        //    if (!drPobranieDanych(out drXd, out drXg, out drH))
        //    {
        //        //sygnalizacja bledu
        //        errorProvider1.SetError(drbtnWizualizacjaTabelaryczna, "ERROR: podczas wprowadzania" +
        //            "danych wejściowych wystąpił błąd i dana funkcjonalność nie może być wykonana");
        //        return;
        //    }
        //    if (drTWS is null)
        //    {
        //        TablicowanieWartosciSzeregu(drXd, drXg, drH, out drTWS);
        //    }
        //    // przypisanie elementów tablicy TWS do kontrolki DataGridView
        //    //bezpośrednie przepisanie elementów tablicy TWS do kontrolki DataGridView
        //    drPrzekazanieWynikówDoDGV(drTWS, drdgvTWS);
        //    //ukrycie kontrolki chart
        //    //--------chtWykresSzeregu.Visible = false;-------
        //    // ustawienie braku aktywnosci dla przycisku wizualizacji
        //    drdgvTWS.Visible = true;
        //    drbtnWizualizacjaTabelaryczna.Enabled = false;
        //}
        ///*        
        // *        void TablicowanieWartosciSzeregu(float Xd, float Xg, float h, float Eps, out float[,] TWS)
        //{
        //    // dla utworzenia egzemplarza tablicy TWS musimy wyznaczyc liczbe niezbednych jego wierszy
        //    int n = (int)((Xg - Xd) / h + 1);
        //// utworzenie egzemplarza tablic TWS
        //TWS = new float[n + 1, 3];
        //    // dla potrzeb tablicowania deklarujemy zmienne pomocnicze
        //    float X;
        //int i; //Numer podprzedzialu w przedziale [Xd, Xg]
        //ushort LicznikZsumowanychWyrazów;
        //    // tablicowanie
        //    for (X = Xd, i = 0; i<TWS.GetLength(0); i++, X = Xd + i* h) // nie piszemy tak X = X + h
        //    { // Wpisanie do tablicy TWS wynikow tablicowania wartosci szeregu
        //        TWS[i, 0] = X;
        //        TWS[i, 1] = ObliczanieSumyWartościSzereguPotęgowego(X, Eps, out LicznikZsumowanychWyrazów);
        //TWS[i, 2] = LicznikZsumowanychWyrazów;
        //    }*/

        ///*
        // * 
        // */
    }
}

