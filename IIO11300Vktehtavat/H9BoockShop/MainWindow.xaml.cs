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

namespace H9BoockShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearchTest_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = BookShop.GetTestBooks();
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Asetaan stackPanelin dataconteksiksi valittu olio
            spBook.DataContext = dgBooks.SelectedItem;
        }

        private void btnSearchSQL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Haetaan kirjat BL-kerroksesta
                dgBooks.DataContext = BookShop.GetBooks(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Mistä tiedetään mitä muokata ---> book-olion ID:stä
            try
            {
                Book current = (Book)spBook.DataContext;
                if(BookShop.UpdateBook(current) > 0)
                {
                    MessageBox.Show(string.Format("kirja {0} päivitetty tietokantaan onnistuneesti", current.ToString()));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            if(btnNew.Content.ToString() == "Uusi")
            { 
                //luodaan uusi kirja olio
                Book newBook = new Book(0);
                newBook.Name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnNew.Content = "Tallenna uusi kantaan";
            }
            else
            {
                Book current = (Book)spBook.DataContext;
                BookShop.InsertBook(current);
                dgBooks.DataContext = BookShop.GetBooks(true);
                MessageBox.Show(string.Format("Kirja {0} tallennettu kantaan onnistuneesti", current.ToString()));
                btnNew.Content = "Uusi";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
