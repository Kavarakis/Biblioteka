using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    class StudentBachelor : Clanovi, Ipopust
    {
        private string indeks { get; set; }
        public StudentBachelor(string ime, string prezime, DateTime datum, string jmbg,string indeks) : base(ime, prezime, datum, jmbg)
        {
            this.indeks = indeks;
        }

        public float ObracunPopusta()
        {
            clanarina -= ((float)12.5 * clanarina) / ((float)100);
            return clanarina;
        }
        public override float PlacanjeClanarine(bool izbor,float iznos)
        {
          
            if (izbor) vrsta = VrstaClanarine.godisnja;
            else vrsta = VrstaClanarine.mjesecna;


            if (vrsta == VrstaClanarine.mjesecna)
            {
                istekClanarine.AddMonths(1);
                iznos = clanarina;
            }
            else if (vrsta == VrstaClanarine.godisnja)
            {
                istekClanarine.AddYears(1);
                clanarina = clanarina * 12;
            }
            return ObracunPopusta();
        }


    }
}
