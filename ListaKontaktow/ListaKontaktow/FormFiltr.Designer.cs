namespace ListaKontaktow
{
    partial class FormFiltr
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Button btnWyczysc;
        private System.Windows.Forms.ComboBox cmbSortuj;
        private System.Windows.Forms.Button btnOK;

        // Dodane kontrolki Label
        private System.Windows.Forms.Label labelImie;
        private System.Windows.Forms.Label labelNazwisko;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.Label labelSortuj;

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
            this.txtImie = new System.Windows.Forms.TextBox();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.cmbSortuj = new System.Windows.Forms.ComboBox();
            this.btnWyczysc = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();

            this.labelImie = new System.Windows.Forms.Label();
            this.labelNazwisko = new System.Windows.Forms.Label();
            this.labelTelefon = new System.Windows.Forms.Label();
            this.labelSortuj = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // labelImie
            this.labelImie.AutoSize = true;
            this.labelImie.Location = new System.Drawing.Point(20, 10);
            this.labelImie.Name = "labelImie";
            this.labelImie.Size = new System.Drawing.Size(29, 15);
            this.labelImie.Text = "Imię";

            // txtImie
            this.txtImie.Location = new System.Drawing.Point(20, 30);
            this.txtImie.Name = "txtImie";
            this.txtImie.PlaceholderText = "Wpisz imię";
            this.txtImie.Size = new System.Drawing.Size(260, 27);
            this.txtImie.TextChanged += new System.EventHandler(this.FiltrZmieniony);

            // labelNazwisko
            this.labelNazwisko.AutoSize = true;
            this.labelNazwisko.Location = new System.Drawing.Point(20, 65);
            this.labelNazwisko.Name = "labelNazwisko";
            this.labelNazwisko.Size = new System.Drawing.Size(65, 15);
            this.labelNazwisko.Text = "Nazwisko";

            // txtNazwisko
            this.txtNazwisko.Location = new System.Drawing.Point(20, 85);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.PlaceholderText = "Wpisz nazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(260, 27);
            this.txtNazwisko.TextChanged += new System.EventHandler(this.FiltrZmieniony);

            // labelTelefon
            this.labelTelefon.AutoSize = true;
            this.labelTelefon.Location = new System.Drawing.Point(20, 120);
            this.labelTelefon.Name = "labelTelefon";
            this.labelTelefon.Size = new System.Drawing.Size(52, 15);
            this.labelTelefon.Text = "Telefon";

            // txtTelefon
            this.txtTelefon.Location = new System.Drawing.Point(20, 140);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.PlaceholderText = "Wpisz numer telefonu";
            this.txtTelefon.Size = new System.Drawing.Size(260, 27);
            this.txtTelefon.TextChanged += new System.EventHandler(this.FiltrZmieniony);

            // labelSortuj
            this.labelSortuj.AutoSize = true;
            this.labelSortuj.Location = new System.Drawing.Point(20, 175);
            this.labelSortuj.Name = "labelSortuj";
            this.labelSortuj.Size = new System.Drawing.Size(38, 15);
            this.labelSortuj.Text = "Sortuj";

            // cmbSortuj
            this.cmbSortuj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortuj.Items.AddRange(new object[] { "Brak", "Imię A-Z", "Nazwisko A-Z", "Telefon A-Z" });
            this.cmbSortuj.Location = new System.Drawing.Point(20, 195);
            this.cmbSortuj.Name = "cmbSortuj";
            this.cmbSortuj.Size = new System.Drawing.Size(260, 28);
            this.cmbSortuj.SelectedIndexChanged += new System.EventHandler(this.FiltrZmieniony);

            // btnWyczysc
            this.btnWyczysc.Location = new System.Drawing.Point(20, 235);
            this.btnWyczysc.Name = "btnWyczysc";
            this.btnWyczysc.Size = new System.Drawing.Size(125, 35);
            this.btnWyczysc.Text = "Wyczyść filtr";
            this.btnWyczysc.UseVisualStyleBackColor = true;
            this.btnWyczysc.Click += new System.EventHandler(this.btnWyczysc_Click);

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(155, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 35);
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // FormFiltr
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 290);
            this.Controls.Add(this.labelImie);
            this.Controls.Add(this.txtImie);
            this.Controls.Add(this.labelNazwisko);
            this.Controls.Add(this.txtNazwisko);
            this.Controls.Add(this.labelTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.labelSortuj);
            this.Controls.Add(this.cmbSortuj);
            this.Controls.Add(this.btnWyczysc);
            this.Controls.Add(this.btnOK);
            this.Name = "FormFiltr";
            this.Text = "Zaawansowane filtrowanie";
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }

}
