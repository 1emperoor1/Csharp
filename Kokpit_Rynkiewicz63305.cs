using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNR1_Rynkiewicz63305
{
    public partial class Kokpit_Rynkiewicz63305 : Form
    {
        public Kokpit_Rynkiewicz63305()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // wyswietlenie okna dialogowego
            DialogResult OknoMessage = MessageBox.Show("Czy rzeczywiście chcesz zakmnąć formularz"
                     + "i zakończyć pracę w programie?", this.Text,
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OknoMessage == DialogResult.Yes)
            {
                Application.ExitThread();
                // zamknięcie programu
            }
            else
            {
                // anulowanie wyświetlania okna dialogowego
                e.Cancel = true;
            }
        }

        private void btnLaboratoryjnyNr1_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy egzemplarz został juz wczesniej utworzony
            foreach (Form Formularz in Application.OpenForms)
                // sprawdzenie czy został znaleziony formularz
                if (Formularz.Name == "LaboratoriumNr2")
                {
                    // ukrycie głównego formularza 
                    this.Hide();
                    // odsłonięcie znalezionego formularza
                    Formularz.Show();
                    // bezwarunkowe zakończenie metody zdarzenia obsługi Click
                    return;
                }
            // inaczej formularz nie został znaleziony
            // tak więc tworzymy nowy formularz xD 
            LaboratoriumNr1 FormLaboratoriumNr1 = new LaboratoriumNr1();
            // ukrycie bieżacego formularza i odsłonięcie nowoutworzonego
            this.Hide();
            // odsłonięcie nowoutworzonego formularza
            FormLaboratoriumNr1.Show();
        }

        private void btnIndywidualnyNr1_Click(object sender, EventArgs e)
        {
            // sprawdzenie czy egzemplarz został juz wczesniej utworzony
            foreach (Form Formularz in Application.OpenForms)
                // sprawdzenie czy został znaleziony formularz
                if (Formularz.Name == "ProjektNr2_Rynkiewicz63305")
                {
                    // ukrycie głównego formularza 
                    this.Hide();
                    // odsłonięcie znalezionego formularza
                    Formularz.Show();
                    // bezwarunkowe zakończenie metody zdarzenia obsługi Click
                    return;
                }
            // inaczej formularz nie został znaleziony
            // tak więc tworzymy nowy formularz xD 
            ProjektNr1_Rynkiewicz63305 FormIndywidualnyNR1 = new ProjektNr1_Rynkiewicz63305();
            // ukrycie bieżacego formularza i odsłonięcie nowoutworzonego
            this.Hide();
            // odsłonięcie nowoutworzonego formularza
            FormIndywidualnyNR1.Show();
        }
    }
}
