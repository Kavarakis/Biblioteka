using System;
using System.Linq;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
    public partial class UposlenikPanel : Form
    {
        Administrator admin;
        public UposlenikPanel(Administrator x)
        {
            admin = x;
            admin.DodajKnjigu("Derviš i smrt", "Meša Selimović", "1987", "Publishing", "Roman", "9788610009729");
            admin.DodajKnjigu("PRIČE O DECI", "Ivo Andrić", "1977", "Algoritam", "Roman", "9788663690912");
            InitializeComponent();
            this.Location = Log.ActiveForm.Location;
            radioButton1.Checked = true;
            checkedListBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var item in admin.DajClanove())
            {
                listBox2.Items.Add(item.ToString());
            }

            foreach (var str in admin.DajKnjige())
            {
                listBox1.Items.Add(str);
                if (str.ToString().Contains(IzdavactextBox.Text))
                {
                    checkedListBox1.Items.Add(str);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x <= checkedListBox1.CheckedItems.Count - 1; x++)
                admin.IzbrisiKnjigu(admin.PretragaKnjiga(checkedListBox1.CheckedItems[x].ToString()));
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var str in admin.DajKnjige())
            {
                listBox1.Items.Add(str);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in admin.DajClanove())
            {
                if (listBox2.SelectedItem.Equals(item.ToString()))
                {
                    int i = 0,indeksic=0;
                    for( i = 0; i < admin.DajClanove().Count; i++)
                    {
                        if (item.ToString().Equals(admin.DajClanove()[i].ToString())) indeksic = i;
                    }
                    AzuriranjeClana novi = new AzuriranjeClana(admin, item,indeksic);
                    this.Hide();
                    novi.ShowDialog();
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            admin.DodajKnjigu(NaslovtextBox.Text, AutortextBox.Text, GodIzdtextBox.Text, IzdavactextBox.Text,zanrtextBox.Text, ISBNtextBox.Text);
        }
    }
}
