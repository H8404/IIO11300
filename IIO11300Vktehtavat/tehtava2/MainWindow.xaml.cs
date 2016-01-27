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

namespace tehtava2
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            int boxIndex = comboBox.SelectedIndex;
            int r = Int32.Parse(rows.Text);

            if (boxIndex == 0)
            {
                numbers.Text = BLWindow.DrawRandom();
            }
            if (boxIndex == 1)
            {

                numbers.Text = BLWindow.DrawViking();
            }
            if (boxIndex == 2)
            {
                numbers.Text = BLWindow.DrawEuro();
            }
            
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            rows.Text = "1";
            numbers.Clear();
            comboBox.SelectedIndex = -1;
        }
    }
}
