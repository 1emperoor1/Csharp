namespace ProjectNR1_Rynkiewicz63305
{
    partial class ProjektNr1_Rynkiewicz63305
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.drtxtXd = new System.Windows.Forms.TextBox();
            this.drtxtXg = new System.Windows.Forms.TextBox();
            this.drtxtH = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.drpbRysownica = new System.Windows.Forms.PictureBox();
            this.drdgvTWS = new System.Windows.Forms.DataGridView();
            this.drbtnWizualizacjaTabelaryczna = new System.Windows.Forms.Button();
            this.drbtnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.drbtnReset = new System.Windows.Forms.Button();
            this.drbtnAnimacja = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WartośćX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumaSzeregu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drdgvTWS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Przedział wartości zmiennej niezależnej X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(308, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xd ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(397, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Xg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(488, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "H: (krok zmian\r\n wartości X)\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drtxtXd
            // 
            this.drtxtXd.Location = new System.Drawing.Point(344, 52);
            this.drtxtXd.Name = "drtxtXd";
            this.drtxtXd.Size = new System.Drawing.Size(37, 20);
            this.drtxtXd.TabIndex = 4;
            // 
            // drtxtXg
            // 
            this.drtxtXg.Location = new System.Drawing.Point(429, 52);
            this.drtxtXg.Name = "drtxtXg";
            this.drtxtXg.Size = new System.Drawing.Size(43, 20);
            this.drtxtXg.TabIndex = 5;
            this.drtxtXg.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // drtxtH
            // 
            this.drtxtH.Location = new System.Drawing.Point(585, 52);
            this.drtxtH.Name = "drtxtH";
            this.drtxtH.Size = new System.Drawing.Size(41, 20);
            this.drtxtH.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // drpbRysownica
            // 
            this.drpbRysownica.BackColor = System.Drawing.SystemColors.Window;
            this.drpbRysownica.Location = new System.Drawing.Point(12, 79);
            this.drpbRysownica.Name = "drpbRysownica";
            this.drpbRysownica.Size = new System.Drawing.Size(596, 415);
            this.drpbRysownica.TabIndex = 7;
            this.drpbRysownica.TabStop = false;
            this.drpbRysownica.Paint += new System.Windows.Forms.PaintEventHandler(this.drpbRysownica_Paint);
            // 
            // drdgvTWS
            // 
            this.drdgvTWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drdgvTWS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WartośćX,
            this.SumaSzeregu});
            this.drdgvTWS.Location = new System.Drawing.Point(524, 78);
            this.drdgvTWS.Name = "drdgvTWS";
            this.drdgvTWS.Size = new System.Drawing.Size(243, 415);
            this.drdgvTWS.TabIndex = 8;
            this.drdgvTWS.Visible = false;
            // 
            // drbtnWizualizacjaTabelaryczna
            // 
            this.drbtnWizualizacjaTabelaryczna.Location = new System.Drawing.Point(808, 136);
            this.drbtnWizualizacjaTabelaryczna.Name = "drbtnWizualizacjaTabelaryczna";
            this.drbtnWizualizacjaTabelaryczna.Size = new System.Drawing.Size(75, 23);
            this.drbtnWizualizacjaTabelaryczna.TabIndex = 13;
            // 
            // drbtnWizualizacjaGraficzna
            // 
            this.drbtnWizualizacjaGraficzna.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drbtnWizualizacjaGraficzna.Location = new System.Drawing.Point(798, 237);
            this.drbtnWizualizacjaGraficzna.Name = "drbtnWizualizacjaGraficzna";
            this.drbtnWizualizacjaGraficzna.Size = new System.Drawing.Size(164, 94);
            this.drbtnWizualizacjaGraficzna.TabIndex = 10;
            this.drbtnWizualizacjaGraficzna.Text = "Wizualizacja graficzna\r\nzmiany wartości szeregu potęgowego\r\n";
            this.drbtnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            // 
            // drbtnReset
            // 
            this.drbtnReset.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drbtnReset.Location = new System.Drawing.Point(798, 427);
            this.drbtnReset.Name = "drbtnReset";
            this.drbtnReset.Size = new System.Drawing.Size(164, 59);
            this.drbtnReset.TabIndex = 11;
            this.drbtnReset.Text = "RESETUJ";
            this.drbtnReset.UseVisualStyleBackColor = true;
            this.drbtnReset.Click += new System.EventHandler(this.drbtnReset_Click);
            // 
            // drbtnAnimacja
            // 
            this.drbtnAnimacja.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.drbtnAnimacja.Location = new System.Drawing.Point(798, 337);
            this.drbtnAnimacja.Name = "drbtnAnimacja";
            this.drbtnAnimacja.Size = new System.Drawing.Size(164, 84);
            this.drbtnAnimacja.TabIndex = 12;
            this.drbtnAnimacja.Text = "Animacja po linii toru\r\n(wyznaczona przez szereg potęgowy)";
            this.drbtnAnimacja.UseVisualStyleBackColor = true;
            this.drbtnAnimacja.Click += new System.EventHandler(this.drbtnAnimacja_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WartośćX
            // 
            this.WartośćX.HeaderText = "Wartość zmiennej niezależnej X";
            this.WartośćX.Name = "WartośćX";
            // 
            // SumaSzeregu
            // 
            this.SumaSzeregu.HeaderText = "Obliczona suma szeregu potęgowego S(x)";
            this.SumaSzeregu.Name = "SumaSzeregu";
            // 
            // ProjektNr1_Rynkiewicz63305
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 498);
            this.Controls.Add(this.drbtnAnimacja);
            this.Controls.Add(this.drbtnReset);
            this.Controls.Add(this.drbtnWizualizacjaGraficzna);
            this.Controls.Add(this.drbtnWizualizacjaTabelaryczna);
            this.Controls.Add(this.drdgvTWS);
            this.Controls.Add(this.drpbRysownica);
            this.Controls.Add(this.drtxtH);
            this.Controls.Add(this.drtxtXg);
            this.Controls.Add(this.drtxtXd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProjektNr1_Rynkiewicz63305";
            this.Text = "Animacja komputerowa po linii toru";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjektNr1_Rynkiewicz63305_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drdgvTWS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox drtxtXd;
        private System.Windows.Forms.TextBox drtxtXg;
        private System.Windows.Forms.TextBox drtxtH;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox drpbRysownica;
        private System.Windows.Forms.Button drbtnAnimacja;
        private System.Windows.Forms.Button drbtnReset;
        private System.Windows.Forms.Button drbtnWizualizacjaGraficzna;
        private System.Windows.Forms.Button drbtnWizualizacjaTabelaryczna;
        private System.Windows.Forms.DataGridView drdgvTWS;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartośćX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumaSzeregu;
    }
}