using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fallabda
{
    public partial class Felbontas : Form
    {
        public Felbontas()
        {
            InitializeComponent();
        }
        public int meret = 1; //méret meghatározása
        public int Meret
        {
            get { return meret; }
            set { meret = value; }
        }
//kis méret
        private void button1_Click(object sender, EventArgs e)
        {
            meret = 1;
            this.Close();
        }
//közepes méret
        private void button2_Click_1(object sender, EventArgs e)
        {
            meret = 2;
            this.Close();
        }
//nagy méret
        private void button3_Click_1(object sender, EventArgs e)
        {
            meret = 3;
            this.Close();
        } 
    }
}
