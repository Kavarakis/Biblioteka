using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    public enum VrstaClanarine{mjesecna=0,godisnja=1 };
    public abstract class Clanovi: Osoba
    {
        protected static float clanarina { get; set; } = 25;
        protected VrstaClanarine vrsta;
        protected DateTime istekClanarine { get; set; }
      //  public bool uplata = false;
        
        public List<int> iznajmljeneKnjige;

        public Clanovi(string ime, string prezime, DateTime datum, string jmbg) : base(ime, prezime, datum, jmbg)
        {
            IdSifra++;
            istekClanarine = IstekClanarine;
        }

        //private static double popust { get; set; }

        public DateTime IstekClanarine
        {
            get
            {
                return istekClanarine;
            }
            set
            {
                istekClanarine = DateTime.Today; 
            }
        }
        public virtual void SetMjesecnaClanarina(float iznos)
        {
            clanarina = iznos;
        }
        
        
        public virtual bool Uplata()
        {
            if (istekClanarine > DateTime.Today) return true;
            else return false;
        }
        public abstract float PlacanjeClanarine( bool izbor, float iznos = 25);
        public override string ToString()
        {
            return ime + " " + prezime + " " + "(" + Jmbg + ") ";
        }
        
        
    }
  
      
}
