using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace fallabda
{
    /// <summary>
    /// Base class for tegla.
    /// </summary>
    class tegla
    {
        #region Fields

        // The xPosition field of the tegla calss.
        int posx;

        // The yPosition field of the tegla calss.
        int posy;

        // The brush that fills the object's picture with color.
        Brush B;

        // The pen that creates the outline for the object's picture.
        Pen P;

        // The width field of the tegla class.
        int dx;

        // The height field of the tegla class.
        int dy;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the posx.
        /// </summary>
        /// <value>
        /// The posx.
        /// </value>
        public int Posx
        {
            get { return posx; }
            set { posx = value; }
        }

        /// <summary>
        /// Gets or sets the posy.
        /// </summary>
        /// <value>
        /// The posy.
        /// </value>
        public int Posy
        {
            get { return posy; }
            set { posy = value; }
        }

        /// <summary>
        /// Gets or sets the dx.
        /// </summary>
        /// <value>
        /// The dx.
        /// </value>
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }

        /// <summary>
        /// Gets or sets the dy.
        /// </summary>
        /// <value>
        /// The dy.
        /// </value>
        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="tegla"/> class.
        /// </summary>
        /// <param name="ujx">The input value of the posx field.</param>
        /// <param name="ujy">The input value of the posy field.</param>
        /// <param name="ujdx">The input value of the dx field.</param>
        /// <param name="ujdy">The input value of the dy field.</param>
        /// <param name="ujB">The input value of the B field.</param>
        /// <param name="ujP">The input value of the P field.</param>
        public tegla(int ujx, int ujy, int ujdx, int ujdy, Brush ujB, Pen ujP)
        {
            posx = ujx;
            posy = ujy;
            dx = ujdx;
            dy = ujdy;
            B = ujB;
            P = ujP;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Paints the tegla.
        /// </summary>
        /// <param name="g">The graphics input.</param>
        public void Paint(Graphics g)
        {
            g.FillRectangle(B, posx, posy, dx, dy);
            g.DrawRectangle(P, posx, posy, dx, dy);
        }

        #endregion Methods
    }
}