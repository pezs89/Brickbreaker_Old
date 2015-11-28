using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace fallabda
{
//ős labda osztály
    abstract class Labda
    {
        int dx; //viszszintes irány
        int dy; //függőleges irány
        int cx; //viszszintes pozició
        int cy; //függőleges pozíció
        public Brush B; //kitöltés
        public Pen P; //megrajzolás
        int r; //sugár
        int pont = 0; //pontszámítás
        public int Pont
        {
            get { return pont; }
            set { pont = value; }
        }
        public int R
        {
            get { return r; }
            set { r = value; }
        }
        public int Cx
        {
            get { return cx; }
            set { cx = value; }
        }
        public int Cy
        {
            get { return cy; }
            set { cy = value; }
        }
        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }
        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }
        public int pontszamitas()
        {
            return pont;
        }
//pattogásért felelős
        public bool pattog(int maxx, int maxy, int ux, int uxsize, int uy, int uysize, bool mehet, int hiba, List<tegla> brick)
        {
            if (mehet)
            {
                bool rb = false;
                bool rt = false;
                bool lb = false;
                bool lt = false;
                bool patt = false;
                if (cy + 2 * r >= maxy)
                {
                    patt = true;
                    return true; //a labda elérte a pálya alját
                }
                else //a ladba nem érte el a pálya alját
                {
                    if (!patt)
                    {
                        switch (hiba % 2) //indul jobbra
                        {
                            case 0:
                                cx = cx - dx;
                                break;
                            default:
                                cx = cx + dx;
                                break;
                        }
                        switch (hiba % 2) //indul fel
                        {
                            case 0:
                                cy = cy + dy;
                                break;
                            default:
                                cy = cy - dy;
                                break;
                        }
                    }
//ütközés ellenörzése
                    for (int i = 0; i < brick.Count; i++)
                    {
                        if (!(this.cx + 10 < brick[i].Posx || this.Cx - 10 > brick[i].Posx + brick[i].Dx || this.cy + 10 < brick[i].Posy || this.cy - 10 > brick[i].Posy + brick[i].Dy))
                        {
                            if (this.Cx + 10 > brick[i].Posx && this.Cy + 10 > brick[i].Posy) //jobb lent
                            {
                                rb = true;
                            }
                            else if (this.Cx + 10 > brick[i].Posx && this.Cy - 10 < brick[i].Posy + brick[i].Dy) //jobb fönt
                            {
                                rt = true;
                            }
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx && this.Cy + 10 > brick[i].Posy) //bal lent
                            {
                                lb = true;
                            }
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx && this.Cy - 10 < brick[i].Posy + brick[i].Dy) //bal fent
                            {
                                lt = true;
                            }
                            else if (this.Cx + 10 > brick[i].Posx) //jobb
                            {
                                rb = true;
                                rt = true;
                            }
                            else if (this.Cx - 10 < brick[i].Posx + brick[i].Dx) //bal
                            {
                                lb = true;
                                lt = true;
                            }
                            else if (this.Cy + 10 > brick[i].Posy) //lent
                            {
                                lb = true;
                                rb = true;
                            }
                            else if (this.cy - 10 < brick[i].Posy + brick[i].Dy) //fent
                            {
                                rt = true;
                                lt = true;
                            }
                            brick.RemoveAt(i);
                            pont += 100;
                        }
                    }
//csak viszszintes ütközés
                    if ((rt == true && lt == true && rb == false && rb == false) || (rt == false && lt == false && rb == true && rt == true))
                    {
                        this.dy = -dy;
                    }
//csak függőleges ütközés
                    else if ((rt == true && rb == true && lt == false && lb == false) || (rt == false && rb == false && lt == true && lb == true))
                    {
                        this.dx = -dx;
                    }
//akár több oldalról történő ütközés
                    else if (rt == true || rb == true || lt == true || lb == true)
                    {
                        this.dy = -dy;
                    }
//a 3 fal és az ütő vizsgálata
                    int adx = Math.Abs(dx); //viszszintes távolság
                    int ady = Math.Abs(dy); //függőleges távolság
                    if (cx - r - adx < 0  || cx + r + adx > maxx ) dx = -dx; //két oldalsó fal
                    if (((cy - r - ady) < 10)/*felső fal*/ || (((cy + r + ady) > (maxy - 15 + uysize))/*alsó fal*/ && ((cx + r + adx) > ux)/*ütő*/ && ((cx - r) < (ux + uxsize))))/*ütő*/ dy = -dy; //alsó és felső fal
                    patt = true;
                    return false;
                }
            }
            else
            {
                cx = ux + (uxsize / 2);
                cy = uy - r;
                return false;
            }
        }
//labda konstruktora
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
        abstract public void Paint(Graphics g);
    }
//labda öröklő osztály
    class init_labda : Labda
    {
        int w; //szélesség
        int h; //magasság
//konstruktor
        public init_labda(int ujtx, int ujty, int ujw, int ujh, int ujdx, int ujdy, Brush ujB, Pen ujP): base(ujtx + ujw / 2, ujty + ujh / 2, ujdx, ujdy, ujB, ujP, (int)Math.Sqrt(ujw * ujw + ujh * ujh) / 2)
        {
            w = ujw; h = ujh;
        }
//kirajzolás
        public override void Paint(Graphics g)
        {
            g.DrawEllipse(P, Cx - w / 2, Cy - h / 2, w, h);
            g.FillEllipse(B, Cx - w / 2, Cy - h / 2, w, h);
        }
    }
}
