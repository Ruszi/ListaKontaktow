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
    public partial class FormFiltr : Form
    {
        public string Imie => txtImie.Text;
        public string Nazwisko => txtNazwisko.Text;
        public string Telefon => txtTelefon.Text;
        public string SortujPo => cmbSortuj.SelectedItem?.ToString() ?? "Brak";

        public FormFiltr()
        {
            InitializeComponent();
            cmbSortuj.SelectedIndex = 0; // Domyślnie "Brak"
        }

        private void FiltrZmieniony(object sender, EventArgs e)
        {
           // DialogResult = DialogResult.OK;
            
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            txtImie.Text = "";
            txtNazwisko.Text = "";
            txtTelefon.Text = "";
            cmbSortuj.SelectedIndex = 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }

}
