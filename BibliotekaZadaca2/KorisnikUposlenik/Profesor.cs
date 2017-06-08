using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    class Profesor : Clanovi, Ipopust
    {
        private string sifraZaposlenog;

        public Profesor(string ime, string prezime, DateTime datum, string jmbg,string sifraZ) : base(ime, prezime, datum, jmbg)
        {
            sifraZaposlenog = sifraZ;
        }

        public float ObracunPopusta()
        {
            clanarina -= ((float)15 * clanarina) / ((float)100);
            return clanarina;
        }
       
        public override float PlacanjeClanarine( bool izbor, float iznos)
        {
            
            if (izbor) vrsta = VrstaClanarine.godisnja;
            else vrsta = VrstaClanarine.mjesecna;
           
            
            if (vrsta == VrstaClanarine.mjesecna)
            {
                istekClanarine.AddMonths(1);
                clanarina = iznos;
            }
            else if (vrsta == VrstaClanarine.godisnja)
            {
                istekClanarine.AddYears(1);
               clanarina=iznos* 12;
            }
            return ObracunPopusta();
        }
    }
}
