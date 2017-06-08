using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
   static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Administrator admin = new Administrator();
           
            Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
 
            Application.Run(new Start(admin));
        }
        

    }

    }

