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
    /// <summary>
    /// Interaction logic for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Fields

        // Bricks.
        List<tegla> brick = new List<tegla>();

        // Balls.
        List<Labda> ball = new List<Labda>();

        // Rackets.
        List<uto> table = new List<uto>();

        // Winners.
        List<nyertes> nyertesek = new List<nyertes>();

        // The life point.
        int hiba = 3;

        // The width of the racket.
        int uxsize = 40;

        // The height of the racket.
        int uysize = 10;

        // The xPosition of the racket.
        int ux = 10;

        // The yPosition of the racket.
        int uy;

        // Start the ball.
        bool mehet;

        // The score.
        int pont = 0;

        // The name of the player.
        string név = "";

        // The score of the player.
        string pontnev = "";

        // Enable window sizing.
        bool valtozhat = true;

        // The window size.
        int valtozas;

        // The number of bricks.
        int tegladarab = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Drawing the bricks.
        /// </summary>
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

        /// <summary>
        /// Handles the Paint event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw.
            try
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);

                foreach (tegla t in brick) t.Paint(g);
                foreach (Labda l in ball) l.Paint(g);

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

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Refresh
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
                // Get the score.
                pont = b.pontszamitas();
            }

            if (brick.Count == 0)
            {
                // Game over.
                Vege();
            }

            Invalidate();
        }

        /// <summary>
        /// Game over.
        /// </summary>
        public void Vege()
        {
            timer1.Enabled = false;

            if (hiba == 0)
            {
                // No more life's left.
                MessageBox.Show("Elfogyott az életed, játék vége!", "Falladba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // No more brick's left.
                MessageBox.Show("Nyertél! Vége!");
            }

            eredmény er = new eredmény();

            // Submit the score to the highscores.
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

        /// <summary>
        /// Handles the MouseMove event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // The racket follows the mouse.
            if (e.X + (uxsize / 2) >= ClientSize.Width)
            {
                ux = ClientSize.Width - uxsize;
            }
            else if (e.X - (uxsize / 2) <= 0)
            {
                ux = 0;
            }
            else
            {
                ux = e.X - uxsize / 2;
            }

            Invalidate();
        }

        /// <summary>
        /// Handles the Click event of the könnyűToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void könnyűToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the difficulty to easy.
            uy = ClientRectangle.Height - uysize;
            mehet = false;
            int temp = ball.Count;

            if (temp <= 0)
            {
                init_labda l0 = new init_labda(60, 60, 10, 10, 10, 20, Brushes.Red, Pens.Black);
                ball.Add(l0);
            }
            else
            {
                ball.Clear();
                init_labda l0 = new init_labda(60, 60, 10, 10, 10, 20, Brushes.Red, Pens.Black);
                ball.Add(l0);
            }

            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }

        /// <summary>
        /// Handles the Click event of the közepesToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void közepesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the difficulty to medium.
            uy = ClientRectangle.Height - uysize;
            mehet = false;
            int temp = ball.Count;

            if (temp <= 0)
            {
                init_labda l1 = new init_labda(60, 60, 10, 10, 15, 30, Brushes.Red, Pens.Black);
                ball.Add(l1);
            }
            else
            {
                ball.Clear();
                init_labda l1 = new init_labda(60, 60, 10, 10, 15, 30, Brushes.Red, Pens.Black);
                ball.Add(l1);
            }

            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }

        /// <summary>
        /// Handles the Click event of the nehézToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void nehézToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the difficulty to hard.
            uy = ClientRectangle.Height - uysize;
            mehet = false;
            int temp = ball.Count;

            if (temp <= 0)
            {
                init_labda l2 = new init_labda(60, 60, 10, 10, 20, 40, Brushes.Red, Pens.Black);
                ball.Add(l2);
            }
            else
            {
                ball.Clear();
                init_labda l2 = new init_labda(60, 60, 10, 10, 20, 40, Brushes.Red, Pens.Black);
                ball.Add(l2);
            }

            TeglatKirajzol();
            timer1.Enabled = true;
            hiba = 3;
        }

        /// <summary>
        /// Handles the KeyPress event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // The p key was hit.
            if (e.KeyChar == 'p')
            {
                // Pause the game.
                timer1.Enabled = false;
                e.Handled = true;

                if (MessageBox.Show("Szünet! Folytatod?", "Fallabda", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Continue
                    timer1.Enabled = true;
                }
                else
                {
                    // Exit
                    Close();
                }
            }
            else
            {
                // Continue the game.
                e.Handled = false;
                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // The space key was hit.
            if (e.KeyData == Keys.Space)
            {
                // Start the ball.
                mehet = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the névjegyToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the credits.
            MessageBox.Show("Név: " + "\n" + "Neptun kód: ");
        }

        /// <summary>
        /// Handles the MouseClick event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Start the ball.
            mehet = true;
        }

        /// <summary>
        /// Handles the Click event of the kilepésToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void kilépésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit
            Close();
        }

        /// <summary>
        /// Write in the highscores file.
        /// </summary>
        private void fajliras()
        {
            string FileName = @"../../Resources/highs.ore";

            // Open the file.
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            BinaryWriter wr = new BinaryWriter(fs);

            // Write in the file.
            for (int i = 0; i < nyertesek.Count; i++)
            {
                wr.Write(nyertesek[i].Nev);
                wr.Write(nyertesek[i].Pontok);
            }

            // Close the binaryWriter and the fileStream.
            wr.Close();
            fs.Close();
        }

        /// <summary>
        /// Read the highscores file.
        /// </summary>
        private void fajlolvasas()
        {
            takarit();
            bool igaz = false;
            bool eredeti = false;
            int fre = 0;
            string FileName = @"../../Resources/highs.ore";

            // Open the file.
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader rd = new BinaryReader(fs);

            // Read the items.
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

                if (!igaz)
                {
                    nyertesek.Add(new nyertes(név, pont));
                }
                else
                {
                    if (eredeti)
                    {
                        nyertesek.RemoveAt(fre);
                        nyertesek.Add(new nyertes(név, pont));
                    }
                }
            }

            // Close the binaryReader and fileStream.
            rd.Close();
            fs.Close();
        }

        /// <summary>
        /// Clear the winners list.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the pontlistaToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pontlistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the highscore list.
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

        /// <summary>
        /// Handles the Click event of the beállításokToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the window size.
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

        /// <summary>
        /// Handles the Resize event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion Methods
    }
}