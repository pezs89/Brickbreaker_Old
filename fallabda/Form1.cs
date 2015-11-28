using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace fallabda
{
    public partial class Form1 : Form
    {
//változók
        #region
        List<tegla> brick = new List<tegla>(); //téglákat tartalmazó lista
        List<Labda> ball = new List<Labda>(); //labdákat tartalmazó lista
        List<nyertes> nyertesek = new List<nyertes>(); //nyerteseket tartalmazó lista
        int hiba = 3; //az életet számontartó változó
        int uxsize = 40; //az ütő szélessége
        int uysize = 10; //az ütő magassága
        int ux = 10; //az ütő viszszintes koordinátája
        int uy; //az ütő függőleges koordinátája
        bool mehet; //a labda indítása
        int pont = 0; //pontszám
        string név = ""; //név írásra/olvasásra
        string pontnev = ""; //pontszám írásra/olvasásra
        bool valtozhat = true; //ablakméretezés engedélyezése
        int tegladarab = 0; //téglák száma
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
//téglák kirajzolása
        public void TeglatKirajzol()
        {
            if (brick.Count != 0)
            {
                brick.Clear();
                for (int j = 0; j < ClientSize.Width; j += 40)
                {
                    for (int i = 20; i < ClientSize.Height / 2; i += 20)
                    {
                        tegla t = new tegla(j, i, 40, 20, Brushes.Aqua, Pens.Beige);
                        brick.Add(t);
                    }
                }
                tegladarab = brick.Count;
            }
            else
            {
                for (int j = 0; j < ClientSize.Width; j += 40)
                {
                    for (int i = 20; i < ClientSize.Height / 2; i += 20)
                    {
                        tegla t = new tegla(j, i, 40, 20, Brushes.Aqua, Pens.Beige);
                        brick.Add(t);
                    }
                }
                tegladarab = brick.Count;
            }

        }
//rajzolás
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);
                foreach (tegla t in brick) t.Paint(g);
                foreach (Labda l in ball) l.Paint(g);
                //foreach (uto u in table) u.Paint(g);
                g.FillRectangle(Brushes.Brown, ux, uy, uxsize, uysize);
                g.DrawString("Élet: " + hiba, new Font("Arial", 10), Brushes.Black, 10, 25);
                g.DrawString("Pontszám: " + pont, new Font("Arial", 10), Brushes.Black, 100, 25);
                g.DrawString("Téglák: " + brick.Count, new Font("Arial", 10), Brushes.Black, 220, 25);
                DoubleBuffered = true;
                if (hiba <= 0)
                {
                    g.Clear(Color.White);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
//timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            foreach (Labda a in ball)
            {
                if (a.pattog(ClientRectangle.Width, uy + 15, ux, uxsize, uy, uysize, mehet, hiba, brick))
                {
                    hiba--;
                    mehet = false;
                    if (hiba <= 0)
                    {
                        Vege();
                    }
                }
            }
            foreach (Labda b in ball)
            {
                pont = b.pontszamitas();
            }
            if (brick.Count == 0)
            {
                Vege();
            }
            Invalidate();
        }
//játék vége
        public void Vege()
        {
            timer1.Enabled = false;
            if (hiba == 0)
            {
                MessageBox.Show("Elfogyott az életed, játék vége!", "Falladba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Nyertél! Vége!");
            }
            eredmény er = new eredmény();
            if (DialogResult.OK == er.ShowDialog())
            {
                név = er.nev;
                nyertesek.Add(new nyertes(név, pont));
                takarit();
                for (int i = 0; i < nyertesek.Count; i++)
                {
                    pontnev = pontnev + nyertesek[i].ToString() + "\n";
                }
                MessageBox.Show("AZ ön neve: " + név + "\n Az ön eredménye: " + pont.ToString());
            }
        }
//ütő mozgatása
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X+(uxsize/2)>=ClientSize.Width)
            {
                ux = ClientSize.Width - uxsize;
            }
            else if (e.X-(uxsize/2) <= 0)
            {
                ux = 0;
            }
            else
            {
                ux = e.X - uxsize / 2;
            }
            Invalidate();
        }
//könnyű nehézségi szint
        private void könnyűToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uy = ClientRectangle.Height - uysize;

            valtozhat = false;
            mehet = false;

            int temp = ball.Count;
            if (temp <= 0)
            {
                init_labda l0 = new init_labda(60, 60, 10, 10, 5, 10, Brushes.Red, Pens.Black);
                ball.Add(l0);
            }
            else
            {
                ball.Clear();
                init_labda l0 = new init_labda(60, 60, 10, 10, 5, 10, Brushes.Red, Pens.Black);
                ball.Add(l0);
            }
            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }
//közepes nehézségi szint
        private void közepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uy = ClientRectangle.Height - uysize;
            valtozhat = false;
            mehet = false;
            int temp = ball.Count;
            if (temp <= 0)
            {
                init_labda l1 = new init_labda(60, 60, 10, 10, 7, 14, Brushes.Red, Pens.Black);
                ball.Add(l1);
            }
            else
            {
                ball.Clear();
                init_labda l1 = new init_labda(60, 60, 10, 10, 7, 14, Brushes.Red, Pens.Black);
                ball.Add(l1);
            }
            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }
//nehéz nehézségi szint
        private void nehézToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uy = ClientRectangle.Height - uysize;
            valtozhat = false;
            mehet = false;
            int temp = ball.Count;
            if (temp <= 0)
            {
                init_labda l2 = new init_labda(60, 60, 10, 10, 10, 20, Brushes.Red, Pens.Black);
                ball.Add(l2);
            }
            else
            {
                ball.Clear();
                init_labda l2 = new init_labda(60, 60, 10, 10, 10, 20, Brushes.Red, Pens.Black);
                ball.Add(l2);
            }
            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }
//szünet (pause)
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p')
            {
                timer1.Enabled = false;
                e.Handled = true;
                if (MessageBox.Show("Szünet! Folytatod?", "Fallabda", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    Close();
                }
            }
            else
            {
                e.Handled = false;
                timer1.Enabled = true;
            }
        }
//billentyűvel történő irányítás
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                mehet = true;
            }
        }
//névjegy
        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Név: Péter Zsolt" + "\n" + "Neptun kód: GZOG8N");
        }
//elindítja a labdát
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            mehet = true;
        }
//kilépés
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
//beolvasott fájlba adatírás
        private void fajliras()
        {
            string FileName = "highs.ore";
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter wr = new BinaryWriter(fs);
            for (int i = 0; i < nyertesek.Count; i++)
            {
                wr.Write(nyertesek[i].Nev);
                wr.Write(nyertesek[i].Pontok);
            }
            wr.Close();
            fs.Close();
        }
//beolvasott fájl adatainak feldolgozása
        private void fajlolvasas()
        {
            takarit();
            bool igaz = false;
            bool eredeti = false;
            int fre = 0;
            string FileName = "highs.ore";
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader rd = new BinaryReader(fs);
            while (rd.BaseStream.Position != rd.BaseStream.Length)
            {
                string név = rd.ReadString();
                int pont = rd.ReadInt32();
                for (int j = 0; j < nyertesek.Count; j++)
                {
                    if (nyertesek[j].Nev == név)
                    {
                        igaz = true;
                        if (nyertesek[j].Pontok < pont)
                        {
                            eredeti = true;
                            fre = j;
                        }
                    }
                    else
                    {
                        igaz = false;
                    }
                }
                if (!igaz) nyertesek.Add(new nyertes(név, pont));
                else
                {
                    if (eredeti)
                    {
                        nyertesek.RemoveAt(fre);
                        nyertesek.Add(new nyertes(név, pont));
                    }
                }
            }
            rd.Close();
            fs.Close();
        }
//a fájl átrendezése
        private void takarit()
        {
            for (int j = 0; j < nyertesek.Count; j++)
            {
                for (int i = nyertesek.Count - 1; j != i; i--)
                {
                    if (nyertesek[i].Nev == nyertesek[j].Nev)
                    {
                        if (nyertesek[i].Pontok > nyertesek[j].Pontok)
                        {
                            nyertesek.RemoveAt(j);
                        }
                        else
                        {
                            nyertesek.RemoveAt(i);
                        }
                    }
                }
            }
        }
//ponlista megjelenítése
        private void pontlistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fajlolvasas();
            fajliras();
            pontnev = "";
            takarit();
            for (int i = 0; i < nyertesek.Count; i++)
            {
                pontnev = pontnev + nyertesek[i].ToString() + "\n";
            }
            MessageBox.Show(pontnev, "Eredmények:");
            pontnev = "";
        }
//átméretezés
        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Felbontas F = new Felbontas();
            if (F.ShowDialog() == DialogResult.OK)
            {
                if (valtozhat == true)
                {
                    switch (F.meret)
                    {
                        case 1:
                            this.ClientSize = new System.Drawing.Size(370, 388);
                            break;
                        case 2:
                            this.ClientSize = new System.Drawing.Size(432, 453);
                            break;
                        case 3:
                            this.ClientSize = new System.Drawing.Size(518, 543);
                            break;
                    }
                }
            }
        }
//ablak átméretezése
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
