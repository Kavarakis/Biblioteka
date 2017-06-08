using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaZadaca2
{
    class ObicnaKnjiga : Knjiga
    {
        public ObicnaKnjiga(string naslov, string autor, string godina, string izdavac, string zanr, string ISBN) : base(naslov, autor, godina, izdavac, zanr, ISBN)
        {
          
        }
        public override string ToString()
        {
            return naslov + " " + autori.ToString() + " (" + isbn + ")" + " " + nazivIzdavaca + ", " + godinaIzdanja;
        }
    }
}
