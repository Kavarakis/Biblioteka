using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    
    class Stripovi : Knjiga
    {
        private string imeAnimatorskeKuce { get; set; }
        private Autori umjetnici;
        private int brojIzdanja { get; set; }
        private string vrstaIzdanja;

        public Stripovi(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN, string Umjetnici, string animKuca, string vrsta, string broj) : base(naslov, autor, godina, izdavac, zanr, ISBN)
        {
            this.imeAnimatorskeKuce = animKuca;
            umjetnici = new Autori(Umjetnici);
            vrstaIzdanja= vrsta;
            brojIzdanja = Int32.Parse(broj);
        }

        public static bool VrstaIzdanja(string vrsta)
        {

            if (vrsta.Equals("Obicno") || vrsta.Equals("Specijalno")) return true;
            else return false;
        }
        public List<string> Umjetnici
        {
            get
            {
                return umjetnici.Vrati();
            }
            set
            {
                
            }
        }

        public override string ToString()
        {
            return naslov + " " + autori.ToString() +" "+umjetnici.ToString()+" (" + isbn + ")" + " " + imeAnimatorskeKuce + " " + vrstaIzdanja +" "+brojIzdanja+" "+ nazivIzdavaca + ", " + godinaIzdanja;

        }

    }
}
