using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
    public sealed class Administrator:Biblioteka
    {
        //Biblioteka GlavnaBaza;
       
        Dictionary<Osoba, Tuple<string, string>> Baza;
        public Administrator()
        {
           // GlavnaBaza = new Biblioteka();
            Baza = new Dictionary<Osoba, Tuple<string, string>>();
            
        }
       
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash( input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        public void DodajNovogClana(int ID,string name,string password)
        {
            Osoba temp;
            temp = BazaClanova.Find(x => x.IdSifra == ID);
            if (!BazaClanova.Contains(temp)) throw new ArgumentException("Ne postoji korisnik!");
            else
            {   
                    Baza.Add(temp,
                        new Tuple<string, string>(name, GetMd5Hash(password)
                        ));         
            }
        }
        public void DodajNovogZaposlenika(int ID,string user,string pass)
        {
            Osoba temp;
            temp = BazaUposlenika.Find(x => x.IdSifra == ID);
            if(!BazaUposlenika.Contains(temp)) throw new ArgumentException("Ne postoji korisnik!");
            else
            {
                Baza.Add(temp,
                    new Tuple<string, string>(user, GetMd5Hash(pass)
                    ));
            }
        }
        public bool CheckUser(string user,string pass)
        {
            Tuple<string, string> temp;
            temp = new Tuple<string, string>(user, GetMd5Hash(pass));
            foreach (var item in Baza)
            {
                if (item.Value.Item1 == temp.Item1 && item.Value.Item2==temp.Item2) return true;
            }
            return false;
        }
        public Osoba DajUser(string username)
        {
            foreach (var item in Baza)
            {
                if (item.Value.Item1 == username) return item.Key;
            }
            throw new ArgumentException("Ne postoji korisnik pod navedenim nadimkom!");
        }
        public  string VratiUsername(int ID)
        {
            Tuple<string, string> temp;
            if (!Baza.TryGetValue(BazaClanova.Find(x => x.IdSifra == ID), out temp)) throw new ArgumentException("Ne postoji Username!");
            else return temp.Item1;
        }
        public void CreateBazaClanova(Clanovi clan)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda = new MySqlCommand();
      
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
            
            konekcija.Close();
        }
        public void UpdateBazaClanova(int ID,Clanovi clan)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "UPDATE novabaza.clanovi SET Ime = '" 
                + clan.Ime
                + "',Prezime= '" + clan.Prezime 
                + "',DatumRodjenja= '" 
                + Convert.ToString(clan.Datum.Year) + "-" 
                + Convert.ToString(clan.Datum.Month) + "-" 
                + Convert.ToString(clan.Datum.Day) 
                +"',JMBG=" + clan.JMBG 
                + " WHERE ID="+ Convert.ToString(ID) 
                + ";";
        }
        public void DeleteBazaClanova(int ID)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "DELETE FROM novabaza.clanovi WHERE id=" 
                + Convert.ToString(ID) + ";";
        }
        public void UbaciIzBazeClanove()
        {
            MySqlConnection konekcija;
            MySqlCommand komanda;
            MySqlDataReader reader;
            konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            komanda = new MySqlCommand();
            komanda.CommandText = "SELECT * FROM novabaza.clanovi;";
            konekcija.Open();
            komanda.Connection = konekcija;
            reader = komanda.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DodajClana(reader.GetString(1), reader.GetString(2), reader.GetDateTime(4), reader.GetString(3), "11", 1);
                }
            }
         
 
           
            reader.Close();
            konekcija.Close();
        }
       public void UbaciIzBazeUposlene()
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda;
            MySqlDataReader reader;
            komanda = new MySqlCommand();
            komanda.CommandText = "SELECT * FROM novabaza.uposlenici;";
            konekcija.Open();
            komanda.Connection = konekcija;
            reader = komanda.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DodajUposlenika(reader.GetString(1), reader.GetString(2), reader.GetDateTime(5), reader.GetString(3), null);
                }
            }


            reader.Close();
            konekcija.Close();
        }
        public void CreateBazaUposlenika(Uposlenik uposlenik)
        {
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id = root; database = novabaza");
            MySqlCommand komanda = new MySqlCommand();

            komanda.CommandText = "INSERT INTO novabaza.uposlenici(Ime,Prezime,JMBG,DatumRodjenja,Photo) VALUES('"
                    + uposlenik.Ime + "', '" +
                    uposlenik.Prezime + "', '" +
                    uposlenik.JMBG + "', '"+
                    Convert.ToString(uposlenik.Datum.Year) + "-" +
                    Convert.ToString(uposlenik.Datum.Month) + "-" +
                    Convert.ToString(uposlenik.Datum.Day) + "','" +
                    null
                    +"','"
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

            konekcija.Close();
        }
    }
}