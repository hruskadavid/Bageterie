using SQLite.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interakční logika pro Page1.xaml
    /// </summary>
    public partial class Alergeny : Page
    {
        public Alergeny(MainWindow _main)
        {
            InitializeComponent();
            Products.ItemsSource = App.Database.GetItemsAsync().Result;
            
        }
    }
}
