using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace fallabda
{
    class tegla
    {
        int posx; //viszszintes koordináta
        int posy; //függőleges koordináta
        Brush B; //kitöltés
        Pen P; //rajzolás
        int dx; //szélesség
        int dy; //magasság
        public int Posx
        {
            get { return posx; }
            set { posx = value; }
        }
        public int Posy
        {
            get { return posy; }
            set { posy = value; }
        }
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }
        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }
//a tégla konstruktora
        public tegla(int ujx, int ujy, int ujdx, int ujdy, Brush ujB, Pen ujP)
        {
            posx = ujx; posy = ujy; dx = ujdx; dy = ujdy; B = ujB; P = ujP;
        }
//kirajzolás
        public void Paint(Graphics g)
        {
            g.FillRectangle(B, posx, posy, dx, dy);
            g.DrawRectangle(P, posx, posy, dx, dy);
        }
    }
}
