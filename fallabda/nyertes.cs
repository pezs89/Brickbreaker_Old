using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fallabda
{
    class nyertes
    {
        int pontok; //pontszámok
        string nev; //nevek
        public int Pontok
        {
            get { return pontok; }
            set { pontok = value; }
        }
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }
//konstruktor
        public nyertes(string nev1, int pontok1)
        {
            nev = nev1;
            pontok = pontok1;
        }
//tostring felülírása
        public override string ToString()
        {
            return nev + " " + pontok.ToString();
        }
    }
}
