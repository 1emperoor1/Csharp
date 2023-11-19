namespace ProjectNR1_Rynkiewicz63305
{
    partial class Kokpit_Rynkiewicz63305
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kokpit_Rynkiewicz63305));
            this.btnLaboratoryjnyNr1 = new System.Windows.Forms.Button();
            this.btnIndywidualnyNr1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaboratoryjnyNr1
            // 
            this.btnLaboratoryjnyNr1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLaboratoryjnyNr1.Location = new System.Drawing.Point(70, 170);
            this.btnLaboratoryjnyNr1.Name = "btnLaboratoryjnyNr1";
            this.btnLaboratoryjnyNr1.Size = new System.Drawing.Size(314, 104);
            this.btnLaboratoryjnyNr1.TabIndex = 0;
            this.btnLaboratoryjnyNr1.Text = "Laboratorium Nr 1\r\n(szereg laboratoryjny)";
            this.btnLaboratoryjnyNr1.UseVisualStyleBackColor = true;
            this.btnLaboratoryjnyNr1.Click += new System.EventHandler(this.btnLaboratoryjnyNr1_Click);
            // 
            // btnIndywidualnyNr1
            // 
            this.btnIndywidualnyNr1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIndywidualnyNr1.Location = new System.Drawing.Point(422, 170);
            this.btnIndywidualnyNr1.Name = "btnIndywidualnyNr1";
            this.btnIndywidualnyNr1.Size = new System.Drawing.Size(312, 104);
            this.btnIndywidualnyNr1.TabIndex = 1;
            this.btnIndywidualnyNr1.Text = "Projekt Nr 1\r\n(szereg indywidualny autora programu)";
            this.btnIndywidualnyNr1.UseVisualStyleBackColor = true;
            this.btnIndywidualnyNr1.Click += new System.EventHandler(this.btnIndywidualnyNr1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(194, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Animacja komputerowa po linii toru \r\nwyznaczonego przez wykres zmiany wartości sz" +
    "eregu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(504, 280);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(164, 281);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 65);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Kokpit_Rynkiewicz63305
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIndywidualnyNr1);
            this.Controls.Add(this.btnLaboratoryjnyNr1);
            this.Name = "Kokpit_Rynkiewicz63305";
            this.Text = "Animacja komputerowa po linii toru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLaboratoryjnyNr1;
        private System.Windows.Forms.Button btnIndywidualnyNr1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

