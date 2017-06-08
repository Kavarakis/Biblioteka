using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    class NaucniRadovi : Knjiga
    {
        private string konferencija { get; set; }
        private string oblast { get; set; }
        private string OblikReferenciranja { get; set; }
        public NaucniRadovi(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN,string konf,string oblast) : base(naslov, autor, godina, izdavac, zanr, ISBN)
        {
            this.konferencija = konf;
            this.oblast = oblast;
        }

       
   
        public override string ToString()
        {
            return naslov+" "+autori.ToString()+" (" + isbn + ")"+" "+oblast+" "+konferencija+" "+nazivIzdavaca+", "+godinaIzdanja;
        }
       public void generalneInformacije()
        {
            Console.WriteLine("Naslov: {0} ", naslov);
            Console.WriteLine("Godina izdanja: {0} ",godinaIzdanja);
            Console.WriteLine("Izdavac: {0}", nazivIzdavaca);
        }
       public void autoriRada()
        {
            autori.ToString();
        }
       public string oblastRada()
        {
            return this.oblast;
        }
       public string oblikReferenciranja()
        {
            return OblikReferenciranja;
        }
    }
 
}
