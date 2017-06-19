using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using SQLite.Entity;

namespace SQLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           

            Listing.NavigationService.Navigate(new List(Database));

            New.NavigationService.Navigate(new NovaObjednavka(Database, this));

        }

        private static ObjednavkaDatabase _database;
        public static ObjednavkaDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new ObjednavkaDatabase(fileHelper.GetLocalFilePath("ObjednavkaSQLite.db3"));
                }
                return _database;
            }

        }
    }
}
