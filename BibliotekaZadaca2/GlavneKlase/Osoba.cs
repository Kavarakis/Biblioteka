using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    public abstract class Osoba
    {
        private static int brojac { get; set; }
        public int IdSifra { get; set; }
        protected string ime { get; set; }
        protected string prezime { get; set; }
        protected string username { get; set; }
        protected string Jmbg { get; set; }
        protected DateTime datumRodjenja { get; set; }
   /*     {
            get
            {
                return datumRodjenja;
            }
            set
            {
                if (value > DateTime.Today) throw new ArgumentException("Pogresan datum rođenja!");
                else datumRodjenja = value;
            }
        }
        */
        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
            }
        }
        public string Prezime
        {
            get
            {
               return prezime;
            }
            set
            {
                prezime = value;
            }
        }
        public DateTime Datum
        {
            get
            {
                return datumRodjenja;
            }
            set
            {
                datumRodjenja = value;
            }
        }
        public string JMBG
        {
            get
            {
                return Jmbg;
            }
            set
            {
                if (!CheckMaticni(value)) throw new Exception("Neispravan JMBG!");

                this.Jmbg = value;
            
            }
        }
        public Osoba(string ime, string prezime, DateTime datum, string jmbg)
        {
            IdSifra = ++brojac;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datum;
            JMBG = jmbg;
        }
        public static bool CheckMaticni(string jmbg)
        { 
            int DD, MM, GGG, RR, BBB, K;
            if (Regex.IsMatch(jmbg, "[a-zA-Z]")) return false;
            DD = int.Parse(jmbg.Substring(0, 2));
            MM = Int32.Parse(jmbg.Substring(2, 2));
            GGG = Int32.Parse(jmbg.Substring(4, 3));
            RR = Int32.Parse(jmbg.Substring(7, 2));
            BBB = Int32.Parse(jmbg.Substring(9, 3));
            K = Int32.Parse(jmbg.Substring(12, 1));
            DateTime datum = DateTime.Today;
            if (DD > 31 || DD < 1) return false;
            if (MM > 12 || MM < 1) return false;
            if (GGG > DateTime.Today.Year || GGG < 1) return false;
            if (RR > 96 || RR < 1) return false;
            //BBB se ne treba provjeravati jer varira od 000-999 za muskarce i zene
            int L = 0, brojac = 7, m = 0;
            for (int i = 0; i < jmbg.Length - 1; i++)
            {
                L += brojac * int.Parse(jmbg[i].ToString());
                if (brojac == 2)
                {
                    brojac = 7;
                    continue;
                }
                else brojac--;

            }
            m = L % 11;
            if (m > 1) L = (11 - m);
            else L = m;
            if (K != L) return false;

            return true;
        }
    }
}
