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
    /// Interakční logika pro NovaObjednavka.xaml
    /// </summary>
    public partial class NovaObjednavka : Page
    {
        ObjednavkaDatabase Database;
        MainWindow Main;
        public NovaObjednavka(ObjednavkaDatabase _database, MainWindow _main)
        {
            InitializeComponent();

            Database = _database;
            Main = _main;

            Products.ItemsSource = Database.GetItemsAsync().Result;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.New.NavigationService.Navigate(new Pridat(Database, Main));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
