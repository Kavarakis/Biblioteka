using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace BibliotekaZadaca2
{
    public partial class AdministratorPanel : Form
    {
        BindingList<Clanovi> XMLClanovi;

        protected static Administrator admin;
        Osoba osoba;
        public AdministratorPanel(Administrator x)
        {
            this.Location = Start.ActiveForm.Location;
            InitializeComponent();
            listBox1.Items.Clear();
            admin = x;
            //  this.Size = Start.ActiveForm.Size;

            foreach (var item in admin.DajClanove())
            {
                listBox1.Items.Add(item.ToString());
            }
            foreach (var item in admin.DajUposlenike())
            {
                listBox1.Items.Add(item.ToString());
            }
            osoba = null;
            listBox2.Items.Clear();
            foreach (var item in admin.DajUposlenike())
            {
                listBox2.Items.Add(item.ToString());
            }
            XMLClanovi = new BindingList<Clanovi>();
            foreach (var item in admin.DajClanove())
            {
                XMLClanovi.Add(item);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in admin.DajClanove())
            {
                if (listBox1.SelectedItem.Equals(item.ToString()))
                {
                    osoba = item;
                }
            }
            if (osoba == null)
            {
                foreach (var item in admin.DajUposlenike())
                {
                    if (listBox1.SelectedItem.Equals(item.ToString())) osoba = item;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (osoba == null || textBox1.Text == null || textBox2.Text == null)
            {
                MessageBox.Show("Niste unijeli podatke!");
            }
            if (osoba is Clanovi) admin.DodajNovogClana(osoba.IdSifra, textBox1.Text, textBox2.Text);
            else if (osoba is Uposlenik) admin.DodajNovogZaposlenika(osoba.IdSifra, textBox1.Text, textBox2.Text);
            MessageBox.Show("Uspjesan unos!");
            this.Hide();
            Start novi = new Start(admin);
            novi.ShowDialog();
            this.Close();
        }

        private void AdministratorPanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'novabazaDataSet1.clanovi' table. You can move, or remove it, as needed.
            this.clanoviTableAdapter.Fill(this.novabazaDataSet1.clanovi);
            // TODO: This line of code loads data into the 'novabazaDataSet.clanovi' table. You can move, or remove it, as needed.
            this.clanoviTableAdapter.Fill(this.novabazaDataSet.clanovi);

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda = new MySqlCommand();
            Clanovi clan;
            clan = admin.DajClanove()[0];
            komanda.CommandText = "INSERT INTO novabaza.clanovi(Ime,Prezime,JMBG,DatumRodjenja,IstekClanarine) VALUES('"
                    + clan.Ime + "', '" +
                    clan.Prezime + "', '" +
                    clan.JMBG + "', '" +
                    Convert.ToString(clan.Datum.Year) + "-" +
                    Convert.ToString(clan.Datum.Month) + "-" +
                    Convert.ToString(clan.Datum.Day) + "','" +

                    Convert.ToString(clan.IstekClanarine.Year) + "-" +
                    Convert.ToString(clan.IstekClanarine.Month) + "-" +
                    Convert.ToString(clan.IstekClanarine.Day)
                        + "');";
            komanda.Connection = konekcija;
            konekcija.Open();
            try
            {
                int aff = komanda.ExecuteNonQuery();
                MessageBox.Show(aff + " rows were affected.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=novabaza");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "SELECT * FROM novabaza.clanovi;";
            komanda.Connection = konekcija;
            konekcija.Open();

            try
            {
                MySqlDataAdapter adp = new MySqlDataAdapter(komanda);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                konekcija.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in admin.DajClanove())
            {
                if (item.ToString().Equals(listBox1.SelectedItem.ToString()))
                {
                    osoba = item;
                }
            }
            //listBox1.SelectedItem.ToString()
            if (osoba == null || textBox1.Text == null || textBox2.Text == null)
            {
                MessageBox.Show("Niste unijeli podatke!");
            }
            if (osoba is Clanovi) admin.DodajNovogClana(osoba.IdSifra, textBox1.Text, textBox2.Text);
            else if (osoba is Uposlenik) admin.DodajNovogZaposlenika(osoba.IdSifra, textBox1.Text, textBox2.Text);
            MessageBox.Show("Uspjesan unos!");
            this.Hide();
            Start novi = new Start(admin);
            novi.ShowDialog();
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Snimamo u XML
            try
            {


                XmlSerializer xs = new XmlSerializer(typeof(List<Clanovi>));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "zaposlenici.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, XMLClanovi.ToList<Clanovi>());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Citamo iz XML
            try
            {
                OpenFileDialog opf = new OpenFileDialog() { CheckFileExists = true };
                if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK && opf.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(opf.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Clanovi>));
                        List<Clanovi> tmp = xs.Deserialize(reader) as List<Clanovi>;
                        if (tmp != null)
                        {
                            XMLClanovi = new BindingList<Clanovi>(tmp);
                            listBox3.DataSource = XMLClanovi;
                            //  dataGridView1.DataSource = zaposlenici;

                        }
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
