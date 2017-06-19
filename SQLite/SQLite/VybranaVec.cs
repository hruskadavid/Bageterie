using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    public class VybranaVec
    {
        public Produkt Item { get; set; }
        public int Pocet { get; set; }
        public VybranaVec(Produkt item, int pocet)
        {
            Item = item;
            Pocet = pocet;
        }
    }
}
