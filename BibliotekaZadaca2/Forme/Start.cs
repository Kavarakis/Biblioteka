using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotekaZadaca2
{
    public partial class Start : Form
    {

        Administrator admin;
        Stopwatch sw;
        Thread LogoThread, CounterThread;
        System.Drawing.Graphics objekat;
        Pen mojPen = new Pen(System.Drawing.Color.Blue, 5);
        Rectangle pravougaonik = new Rectangle(10, 10, 120, 100);
        SolidBrush mojBrush = new SolidBrush(System.Drawing.Color.Yellow);
        public Start(Administrator x=null)
        {
            InitializeComponent();
            if (x != null) admin = x;
           else  admin = new Administrator();
            admin.UbaciIzBazeClanove();
           // admin.UbaciIzBazeUposlene();
            
            LogoThread = new Thread(CrtajLogo);
            CounterThread = new Thread(PokreniThread);
            LogoThread.IsBackground = true;
            CounterThread.IsBackground = true;
            objekat = panel1.CreateGraphics();
            CounterThread.Start();
            LogoThread.Start();
            CheckForIllegalCrossThreadCalls = false;

        }
        public void PokreniThread()
        {
            sw = new Stopwatch();
            sw.Start();
        }
        public void CrtajLogo()
        {
            while (true) { 
                objekat.DrawRectangle(mojPen, pravougaonik);
                objekat.DrawLine(mojPen, 70, 10, 70, 110);
                objekat.DrawLine(mojPen, 15, 40, 65, 40);
                objekat.DrawLine(mojPen, 15, 60, 65, 60);
                objekat.DrawLine(mojPen, 15, 80, 65, 80);
                objekat.DrawLine(mojPen, 75, 40, 125, 40);
                objekat.DrawLine(mojPen, 75, 60, 125, 60);
                objekat.DrawLine(mojPen, 75, 80, 125, 80);
                Thread.Sleep(500);
                objekat.FillRectangle(mojBrush, new Rectangle(12, 12, 56, 95));
                Thread.Sleep(500);
                objekat.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow), new Rectangle(73, 11, 56, 97));
                Thread.Sleep(500);
                Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
                objekat.DrawString("BIBLIOTEKA", f1, new SolidBrush(System.Drawing.Color.Red), new Rectangle(20, 50, 120, 50));
 
                Thread.Sleep(500);

                objekat.Clear(Color.White);
                Thread.Sleep(500);
             }

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            LogoThread.Abort();

            sw.Stop();
            sw.Restart();
            CounterThread.Abort();
            //button1.Text = "";
            MessageBox.Show("Proteklo je vremena u threadu:  " +
                sw.Elapsed.ToString() +
                " ms !"
                );
        }
        private void članToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClanReg novi = new ClanReg(admin);
            this.Hide();
            novi.ShowDialog();
            this.Close();
        }

        private void članToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Log novi = new Log(admin);
            this.Hide();
            novi.ShowDialog();
            this.Close();
        }

        private void uposlenikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log novi = new Log(admin);
            this.Hide();
            novi.ShowDialog();
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UposlenikReg novi = new UposlenikReg(admin);
            this.Hide();
            novi.ShowDialog();
           this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LogoThread.Abort();

            sw.Stop();
            sw.Restart();
            CounterThread.Abort();
            button1.Text = "NE radi";
            MessageBox.Show("Proteklo je " +
                sw.Elapsed.ToString() +
                " ms !"
                );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdministratorPanel novi = new AdministratorPanel(admin);
            this.Hide();
            novi.ShowDialog();
            this.Close();
        }
    }
}
