using SQLite.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SQLite
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : Page
    {
        ObjednavkaDatabase database;
        public List(ObjednavkaDatabase _database)
        {
            InitializeComponent();
            database = _database;

            //OrderList.ItemsSource = database.GetItemsNotDoneAsync().Result;
        }
    }
}
