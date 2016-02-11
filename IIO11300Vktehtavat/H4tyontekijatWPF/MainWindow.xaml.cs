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
using System.Xml;
using System.Xml.Linq;

namespace H4tyontekijatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filu = "D:\\H8404\\Työntekijät2016.xml"; //kovakoodattu
        XElement xe;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReadXML_Click(object sender, RoutedEventArgs e)
        {
            //luetaan XML-teidostosta tyontekija-elementit ja sidotaan ne DataGridiin
            try
            {
                
                xe = XElement.Load(filu);
                dgData.DataContext = xe.Elements("tyontekija");
                tbMessage.Text = string.Format("Työntekijöitä {0}, joista vakituisia {1}. Tyontekijoitten palkat yhteensä {2}.\nVakituisten palkkojen summa {3}",CountWorkers(), CountWorkers("vakituinen"), CalculateSalarySum(), CalculateSalarySum("vakituinen"));
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
            }
        }

        private int CountWorkers()
        {
            int lkm = 0;
            try
            {
               
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(filu);
                //Haetaan kaikkien vakituisten työntekijöitten palkka-elementit XPathilla
                XmlNodeList xml = xmldoc.SelectNodes("/tyontekijat/tyontekija");
                //loopitetaan nodelista läpi
                lkm = xml.Count;
                return lkm;
            }
            catch (Exception ex)
            {
               tbMessage.Text = ex.Message;
               return lkm;
            }
        }

        private int CountWorkers(string tyosuhde)
        {
            int lkm = 0;
            //lasketaan LINQ-kyselyllä tietyn tyyppiset työntekijät
            var temp = from ele in xe.Elements()
                       where ele.Element("tyosuhde").Value == tyosuhde
                       select ele.Element("sukunimi");
            lkm = temp.Count();
            return lkm;
        }

        private decimal CalculateSalarySum()
        {
            decimal sum = 0;
            try
            {
                //luetaan XML-tiedosto XMLDocument olioon
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(filu);
                //Haetaan kaikkien vakituisten työntekijöitten palkka-elementit XPathilla
                XmlNodeList xml = xmldoc.SelectNodes("/tyontekijat/tyontekija[tyosuhde='vakituinen']/palkka");
                //loopitetaan nodelista läpi
                for (int i = 0; i < xml.Count; i++)
                {
                    sum += Convert.ToInt32(xml.Item(i).InnerText);
                }
                return sum;
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
                return sum;
            }
        }

        private decimal CalculateSalarySum(string tyosuhde)
        {
            decimal sum = 0;
            var palkat = from ele
                         in xe.Elements()
                         where ele.Element("tyosuhde").Value == tyosuhde
                         select ele.Element("palkka").Value;
            foreach (var item in palkat)
            {
                System.Diagnostics.Debug.Print(item.ToString());
                sum += decimal.Parse(item);
            }
            return sum;
        }
    }
}
