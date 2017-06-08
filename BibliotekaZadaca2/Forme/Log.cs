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
    public partial class Log : Form
    {
        
        Administrator admin;
        public Log(Administrator x)
        {
            this.Location = Start.ActiveForm.Location;
            InitializeComponent();
         
            admin = x;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string temp = Administrator.GetMd5Hash(textBox2.Text);
            if (admin.CheckUser(textBox1.Text,textBox2.Text )) MessageBox.Show("Uspješno logovanje!");
            if(admin.DajUser(textBox1.Text) is Uposlenik)
            {
                UposlenikPanel novi = new UposlenikPanel(admin);
                this.Hide();
                novi.ShowDialog();
                this.Close();

            }
        }
    }
}
