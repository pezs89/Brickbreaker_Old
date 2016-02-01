using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fallabda
{
    /// <summary>
    /// Base class for nyertes.
    /// </summary>
    class nyertes
    {
        #region Fields

        // The score field of the nyertes class.
        int pontok;

        // The name field of the nyertes class.
        string nev;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the pontok.
        /// </summary>
        /// <value>
        /// The pontok.
        /// </value>
        public int Pontok
        {
            get { return pontok; }
            set { pontok = value; }
        }

        /// <summary>
        /// Gets or sets the nev.
        /// </summary>
        /// <value>
        /// The nev.
        /// </value>
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="nyertes"/> class.
        /// </summary>
        /// <param name="nev1">The input value of the nev field.</param>
        /// <param name="pontok1">The input value of the pontok field.</param>
        public nyertes(string nev1, int pontok1)
        {
            nev = nev1;
            pontok = pontok1;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Overrides the ToString.
        /// </summary>
        /// <returns>The overwritten ToString.</returns>
        public override string ToString()
        {
            return nev + " " + pontok.ToString();
        }

        #endregion Methods
    }
}