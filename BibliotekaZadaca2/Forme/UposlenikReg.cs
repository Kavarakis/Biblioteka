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
    public partial class UposlenikReg : Form
    {
        Administrator admin;
        public UposlenikReg(Administrator x)
        {
            admin = x;
            InitializeComponent();
            this.Location = Start.ActiveForm.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                admin.DodajUposlenika(ImetextBox.Text, PrezimetextBox.Text, dateTimePicker1.Value, JMBGtextBox.Text, pictureBox1.Image);
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.ForestGreen;
                toolStripStatusLabel1.Text = "Uspješan Unos";
                MessageBox.Show("Uposlenik je uspješno unesen.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                admin.CreateBazaUposlenika(admin.DajUposlenike().Last());
                Start novi = new Start(admin);
                this.Hide();
                novi.ShowDialog();
                this.Close();
            }
            catch(Exception x)
            {
                toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkRed;
                toolStripStatusLabel1.Visible = true;
                toolStripStatusLabel1.Text = x.Message;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path
                //textBox1.Text = open.FileName;
            }

        }
    }
}
