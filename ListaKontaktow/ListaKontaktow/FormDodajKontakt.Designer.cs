namespace ListaKontaktow
{
    partial class FormDodajKontakt
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.Button btnPoradnik;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImie = new System.Windows.Forms.TextBox();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.btnPoradnik = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1 - Imię
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.Text = "Imię";

            // txtImie
            this.txtImie.Location = new System.Drawing.Point(100, 15);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(200, 23);
            this.txtImie.TabIndex = 0;

            // label2 - Nazwisko
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.Text = "Nazwisko";

            // txtNazwisko
            this.txtNazwisko.Location = new System.Drawing.Point(100, 55);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(200, 23);
            this.txtNazwisko.TabIndex = 1;

            // label3 - Telefon
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.Text = "Telefon";

            // txtTelefon
            this.txtTelefon.Location = new System.Drawing.Point(100, 95);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(200, 23);
            this.txtTelefon.TabIndex = 2;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(100, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnAnuluj
            this.btnAnuluj.Location = new System.Drawing.Point(225, 140);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(75, 30);
            this.btnAnuluj.TabIndex = 4;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);

            // btnPoradnik
            this.btnPoradnik.Location = new System.Drawing.Point(340, 140);
            this.btnPoradnik.Name = "btnPoradnik";
            this.btnPoradnik.Size = new System.Drawing.Size(90, 30);
            this.btnPoradnik.TabIndex = 5;
            this.btnPoradnik.Text = "Poradnik";
            this.btnPoradnik.UseVisualStyleBackColor = true;
            this.btnPoradnik.Click += new System.EventHandler(this.btnPoradnik_Click);

            // FormDodajKontakt
            this.ClientSize = new System.Drawing.Size(450, 190);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNazwisko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnuluj);
            this.Controls.Add(this.btnPoradnik);
            this.Name = "FormDodajKontakt";
            this.Text = "Dodaj kontakt";
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
