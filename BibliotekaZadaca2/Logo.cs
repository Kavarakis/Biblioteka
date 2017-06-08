using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
    public partial class Logo : UserControl

    {
        //static int tajmer = 0;
        Stopwatch sw;
        Thread LogoThread, CounterThread;
        System.Drawing.Graphics objekat;
        Pen mojPen = new Pen(System.Drawing.Color.Blue, 5);
        Rectangle pravougaonik = new Rectangle(10, 10, 120, 100);
        SolidBrush mojBrush = new SolidBrush(System.Drawing.Color.Yellow);
        public Logo()
        {
            InitializeComponent();
            LogoThread = new Thread(CrtajLogo);
            CounterThread = new Thread(PokreniThread);
            LogoThread.IsBackground = true;
            CounterThread.IsBackground = true;
            objekat = panel1.CreateGraphics();
            CounterThread.Start();
            LogoThread.Start();
        }
        public void PokreniThread()
        {
       
            sw = Stopwatch.StartNew();
            

        }
        public void CrtajLogo()
        {
            long x;
            x = sw.ElapsedMilliseconds;
            
            if (sw.ElapsedMilliseconds == 500)
            {
                objekat.DrawRectangle(mojPen, pravougaonik);
                objekat.DrawLine(mojPen, 70, 10, 70, 110);
                objekat.DrawLine(mojPen, 15, 40, 65, 40);
                objekat.DrawLine(mojPen, 15, 60, 65, 60);
                objekat.DrawLine(mojPen, 15, 80, 65, 80);
                objekat.DrawLine(mojPen, 75, 40, 125, 40);
                objekat.DrawLine(mojPen, 75, 60, 125, 60);
                objekat.DrawLine(mojPen, 75, 80, 125, 80);
            }
            if (sw.ElapsedMilliseconds == 1300)
            {
                objekat.FillRectangle(mojBrush, new Rectangle(12, 12, 56, 95));
            }
            if (sw.ElapsedMilliseconds == 2300)
            {
                objekat.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow), new Rectangle(73, 11, 56, 97));
            }
            if (sw.ElapsedMilliseconds == 4500)
            {
                Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
                objekat.DrawString("BIBLIOTEKA", f1, new SolidBrush(System.Drawing.Color.Red), new Rectangle(20, 50, 120, 50));
            }
            else if (sw.ElapsedMilliseconds > 5000)
            {
                 objekat.Clear(Color.White);
            }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LogoThread.Abort();
           
            sw.Stop();
            sw.Restart();
            CounterThread.Abort();

            MessageBox.Show("Proteklo je " +
                sw.Elapsed.ToString() +
                " ms !"
                );
        }

  /*      private void timer1_Tick(object sender, System.EventArgs e)
        {
            objekat = panel1.CreateGraphics();
            if (tajmer == 0)
            {
                objekat.DrawRectangle(mojPen, pravougaonik);
                objekat.DrawLine(mojPen, 70, 10, 70, 110);
                objekat.DrawLine(mojPen, 15, 40, 65, 40);
                objekat.DrawLine(mojPen, 15, 60, 65, 60);
                objekat.DrawLine(mojPen, 15, 80, 65, 80);
                objekat.DrawLine(mojPen, 75, 40, 125, 40);
                objekat.DrawLine(mojPen, 75, 60, 125, 60);
                objekat.DrawLine(mojPen, 75, 80, 125, 80);
                tajmer++;
                timer1.Interval = 1000;
            }
            else if (tajmer == 1)
            {
                objekat.FillRectangle(mojBrush, new Rectangle(12, 12, 56, 95));
                tajmer++;
            }
             else if (tajmer == 2) tajmer++;
            else if (tajmer == 3)
            {
                objekat.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow), new Rectangle(73, 11, 56, 97));
                tajmer++;
            }
            else if (tajmer == 4 || tajmer ==5)
            {

                Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
                objekat.DrawString("BIBLIOTEKA", f1, new SolidBrush(System.Drawing.Color.Red), new Rectangle(20, 50, 120, 50));
                tajmer++;
            }
            else { tajmer = 0; objekat.Clear(Color.White); }
        }
        */
    }
}
