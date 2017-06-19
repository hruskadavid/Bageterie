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
    /// Interakční logika pro UpravitObjednavku.xaml
    /// </summary>
    public partial class UpravitObjednavku : Page
    {
        Objednavka obj;
        public UpravitObjednavku(MainWindow _main, Objednavka _obj)
        {
            InitializeComponent();
            obj = _obj;
            int kk = obj.ID;
            ObjednavkaList.ItemsSource = App.Database.GetItemDetailAsync(kk).Result;
        }
        private void smazat(object sender, RoutedEventArgs e)
        {

        
        Objednavka smazani = new Objednavka();
        smazani.ID = obj.ID;
        App.Database.DeleteItemAsync(smazani);
        }
    }
}
