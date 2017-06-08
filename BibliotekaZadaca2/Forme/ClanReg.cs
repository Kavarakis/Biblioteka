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

    public partial class ClanReg : Form
    {
        public  Administrator admin;
        public ClanReg(Administrator x)
        {
            InitializeComponent();
            this.Location = Start.ActiveForm.Location;
            admin = x;
      
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if (radioButton1.Checked)
                    {
                        Profesor x = new Profesor(ImetextBox.Text, PrezimetextBox.Text, dateTimePicker1.Value, JMBGtextBox.Text, IndekstextBox.Text);
                        admin.DodajClana(ImetextBox.Text, PrezimetextBox.Text, dateTimePicker1.Value, JMBGtextBox.Text, IndekstextBox.Text, 1);
                    }
                    else if (radioButton2.Checked && !string.IsNullOrEmpty(IndekstextBox.Text))
                        admin.DodajClana(ImetextBox.Text, PrezimetextBox.Text, dateTimePicker1.Value, JMBGtextBox.Text, IndekstextBox.Text, 2);
                    else if (radioButton3.Checked && !string.IsNullOrEmpty(IndekstextBox.Text))
                        admin.DodajClana(ImetextBox.Text, PrezimetextBox.Text, dateTimePicker1.Value, JMBGtextBox.Text, IndekstextBox.Text, 3);
                             
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.ForestGreen;
                
                MessageBox.Show("Član uspješno unesen.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                admin.CreateBazaClanova(admin.DajClanove().Last());
                Start novi = new Start(admin);
                this.Hide();
                novi.ShowDialog();
                this.Close();
               
                
                
            }
            catch (Exception x)
            {
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkRed;
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel1.Text = x.Message;
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label5.Visible = true;
                label5.Text = "Indeks: ";
                IndekstextBox.Visible = true;
            }
            else
            {
                label5.Visible = false;
                IndekstextBox.Visible = false;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label5.Visible = true;
                label5.Text = "Indeks: ";
                IndekstextBox.Visible = true;

            }
            else
            {
                label5.Visible = false;
                IndekstextBox.Visible = false;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label5.Visible = true;
                label5.Text = "Sifra zaposlenog: ";
                IndekstextBox.Visible = true;
            }
            else
            {
                label5.Visible = false;
                IndekstextBox.Visible = false;

            }

        }

        private void JMBGtextBox_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
