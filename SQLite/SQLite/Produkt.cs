using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{

    public class Produkt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public int Cena { get; set; }

        public Produkt()
        {

        }

    }
}