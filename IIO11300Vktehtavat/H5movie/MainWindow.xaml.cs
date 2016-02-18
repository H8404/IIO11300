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

namespace H5movie
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnOpenMovies1_Click(object sender, RoutedEventArgs e)
        {
            movies1 win = new movies1();
            win.ShowDialog();
        }

        private void btnOpenMovies2_Click(object sender, RoutedEventArgs e)
        {
            Movies2 win2 = new Movies2();
            win2.ShowDialog();
        }
    }
}
