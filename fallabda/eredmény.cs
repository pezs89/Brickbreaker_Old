using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fallabda
{
    public partial class eredmény : Form
    {
        public eredmény()
        {
            InitializeComponent();
        }
//név átadása
        public string nev
        {
            get { return textBox1.Text; }
        }
//ablak bezárása
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
