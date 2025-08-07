using System.Data;

namespace ListaKontaktow
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.TextBox txtSzukaj;
        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.Button btnWszyscy;
        private System.Windows.Forms.Button btnEksportuj;
        private Button btnFiltruj;
        private System.Windows.Forms.Button btnEksportujPdf;
        private System.Windows.Forms.ComboBox comboFormat;
        private System.Windows.Forms.Button btnEksportujWybor;
        private System.Windows.Forms.Button btnWyslijEmail;
        private TextBox txtEmailOdbiorcy;




        private DataTable daneKontakty; // dodaj to aby przechowywać dane globalnie




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

        private void InitializeComponent()
        {
            this.Text = "Lista kontaktów";
            this.ClientSize = new Size(1020, 700);
            this.BackColor = Color.WhiteSmoke;

            // === Tabela z kontaktami ===
            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Size = new Size(980, 450);
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.GridColor = Color.LightGray;

            // === STYLIZACJA DataGridView ===
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.GridColor = Color.Gainsboro;

            // === Panel dolny ===
            Panel panelDolny = new Panel();
            panelDolny.Location = new Point(20, 480);
            panelDolny.Size = new Size(980, 180);
            panelDolny.BackColor = Color.White;

            // === Przyciski akcji ===
            btnDodaj = new Button { Text = "Dodaj", Size = new Size(90, 30), Location = new Point(10, 10) };
            btnEdytuj = new Button { Text = "Edytuj", Size = new Size(90, 30), Location = new Point(110, 10) };
            btnUsun = new Button { Text = "Usuń", Size = new Size(90, 30), Location = new Point(210, 10) };
            btnDodaj.Click += btnDodaj_Click;
            btnEdytuj.Click += btnEdytuj_Click;
            btnUsun.Click += btnUsun_Click;

            // === Szukaj ===
            txtSzukaj = new TextBox { Size = new Size(200, 27), Location = new Point(320, 12) };
            btnSzukaj = new Button { Text = "Szukaj", Size = new Size(80, 30), Location = new Point(530, 10) };
            btnSzukaj.Click += btnSzukaj_Click;
            btnWszyscy = new Button { Text = "Wszyscy", Size = new Size(90, 30), Location = new Point(620, 10) };
            btnWszyscy.Click += btnWszyscy_Click;
            btnFiltruj = new Button { Text = "Zaaw. filtry", Size = new Size(110, 30), Location = new Point(720, 10) };
            btnFiltruj.Click += btnFiltruj_Click;

            // === E-mail ===
            Label lblEmail = new Label { Text = "E-mail odbiorcy:", Location = new Point(10, 60), AutoSize = true };
            txtEmailOdbiorcy = new TextBox { Size = new Size(250, 27), Location = new Point(130, 58) };
            Button btnOtworzGmail = new Button { Text = "Otwórz Gmail", Location = new Point(390, 56), Size = new Size(130, 30) };
            btnOtworzGmail.Click += btnOtworzGmail_Click;

            // === Eksport ===
            comboFormat = new ComboBox
            {
                Location = new Point(650, 60),
                Size = new Size(100, 27),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboFormat.Items.AddRange(new object[] { "PDF", "Excel" });
            comboFormat.SelectedIndex = 0;

            btnEksportujWybor = new Button { Text = "Eksportuj", Location = new Point(760, 58), Size = new Size(100, 30) };
            btnEksportujWybor.Click += btnEksportujWybor_Click;

            btnEksportujPdf = new Button { Text = "PDF", Location = new Point(870, 58), Size = new Size(80, 30) };
            btnEksportujPdf.Click += btnEksportujPdf_Click;

            // === Dodaj elementy do panelu ===
            panelDolny.Controls.AddRange(new Control[] {
        btnDodaj, btnEdytuj, btnUsun, txtSzukaj, btnSzukaj, btnWszyscy, btnFiltruj,
        lblEmail, txtEmailOdbiorcy, btnOtworzGmail, comboFormat, btnEksportujWybor, btnEksportujPdf
    });

            // === Dodaj do formularza ===
            this.Controls.Add(dataGridView1);
            this.Controls.Add(panelDolny);
        }



        #endregion
    }
}
