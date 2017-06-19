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
    public partial class Pridat : Page
    {
        ObjednavkaDatabase Database;
        MainWindow Main;
        public Pridat(ObjednavkaDatabase _database, MainWindow _main)
        {
            InitializeComponent();
            
            Database = _database;
            Main = _main;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Produkt item = new Produkt();
            item.Jmeno = Name.Text;
            item.Cena = Int32.Parse(Price.Text);
            Database.SaveItemAsync(item);
            result.Text = "Produkt vytvořen";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.New.NavigationService.Navigate(new NovaObjednavka(Database, Main));
        }

    }
}