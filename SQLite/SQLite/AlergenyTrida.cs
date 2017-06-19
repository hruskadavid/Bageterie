using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    
    public class AlergenyTrida
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Jmeno { get; set; }
        public int ProduktID { get; set; }

        public AlergenyTrida()
        {

        }

    }
}

