using System;
using System.Windows.Forms;

namespace ListaKontaktow
{
    public partial class FormPoradnik : Form
    {
        public FormPoradnik()
        {
            InitializeComponent();

            rtbPoradnik.Text =
                "+48 – Polska\r\n" +
                "+49 – Niemcy\r\n" +
                "+44 – Wielka Brytania\r\n" +
                "+1 – USA / Kanada\r\n" +
                "+33 – Francja\r\n" +
                "+39 – Włochy\r\n" +
                "+34 – Hiszpania\r\n" +
                "+420 – Czechy\r\n" +
                "+421 – Słowacja\r\n" +
                "+380 – Ukraina\r\n" +
                "+370 – Litwa\r\n" +
                "+371 – Łotwa\r\n" +
                "+372 – Estonia\r\n" +
                "+7 – Rosja\r\n" +
                "+86 – Chiny\r\n" +
                "+81 – Japonia\r\n" +
                "+91 – Indie\r\n" +
                "\r\nWprowadź numer w formacie np. +48123456789";
        }
    }
}
