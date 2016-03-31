using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

namespace H10BookShopEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        ObservableCollection<Book> localBooks;
        ICollectionView view; //Filtteröinti
        bool IsBooks;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            ctx = new BookShopEntities();
            ctx.Books.Load();
            localBooks = ctx.Books.Local;
            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            cbCountries.Visibility = Visibility.Visible;
            //view kirjojen filtteröintiä varten
            view = CollectionViewSource.GetDefaultView(localBooks);

        }


        private void btnSearchAsiakkat_Click(object sender, RoutedEventArgs e)
        {
            var customers = ctx.Customers.ToList();
            dgBooks.DataContext = customers;
            IsBooks = false;
        }

        private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = localBooks;
            IsBooks = true;
            cbCountries.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Book newBook;
            if (btnNew.Content.ToString() == "Uusi")
            {
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnNew.Content = "Tallenna Kantaan";
            }
            else
            {
                //Lisätään uusi kirja kontekstiin ja sieltä kantaan
                newBook = (Book)spBook.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnNew.Content = "Uusi";
                MessageBox.Show("Kirja " + newBook.name + " lisätty kantaan");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Book current = (Book)spBook.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.DisplayName2, "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
            if(retval == MessageBoxResult.Yes)
            {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            }
        }

        private bool MyCountryFilter(object item)
        {
            if(cbCountries.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //Haetaan valitun asiakkaan tilaukset
            string msg = "";
            Customer current = (Customer)spCustomer.DataContext;
            msg += string.Format("Asiakkaalla {0} on {1} tilausta:\n", current.DisplayName, current.OrderCount);
            foreach(var item in current.Orders)
            {
                msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n", item.odate, item.Orderitems.Count);
                //kunkin tilauksen rivit ja sitä vastavaa kirja
                Decimal summa = 0;
                foreach (var oitem in item.Orderitems)
                {
                    msg += string.Format("- kirja {0} kappaletta {1}\n", oitem.Book.name, oitem.count);
                    summa += oitem.count * oitem.Book.price.Value;  
                }
                msg += string.Format("Tilaus thteensä: {0}\n", summa);
            }
            MessageBox.Show(msg);
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsBooks == false) { 
                //Valittu item(tässä tapauksessa Customer olio) asetetaan stackpanelin datacontect
                spCustomer.DataContext = dgBooks.SelectedItem;
            }
            else
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //suodatus tehdään ns predikaatti-funktiolla
            view.Filter = MyCountryFilter;
        }
    }
}
