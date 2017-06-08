
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
   public class Uposlenik : Osoba
    {
        protected Image slika { get; set; }
        //protected string SlikaPath { get; set; }
        public Uposlenik(string ime, string prezime, DateTime datum, string jmbg,Image photo) : base(ime, prezime, datum, jmbg)
        {
            this.slika = photo;
        }
        public override string ToString()
        {
            return ime + " " + prezime + " " + "(" + Jmbg + ") ";
        }
        public Image DajSliku()
        {
            return this.slika;
        }
    }
   
}
