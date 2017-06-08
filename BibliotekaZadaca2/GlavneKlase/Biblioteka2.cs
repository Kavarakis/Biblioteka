using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    partial class Biblioteka
    {
        public void Iznajmi(string sifra, string naslov)
        {
            try
            {
                BazaClanova.Find(x => x.IdSifra == int.Parse(sifra));
            }
            catch (Exception)
            {
                throw new ArgumentException("Niste registrovani/sifra je netačna!");
            }
            try
            {
                BazaKnjiga.Find(x => x.Heading == naslov);
            }
            catch (Exception)
            {
                throw new ArgumentException("Ne postoji knjiga sa nazivom: {0}", naslov);
            }

            if (BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).IstekClanarine <= DateTime.Today)
                throw new ArgumentException("Vaša članarina nije važeća!");

            BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).iznajmljeneKnjige.Add(BazaKnjiga.Find(x => x.Heading == naslov).DajSifru());
            BazaKnjiga.Find(x => x.Heading == naslov).SetujIznamljivanje(true);
        }
        public void Vrati(string sifra, string naslov)
        {
            try
            {
                int id = BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).iznajmljeneKnjige.Find(x => x == BazaKnjiga.Find(y => y.Heading == naslov).DajSifru());
                BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).iznajmljeneKnjige.Remove(id);
                BazaKnjiga.Find(y => y.Heading == naslov).SetujIznamljivanje(false);
            }
            catch (Exception)
            {
                throw new ArgumentException("Pogresan Unos!");
            }

        }
        public void UplataClanarine(string sifra,string tipcl)
        {
            try
            {
                BazaClanova.Find(x => x.IdSifra == int.Parse(sifra));
            }
            catch (Exception)
            {
                throw new ArgumentException("Ne postoji registrovani clan sa unesenom sifrom!");
            }
            float cijena=0;
            if (tipcl == "1")
                cijena=BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).PlacanjeClanarine(true);
            else if(tipcl=="2")
                cijena=BazaClanova.Find(x => x.IdSifra == int.Parse(sifra)).PlacanjeClanarine(false);
            this.stanjeRacuna += cijena;
            Console.WriteLine("Za uplatiti: {0}", cijena);
            Console.ReadLine();
            Console.WriteLine("Clanarina uspješno uplaćena!");
        }
        public int PretragaKnjiga(string temp)
        {
            List<string> lista = new List<string>();
            foreach (var item in BazaKnjiga)
            {
                if (item.ToString().Equals(temp)) return item.DajSifru();
              
            }
            if (lista.Count == 0) throw new ArgumentException("Predmet ne postoji u bazi podataka!");
            return 0;
        }
        public List<Clanovi> DajClanove()
        {
            return BazaClanova;
        }
        public void IzmjeniClana(Clanovi item,int indeks)
        {
            BazaClanova[indeks] = item;
        }
        public List<Uposlenik> DajUposlenike()
        {
            return BazaUposlenika;
        }
    }
}
