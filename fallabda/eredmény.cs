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
    /// <summary>
    /// Interaction logic for eredmény.
    /// </summary>
    public partial class eredmény : Form
    {
        #region Properties

        /// <summary>
        /// Gets the nev.
        /// </summary>
        public string nev
        {
            get { return textBox1.Text; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="eredmény"/> class.
        /// </summary>
        public eredmény()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Close
            this.Close();
        }

        #endregion Methods
    }
}