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
using System.IO;
using System.Globalization;

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
            var culture = CultureInfo.GetCultureInfo("cs-CZ");
            var dateTimeInfo = DateTimeFormatInfo.GetInstance(culture);

            var dateTime = DateTime.Today;

            int weekNumber = culture.Calendar.GetWeekOfYear(dateTime, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);

            txtFileName.Text = "C:\\Users\\Hanna\\Documents\\lotto" + weekNumber + ".txt";
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string filename = txtFileName.Text;
                if (!File.Exists(filename))
                {
                    
                    using (StreamWriter sw = File.CreateText(filename))
                    {
                        
                        sw.WriteLine(numbers.Text);
                        tbMessages.Text = "Rivi tallennettu tiedostoon";
                    }
                }
                else {
                    using (StreamWriter sw = File.AppendText(filename))
                    {
                      
                        sw.WriteLine(numbers.Text);
                        tbMessages.Text = "Rivi tallennettu tiedostoon";
                        

                    }
                   
                }

            }
            catch (Exception ex)
            {

                tbMessages.Text = ex.Message;
            }
        }

        private void txtCheck_Click(object sender, RoutedEventArgs e)
        {
            String correctline = txtLotto.Text;
            string filename = txtFileName.Text;
            string line = null;
            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    
                    line = sr.ReadLine();

                }

            }

        }
    }
}
