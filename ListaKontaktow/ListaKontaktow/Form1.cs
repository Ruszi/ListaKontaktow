using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;


namespace ListaKontaktow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            InitializeComponent();
            InitDatabase();  // Tworzy bazę danych, jeśli nie istnieje
            OdswiezDane();   // Ładuje dane do tabeli
        }

        private void InitDatabase()
        {
            string dbPath = "kontakty.db";

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                using (var conn = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE Kontakty (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Imie TEXT NOT NULL,
                                    Nazwisko TEXT NOT NULL,
                                    Telefon TEXT NOT NULL)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void OdswiezDane()
        {
            using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Kontakty", conn);
                daneKontakty = new DataTable(); // <-- Zmienione
                da.Fill(daneKontakty);
                dataGridView1.DataSource = daneKontakty;
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (var formDodaj = new FormDodajKontakt())
            {
                if (formDodaj.ShowDialog() == DialogResult.OK)
                {
                    // Dodaj nowy kontakt do bazy danych
                    using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Kontakty (Imie, Nazwisko, Telefon) VALUES (@imie, @nazwisko, @telefon)";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@imie", formDodaj.Imie);
                        cmd.Parameters.AddWithValue("@nazwisko", formDodaj.Nazwisko);
                        cmd.Parameters.AddWithValue("@telefon", formDodaj.Telefon);
                        cmd.ExecuteNonQuery();
                    }
                    OdswiezDane(); // Odśwież tabelę po dodaniu
                }
            }
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz kontakt do edycji.");
                return;
            }

            // Pobieramy dane z wybranej komórki
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            string imie = dataGridView1.CurrentRow.Cells["Imie"].Value.ToString();
            string nazwisko = dataGridView1.CurrentRow.Cells["Nazwisko"].Value.ToString();
            string telefon = dataGridView1.CurrentRow.Cells["Telefon"].Value.ToString();

            using (var form = new FormDodajKontakt(imie, nazwisko, telefon))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
                    {
                        conn.Open();
                        string sql = "UPDATE Kontakty SET Imie = @imie, Nazwisko = @nazwisko, Telefon = @telefon WHERE Id = @id";
                        SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@imie", form.Imie);
                        cmd.Parameters.AddWithValue("@nazwisko", form.Nazwisko);
                        cmd.Parameters.AddWithValue("@telefon", form.Telefon);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    OdswiezDane();
                }
            }
        }


        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz kontakt do usunięcia.");
                return;
            }

            var wynik = MessageBox.Show("Czy na pewno chcesz usunąć ten kontakt?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (wynik != DialogResult.Yes)
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

            using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
            {
                conn.Open();
                string sql = "DELETE FROM Kontakty WHERE Id = @id";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            OdswiezDane(); // Odświeżenie widoku
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            string fraza = txtSzukaj.Text.Trim();

            using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
            {
                conn.Open();
                string sql = "SELECT * FROM Kontakty WHERE Imie LIKE @fraza OR Nazwisko LIKE @fraza";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fraza", "%" + fraza + "%");

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }


        private void btnWszyscy_Click(object sender, EventArgs e)
        {
            OdswiezDane(); // pokaż wszystko
        }

        //metoda dła zapisywania csv
        private string EscapeCsvValue(string value)
        {
            if (value.Contains("\"") || value.Contains(";") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }
        private string EscapeCsvValueWithApostrophe(string value)
        {
            // Apostrof wewnątrz cudzysłowu -> Excel widzi tekst, + zostaje, a apostrof nie jest widoczny
            return $"\"'{value}\"";
        }


        private void btnEksportuj_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
            {
                conn.Open();
                string sql = "SELECT * FROM Kontakty";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.FileName = "kontakty.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            // nagłówek
                            sw.WriteLine("Imie;Nazwisko;Telefon");

                            while (reader.Read())
                            {
                                string imie = EscapeCsvValue(reader["Imie"].ToString());
                                string nazwisko = EscapeCsvValue(reader["Nazwisko"].ToString());
                                string telefon = EscapeCsvValueWithApostrophe(reader["Telefon"].ToString());




                                string line = $"{imie};{nazwisko};{telefon}";
                                sw.WriteLine(line);
                            }

                        }

                        MessageBox.Show("Eksport zakończony sukcesem!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnFiltruj_Click(object sender, EventArgs e)
        {
            using (var filtr = new FormFiltr())
            {
                if (filtr.ShowDialog() == DialogResult.OK)
                {
                    string imie = filtr.Imie.ToLower();
                    string nazwisko = filtr.Nazwisko.ToLower();
                    string telefon = filtr.Telefon.ToLower();
                    string sortuj = filtr.SortujPo;

                    var wyniki = daneKontakty.AsEnumerable().Where(row =>
                        row["Imie"].ToString().ToLower().Contains(imie) &&
                        row["Nazwisko"].ToString().ToLower().Contains(nazwisko) &&
                        row["Telefon"].ToString().ToLower().Contains(telefon)
                    );

                    if (wyniki.Any())
                    {
                        DataTable dt = wyniki.CopyToDataTable();

                        // Sortowanie
                        switch (sortuj)
                        {
                            case "Imię A-Z":
                                dt.DefaultView.Sort = "Imie ASC";
                                break;
                            case "Nazwisko A-Z":
                                dt.DefaultView.Sort = "Nazwisko ASC";
                                break;
                            case "Telefon A-Z":
                                dt.DefaultView.Sort = "Telefon ASC";
                                break;
                        }

                        dataGridView1.DataSource = dt.DefaultView.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                    }
                }
            }
        }


        private void btnEksportujPdf_Click(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection("Data Source=kontakty.db"))
            {
                conn.Open();
                string sql = "SELECT * FROM Kontakty";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "kontakty.pdf"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // Czcionka z Unicode (np. Arial)
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    iTextSharp.text.pdf.BaseFont baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);

                    // Tytuł
                    iTextSharp.text.Font tytulFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Paragraph tytul = new iTextSharp.text.Paragraph("Lista kontaktów", tytulFont)
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    doc.Add(tytul);

                    // Tabela
                    iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(3) { WidthPercentage = 100 };

                    string[] naglowki = { "Imię", "Nazwisko", "Telefon" };
                    foreach (string naglowek in naglowki)
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(naglowek, font))
                        {
                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
                            HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        };
                        table.AddCell(cell);
                    }

                    while (reader.Read())
                    {
                        table.AddCell(new iTextSharp.text.Phrase(reader["Imie"].ToString(), font));
                        table.AddCell(new iTextSharp.text.Phrase(reader["Nazwisko"].ToString(), font));
                        table.AddCell(new iTextSharp.text.Phrase(reader["Telefon"].ToString(), font));
                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF zapisany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEksportujWybor_Click(object sender, EventArgs e)
        {
            string wybranyFormat = comboFormat.SelectedItem.ToString();

            switch (wybranyFormat)
            {

                case "PDF":
                    btnEksportujPdf_Click(sender, e);
                    break;
                case "Excel":
                    EksportujDoExcela();
                    break;
            }
        }


        private void EksportujDoExcela()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "Kontakty.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add("Kontakty");

                    // Nagłówki
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                    }

                    // Dane
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            var value = dataGridView1.Rows[i].Cells[j].Value;
                            if (value != null)
                                worksheet.Cell(i + 2, j + 1).Value = value.ToString();
                        }
                    }

                    // Auto-dopasowanie kolumn
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);

                    MessageBox.Show("Eksport do Excela zakończony pomyślnie!", "Eksport Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        private void btnOtworzGmail_Click(object sender, EventArgs e)
        {
            string odbiorca = txtEmailOdbiorcy.Text.Trim();

            if (string.IsNullOrWhiteSpace(odbiorca))
            {
                MessageBox.Show("Podaj adres e-mail odbiorcy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string temat = Uri.EscapeDataString("Kontakty z aplikacji");
            string tresc = Uri.EscapeDataString("W załączniku znajduje się lista kontaktów. Dołącz plik ręcznie.");

            string gmailUrl = $"https://mail.google.com/mail/?view=cm&fs=1&to={odbiorca}&su={temat}&body={tresc}";

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = gmailUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udało się otworzyć Gmaila: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
