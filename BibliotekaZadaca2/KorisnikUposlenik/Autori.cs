using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BibliotekaZadaca2
{
    public class Autori
    {
        public List<string> listaAutori;
        public Autori(string s)
        {
           listaAutori= s.Split(',').ToList();
          
        }
      
        public List<string> Vrati()
        {
            return listaAutori;
        }
        public override string ToString()
        
        {
            string temp=null,check=null;
            check = listaAutori[listaAutori.Count-1];
            foreach ( string item in listaAutori)
            {
                temp+= item;

                if (item == check) continue;
                else temp += ", ";
                
            }
            if (string.IsNullOrEmpty(temp)) throw new ArgumentException("Ne postoje autori!");
            return temp;
        }
        public string PretraziAutore(string temp)
        {
            foreach (string item in listaAutori)
            {
                if (item.Contains(temp)) return item;
            }
             return null;
           // throw new ArgumentException("Ne postoji autor");
        }
    }
}
