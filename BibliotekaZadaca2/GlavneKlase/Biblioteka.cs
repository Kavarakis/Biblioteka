using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    public partial class Biblioteka
    {
      
        protected List<Knjiga> BazaKnjiga;
        protected List<Clanovi> BazaClanova;
        protected List<Uposlenik> BazaUposlenika;
        private float stanjeRacuna;
       public Biblioteka()
        {
            BazaKnjiga = new List<Knjiga>();
            BazaClanova = new List<Clanovi>();
            BazaUposlenika = new List<Uposlenik>();
        }
        public List<Knjiga> DajKnjige()
        {
            return BazaKnjiga;
        }
        public void DodajKnjigu(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN)
        {
            BazaKnjiga.Add(new ObicnaKnjiga(naslov, autor, godina, izdavac, zanr, ISBN));
        }
        public void DodajStrip(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN, string artist, string akuca, string vrsta, string broj)
        {
            BazaKnjiga.Add(new Stripovi(naslov, autor, godina, izdavac, zanr, ISBN, artist, akuca, vrsta, broj));
        }
        public void DodajNaucniRad(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN, string oblast, string konferencija)
        {
            BazaKnjiga.Add(new NaucniRadovi(naslov, autor, godina, izdavac, zanr, ISBN, konferencija, oblast));
        }
        public void IzbrisiKnjigu(int sifra)
        {
            if (BazaKnjiga.Count() == 0) throw new ArgumentException("Baza je prazna!");
            else
            {
                try
                {
                    BazaKnjiga.Remove(BazaKnjiga.Find(x => x.DajSifru() == sifra));
                }
                catch(Exception)
                {
                    throw new ArgumentException("Baza ne sadrži knjigu pod navedenom sifrom!");
                }
            }
        }
        public void DodajClana(string ime, string prezime, DateTime datum, string jmbg, string sifrazIndeks, int izbor)
        {
            try
            {
                Profesor temp = new Profesor(ime, prezime, datum, jmbg, sifrazIndeks);
                BazaClanova.Add(temp);
                if (izbor == 2)
                {
                    StudentBachelor temp2 = new StudentBachelor(ime, prezime, datum, jmbg, sifrazIndeks);
                    BazaClanova.Add(temp2);
                }
                else if (izbor == 3)
                {
                    StudentMaster temp3 = new StudentMaster(ime, prezime, datum, jmbg, sifrazIndeks);
                    BazaClanova.Add(temp3);
                }
            }
       
           catch(Exception x)
            {
                throw new Exception(x.Message);
            }

        }
        public void DodajUposlenika(string ime, string prezime, DateTime datum, string jmbg,Image slika)
        {
            try
            {
                Uposlenik x = new Uposlenik(ime, prezime, datum, jmbg,slika);
                BazaUposlenika.Add(x);
            }
           catch(Exception a)
            {
                throw new Exception(a.Message);
            }
           
        }
        public void IzbrisiClana(int sifra)
        {
            if (BazaClanova.Count() == 0) throw new ArgumentException("Baza je prazna!");
            else
            {
                try
                {
                    BazaClanova.Remove(BazaClanova.Find(x => x.IdSifra == sifra));
                }
                catch (Exception)
                {
                    throw new ArgumentException("Baza ne sadrži clana pod navedenom sifrom!");
                }
            }
        }
       
    }
    
}
