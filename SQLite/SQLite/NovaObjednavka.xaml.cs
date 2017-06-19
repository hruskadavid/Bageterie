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
    /// Interakční logika pro NovaObjednavka.xaml
    /// </summary>
    public partial class NovaObjednavka : Page
    {
        
        MainWindow Main;
        Produkt SelectedProduct;
        Objednavka Neworder;
        List<VybranaVec> SelectedProducts = new List<VybranaVec>();
        public NovaObjednavka( MainWindow _main)
        {
            InitializeComponent();

            
            Main = _main;
            Neworder = new Objednavka();

            Products.ItemsSource = App.Database.GetItemsAsync().Result;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.New.NavigationService.Navigate(new Pridat(Main));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Created.Visibility = Visibility.Visible;
            foreach (VybranaVec value in SelectedProducts)
            {
                ObjednanyProdukt item = new ObjednanyProdukt();
                item.ProduktID = value.Item.ID;
                item.ObjednavkaID = Neworder.ID;
                item.Pocet = value.Pocet;
                App.Database.SaveObjednanyProduktAsync(item);
            }
            App.Database.SaveObjednavkaAsync(Neworder);
        }
        private void Pridat(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null)
            {
                Button but = sender as Button;
                string result = but.Content.ToString();
                int opt = 0;
                int index = 0;
                Produkt product = new Produkt();
                if (result == "+1")
                {
                    opt = 1;
                }
               else if (result == "-1")
                {
                    opt = -1;
                }
               
                foreach (VybranaVec value in SelectedProducts)
                {
                    if (value.Item == SelectedProduct)
                    {
                        product = SelectedProduct;
                        break;
                    }
                    index++;
                }
                if (product.Jmeno == null)
                {
                    SelectedProducts.Add(ConvertItem(SelectedProduct, opt));
                }
                else
                {
                    if (opt < 0)
                    {
                        if (SelectedProducts[index].Pocet <= -opt)
                        {
                            SelectedProducts.RemoveAt(index);
                        }
                        else
                        {
                            SelectedProducts[index].Pocet += opt;
                        }
                    }
                    else
                    {
                        SelectedProducts[index].Pocet += opt;
                    }
                }
                PersonsList.ItemsSource = null;
                PersonsList.ItemsSource = SelectedProducts;
            }

        }

        private void Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            SelectedProduct = (Produkt)lv.SelectedItems[0];

        }

        private void PersonsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListView lv = sender as ListView;
                VybranaVec product = (VybranaVec)lv.SelectedItems[0];
                SelectedProduct = product.Item;
            }
            catch
            {

            }
            
        }

        public VybranaVec ConvertItem(Produkt item, int pocet)
        {
            return new VybranaVec(item, pocet);
        }
    }
    
}
