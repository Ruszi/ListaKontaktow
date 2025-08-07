using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaKontaktow
{
    public partial class FormDodajKontakt : Form
    {
        public string Imie => txtImie.Text;
        public string Nazwisko => txtNazwisko.Text;
        public string Telefon => txtTelefon.Text;

        public FormDodajKontakt()
        {
            InitializeComponent();
        }
        public FormDodajKontakt(string imie, string nazwisko, string telefon) : this()
        {
            txtImie.Text = imie;
            txtNazwisko.Text = nazwisko;
            txtTelefon.Text = telefon;
        }
      
        private void btnPoradnik_Click(object sender, EventArgs e)
        {
            using (var poradnik = new FormPoradnik())
            {
                poradnik.ShowDialog();
            }
        }

        // METODA DŁA PIERWSZEJ LITERY Z WIELKIJ 
        private string Capitalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Telefon, @"^\+?\d{9,15}$"))
            {
                MessageBox.Show("Wprowadź poprawny numer telefonu (np. +48123456789)", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(Imie) || string.IsNullOrWhiteSpace(Nazwisko) || string.IsNullOrWhiteSpace(Telefon))
            {
                MessageBox.Show("Wypełnij wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kapitalizacja imienia i nazwiska
            txtImie.Text = Capitalize(txtImie.Text.Trim());
            txtNazwisko.Text = Capitalize(txtNazwisko.Text.Trim());

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
