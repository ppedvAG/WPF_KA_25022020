using System;
using System.Collections.Generic;
using System.Text;

namespace HalloBier.Model
{




    public class Bier
    {
        public string Marke { get; set; }
        public string Name { get; set; }
        public double Alk { get; set; }
        public decimal Preis { get; set; }
        public Sorten Sorte { get; set; }
        public bool Lecker { get; set; }
    }

    public enum Sorten
    {
        Pils,
        Export,
        Weizen,
        Alt,
        Keller,
        Bock,
        Ale,
        Lage,
        Stout,
        Helles,
        Porter
    }
}
