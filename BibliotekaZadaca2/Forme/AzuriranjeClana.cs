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
    public partial class AzuriranjeClana : Form
    {
       Administrator admin;
        Clanovi temp;
        int mjesto = 0;
        public AzuriranjeClana(Administrator x,Clanovi item,int mjesto)
        {
            admin = x;
            temp = item;
            this.mjesto = mjesto;
            InitializeComponent();
            this.Location = UposlenikPanel.ActiveForm.Location;
            if ((temp is StudentBachelor) || (temp is StudentMaster))
            {
                IndekstextBox.Visible = false;
                label5.Visible = false;
            }
            ImetextBox.Text = item.Ime;
            PrezimetextBox.Text = item.Prezime;
            dateTimePicker1.Value = item.Datum;
            JMBGtextBox.Text = item.JMBG;
        }
      
        public void SetujProfesora()
        {
            ImetextBox.Text = temp.Ime;
            PrezimetextBox.Text = temp.Prezime;
            dateTimePicker1.Value = temp.Datum;
            JMBGtextBox.Text = temp.JMBG;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp.Ime = ImetextBox.Text;
            temp.Prezime = PrezimetextBox.Text;
             temp.Datum= dateTimePicker1.Value ;
             temp.JMBG= JMBGtextBox.Text;
            admin.IzmjeniClana(temp, mjesto);
            MessageBox.Show("Informacija", "Uspješna izmjena! ");
            this.Hide();
            UposlenikPanel novi = new UposlenikPanel(admin);
            novi.ShowDialog();
            this.Close();
        }

        private void ImetextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
