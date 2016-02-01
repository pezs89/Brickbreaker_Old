using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace fallabda
{
    /// <summary>
    /// Base class for uto.
    /// </summary>
    class uto
    {
        #region Fields

        // The width field of the uto class.
        int uxsize;

        // The height field of the uto class.
        int uysize;

        // The xPosition field of the uto calss.
        int ux;

        // The yPosition field of the uto class.
        int uy;

        // The brush that fills the object's picture with color.
        Brush B;

        // The pen that creates the outline for the object's picture.
        Pen P;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the uy.
        /// </summary>
        /// <value>
        /// The uy.
        /// </value>
        public int Uy
        {
            get { return uy; }
            set { uy = value; }
        }

        /// <summary>
        /// Gets or sets the ux.
        /// </summary>
        /// <value>
        /// The ux.
        /// </value>
        public int Ux
        {
            get { return ux; }
            set { ux = value; }
        }

        /// <summary>
        /// Gets or sets the uysize.
        /// </summary>
        /// <value>
        /// The uysize.
        /// </value>
        public int Uysize
        {
            get { return uysize; }
            set { uysize = value; }
        }

        /// <summary>
        /// Gets or sets the uxsize.
        /// </summary>
        /// <value>
        /// The uxsize.
        /// </value>
        public int Uxsize
        {
            get { return uxsize; }
            set { uxsize = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="uto"/> class.
        /// </summary>
        /// <param name="ujux">The input value of the ux field.</param>
        /// <param name="ujuy">The input value of the uy field.</param>
        /// <param name="ujuxsize">The input value of the uxsize field.</param>
        /// <param name="ujuysize">The input value of the uysize field.</param>
        public uto(int ujux, int ujuy, int ujuxsize, int ujuysize)
        {
            ux = ujux;
            uy = ujuy;
            uxsize = ujuxsize;
            uysize = ujuysize;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Paints the uto.
        /// </summary>
        /// <param name="g">The graphics input.</param>
        public void Paint(Graphics g)
        {
            g.FillRectangle(B, ux, uy, uxsize, uysize);
            g.DrawRectangle(P, ux, uy, uxsize, uysize);
            g.DrawEllipse(P, (ux + uxsize), uy, 10, 10);
            g.FillEllipse(B, (ux + uxsize), uy, 10, 10);
            g.DrawEllipse(P, ux, (uy - 10), 10, 10);
            g.FillEllipse(B, ux, (uy - 10), 10, 10);
        }

        #endregion Methods
    }
}