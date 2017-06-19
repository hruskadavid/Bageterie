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
        
            MainWindow main;

        
        public List()
        {
            InitializeComponent();
            //Objednavka kokot = new Objednavka();
            //kokot.ID = 1;
            //App.Database.DeleteItemAsync(kokot);
            DataContext = this;


            List<Objednavka> orders = App.Database.GetItemsNotDoneAsync().Result;
            foreach (Objednavka value in orders)
            {
                value.Items = new List<VybranaVec>();
                foreach (ObjednanyProdukt item in App.Database.GetOrderItemsfromOrder(value.ID).Result)
                {
                    VybranaVec product = new VybranaVec(App.Database.GetItemAsync(item.ProduktID).Result, item.Pocet);
                    value.Items.Add(product);
                }
                Produkt testitem = new Produkt();
                VybranaVec testproduct = new VybranaVec(testitem, 10);
                value.Items.Add(testproduct);
            }


        }
        private void Objednavky_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListView lv = sender as ListView;
            Objednavka selectedItem = (Objednavka)lv.SelectedItems[0];

            NavigationService.Navigate(new UpravitObjednavku(main, selectedItem));
        }
    }
}
