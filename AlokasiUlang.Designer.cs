namespace MRZReader
{
    partial class AlokasiUlang
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
            this.tbNoPermohonan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNoPassportLama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNoPassportBaru = new System.Windows.Forms.TextBox();
            this.btnGantiNo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAlasan = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNoPermohonan
            // 
            this.tbNoPermohonan.Location = new System.Drawing.Point(164, 12);
            this.tbNoPermohonan.Name = "tbNoPermohonan";
            this.tbNoPermohonan.ReadOnly = true;
            this.tbNoPermohonan.Size = new System.Drawing.Size(149, 20);
            this.tbNoPermohonan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No. Permohonan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Passport Lama";
            // 
            // tbNoPassportLama
            // 
            this.tbNoPassportLama.Location = new System.Drawing.Point(164, 41);
            this.tbNoPassportLama.Name = "tbNoPassportLama";
            this.tbNoPassportLama.ReadOnly = true;
            this.tbNoPassportLama.Size = new System.Drawing.Size(149, 20);
            this.tbNoPassportLama.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alokasi No. Passport Baru";
            // 
            // tbNoPassportBaru
            // 
            this.tbNoPassportBaru.Location = new System.Drawing.Point(164, 70);
            this.tbNoPassportBaru.Name = "tbNoPassportBaru";
            this.tbNoPassportBaru.ReadOnly = true;
            this.tbNoPassportBaru.Size = new System.Drawing.Size(149, 20);
            this.tbNoPassportBaru.TabIndex = 5;
            // 
            // btnGantiNo
            // 
            this.btnGantiNo.Location = new System.Drawing.Point(319, 68);
            this.btnGantiNo.Name = "btnGantiNo";
            this.btnGantiNo.Size = new System.Drawing.Size(116, 23);
            this.btnGantiNo.TabIndex = 6;
            this.btnGantiNo.Text = "Nomor Pengganti";
            this.btnGantiNo.UseVisualStyleBackColor = true;
            this.btnGantiNo.Visible = false;
            this.btnGantiNo.Click += new System.EventHandler(this.btnGantiNo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Alasan";
            // 
            // cbAlasan
            // 
            this.cbAlasan.FormattingEnabled = true;
            this.cbAlasan.Location = new System.Drawing.Point(164, 98);
            this.cbAlasan.Name = "cbAlasan";
            this.cbAlasan.Size = new System.Drawing.Size(271, 21);
            this.cbAlasan.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 31);
            this.button2.TabIndex = 9;
            this.button2.Text = "Simpan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlokasiUlang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 164);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbAlasan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGantiNo);
            this.Controls.Add(this.tbNoPassportBaru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNoPassportLama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNoPermohonan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AlokasiUlang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alokasi Ulang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlokasiUlang_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNoPermohonan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNoPassportLama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNoPassportBaru;
        private System.Windows.Forms.Button btnGantiNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAlasan;
        private System.Windows.Forms.Button button2;
    }
}