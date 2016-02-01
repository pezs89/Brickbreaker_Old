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
    /// <summary>
    /// Interaction logic for Felbontas.
    /// </summary>
    public partial class Felbontas : Form
    {
        #region Fields

        // The window size.
        public int meret = 1;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the meret.
        /// </summary>
        /// <value>
        /// The meret.
        /// </value>
        public int Meret
        {
            get { return meret; }
            set { meret = value; }
        }

        #endregion Properties

        #region Consctuctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Felbontas"/> class.
        /// </summary>
        public Felbontas()
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
            // Set the size and close.
            meret = 1;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Set the size and close.
            meret = 2;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            // Set the size and close.
            meret = 3;
            this.Close();
        }

        #endregion Methods
    }
}