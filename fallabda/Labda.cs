using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace fallabda
{
    /// <summary>
    /// Base class for Labda.
    /// </summary>
    abstract class Labda
    {
        #region Fields

        // The horisontalMovement field of the Ladba calss.
        int dx;

        // The verticalMovement field of the Labda calss.
        int dy;

        // The xPosition field of the Labda calss.
        int cx;

        // The yPosition field of the Labda calss.
        int cy;

        // The brush that fills the object's picture with color.
        public Brush B;

        // The pen that creates the outline for the object's picture.
        public Pen P;

        // The radius field of the Labda class.
        int r;

        // The score field of the Labda class.
        int pont = 0;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the pont.
        /// </summary>
        /// <value>
        /// The pont.
        /// </value>
        public int Pont
        {
            get { return pont; }
            set { pont = value; }
        }

        /// <summary>
        /// Gets or sets the r.
        /// </summary>
        /// <value>
        /// The r.
        /// </value>
        public int R
        {
            get { return r; }
            set { r = value; }
        }

        /// <summary>
        /// Gets or sets the cx.
        /// </summary>
        /// <value>
        /// The cx.
        /// </value>
        public int Cx
        {
            get { return cx; }
            set { cx = value; }
        }

        /// <summary>
        /// Gets or sets the cy.
        /// </summary>
        /// <value>
        /// The cy.
        /// </value>
        public int Cy
        {
            get { return cy; }
            set { cy = value; }
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

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Labda"/> class.
        /// </summary>
        /// <param name="ujcx">The input value of the cx field.</param>
        /// <param name="ujcy">The input value of the cy field.</param>
        /// <param name="ujdx">The input value of the dx field.</param>
        /// <param name="ujdy">The input value of the dy field.</param>
        /// <param name="ujB">The input value of the B field.</param>
        /// <param name="ujP">The input value of the P field.</param>
        /// <param name="ujR">The input value of the r field.</param>
        public Labda(int ujcx, int ujcy, int ujdx, int ujdy, Brush ujB, Pen ujP, int ujR)
        {
            cx = ujcx;
            cy = ujcy;
            dx = ujdx;
            dy = ujdy;
            B = ujB;
            P = ujP;
            r = ujR;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Returns the score.
        /// </summary>
        /// <returns>The pont field.</returns>
        public int pontszamitas()
        {
            return pont;
        }

        /// <summary>
        /// Paints the Labda.
        /// </summary>
        /// <param name="g">The graphics input.</param>
        abstract public void Paint(Graphics g);

        /// <summary>
        /// Moves the Labda.
        /// </summary>
        /// <param name="maxx">The window's width.</param>
        /// <param name="maxy">The window's height.</param>
        /// <param name="ux">The ux.</param>
        /// <param name="uxsize">The uxsize.</param>
        /// <param name="uy">The uy.</param>
        /// <param name="uysize">The uysize.</param>
        /// <param name="mehet">The ball can move.</param>
        /// <param name="hiba">The life point.</param>
        /// <param name="brick">The bricks.</param>
        /// <returns>The .</returns>
        public bool pattog(int maxx, int maxy, int ux, int uxsize, int uy, int uysize, bool mehet, int hiba, List<tegla> brick)
        {
            if (mehet)
            {
                // The ball is moving.
                bool rb = false;
                bool rt = false;
                bool lb = false;
                bool lt = false;
                bool patt = false;

                if (cy + 2 * r >= maxy)
                {
                    // The ball hit the bottom.
                    patt = true;
                    return true;
                }
                else
                {
                    // The ball didn't hit the bottom.
                    if (!patt)
                    {
                        // Going right.
                        switch (hiba % 2)
                        {
                            case 0:
                                cx = cx - dx;
                                break;
                            default:
                                cx = cx + dx;
                                break;
                        }

                        // Going left.
                        switch (hiba % 2)
                        {
                            case 0:
                                cy = cy + dy;
                                break;
                            default:
                                cy = cy - dy;
                                break;
                        }
                    }

                    // Collision detection.
                    for (int i = 0; i < brick.Count; i++)
                    {
                        if (!(this.cx + 10 < brick[i].Posx || this.Cx - 10 > brick[i].Posx + brick[i].Dx || this.cy + 10 < brick[i].Posy || this.cy - 10 > brick[i].Posy + brick[i].Dy))
                        {
                            // Right bottom.
                            if (this.Cx + 10 > brick[i].Posx && this.Cy + 10 > brick[i].Posy)
                            {
                                rb = true;
                            }

                            // Right top.
                            else if (this.Cx + 10 > brick[i].Posx && this.Cy - 10 < brick[i].Posy + brick[i].Dy)
                            {
                                rt = true;
                            }

                            // Left bottom.
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx && this.Cy + 10 > brick[i].Posy)
                            {
                                lb = true;
                            }

                            // Left top.
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx && this.Cy - 10 < brick[i].Posy + brick[i].Dy)
                            {
                                lt = true;
                            }

                            // Right
                            else if (this.Cx + 10 > brick[i].Posx)
                            {
                                rb = true;
                                rt = true;
                            }

                            // Left
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx)
                            {
                                lb = true;
                                lt = true;
                            }

                            // Bottom.
                            else if (this.Cy + 10 > brick[i].Posy)
                            {
                                lb = true;
                                rb = true;
                            }

                            // Top.
                            else if (this.cy - 10 < brick[i].Posy + brick[i].Dy)
                            {
                                rt = true;
                                lt = true;
                            }

                            brick.RemoveAt(i);
                            pont += 100;
                        }
                    }

                    // Only horizontal collision.
                    if ((rt == true && lt == true && rb == false && rb == false) || (rt == false && lt == false && rb == true && rt == true))
                    {
                        this.dy = -dy;
                    }
                    // Only vertical collision.
                    else if ((rt == true && rb == true && lt == false && lb == false) || (rt == false && rb == false && lt == true && lb == true))
                    {
                        this.dx = -dx;
                    }
                    // Collision on more than one side.
                    else if (rt == true || rb == true || lt == true || lb == true)
                    {
                        this.dy = -dy;
                    }

                    // Check the 4 walls
                    /*
					if (this.cx < 10) // Left
                    {
                        this.cx = 10;
                        //Direction = Math.PI - Direction;
                        this.dx = -dx;
                    }
					
                    if (this.cx > 300 - 10) // Right
                    {
                        this.cx = 300 - 10;
                        //Direction = Math.PI - Direction;
                        this.dx = -dx;
                    }
					
                    if (this.cy < 10) // Top
                    {
                        this.cy = 10;
                        //Direction = 2 * Math.PI - Direction;
                        this.dy = -dy;
                    }
					
                    if (this.cy > 400 - 10) // Bottom => dead ball
                    {
                        return false;
                    }
					*/

                    // Check paddle collision
                    /*
					if (this.cy > 345 - 10 && this.cy < 355 - 10 && this.cx >= maxx && this.cx < maxx + maxy)
                    {
                        this.cy = 345 - 10;
                        // For flat shaped paddle use this formula
                        //Direction = 2 * Math.PI - Direction;
                        this.dy = -dy;
                    }
					*/

                    //return true;

                    // Check the 3 walls and the racket.
                    // Horizontal distance.
                    int adx = Math.Abs(dx);
                    // Vertical distance.
                    int ady = Math.Abs(dy);

                    if (cx - r - adx < 0 || cx + r + adx > maxx)
                    {
                        // The left and right walls.
                        dx = -dx;
                    }

                    if (((cy - r - ady) < 10) /* top wall */
                    || (((cy + r + ady) > (maxy - 15 + uysize)) /* bottom wall */
                    && ((cx + r + adx) > ux) /* racket */
                    && ((cx - r) < (ux + uxsize)))) /* racket */
                    {
                        // The top and bottom walls.
                        dy = -dy;
                    }

                    patt = true;

                    return false;
                }
            }
            else
            {
                // The ball isn't moving.
                cx = ux + (uxsize / 2);
                cy = uy - r;

                return false;
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// Base class for init_labda.
    /// </summary>
    class init_labda : Labda
    {
        #region Fields

        // The width field of the init_labda class.
        int w;

        // The height field of the init_labda class.
        int h;

        #endregion Fields

        #region Properties

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="init_labda"/> class.
        /// </summary>
        /// <param name="ujcx">The input value of the cx field.</param>
        /// <param name="ujcy">The input value of the cy field.</param>
        /// <param name="ujdx">The input value of the dx field.</param>
        /// <param name="ujdy">The input value of the dy field.</param>
        /// <param name="ujB">The input value of the B field.</param>
        /// <param name="ujP">The input value of the P field.</param>
        /// <param name="ujR">The input value of the r field.</param>
        /// <param name="ujw">The input value of the w field.</param>
        /// <param name="ujh">The input value of the h field.</param>
        public init_labda(int ujtx, int ujty, int ujw, int ujh, int ujdx, int ujdy, Brush ujB, Pen ujP)
            : base(ujtx + ujw / 2, ujty + ujh / 2, ujdx, ujdy, ujB, ujP, (int)Math.Sqrt(ujw * ujw + ujh * ujh) / 2)
        {
            w = ujw;
            h = ujh;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Paints the init_labda.
        /// </summary>
        /// <param name="g">The graphics input.</param>
        public override void Paint(Graphics g)
        {
            g.DrawEllipse(P, Cx - w / 2, Cy - h / 2, w, h);
            g.FillEllipse(B, Cx - w / 2, Cy - h / 2, w, h);
        }

        #endregion Methods
    }
}