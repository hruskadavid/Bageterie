using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.ObjectModel;

namespace SQLite.Entity
{
    public class Objednavka
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Datum { get; set; }


        public Objednavka()
        {
            Datum = DateTime.Now;
        }


    }
}
