using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{

public class ObjednanyProdukt
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public int ObjednavkaID { get; set; }
    public int ProduktID { get; set; }
    public int Pocet { get; set; }

    public ObjednanyProdukt()
    {

    }

}
}
