using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
    public partial class Pretraga : Form
    {
        Administrator admin;
      
        public Pretraga(Administrator x)
        {
            admin = x;
            InitializeComponent();
            admin.DodajKnjigu("Derviš i smrt", "Meša Selimović", "1987", "Publishing", "Roman", "9788610009729");
            admin.DodajKnjigu("PRIČE O DECI", "Ivo Andrić", "1977", "Algoritam", "Roman", "9788663690912");
           // items.AddRange(new string[] { "Cat", "Dog", "Carrots", "Brocolli" });
            /*
            foreach (string str in items)
            {
                listBox1.Items.Add(str);
            }
            */
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var str in admin.DajKnjige())
            {
                if (str.ToString().Contains(textBox1.Text))
                {
                    listBox1.Items.Add(str);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
