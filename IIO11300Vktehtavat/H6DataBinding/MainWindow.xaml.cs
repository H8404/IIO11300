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

namespace H6DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smliiga;
        List<HockeyTeam> liigajoukkuuuet;
        int osoitin;
        public MainWindow()
        {
            InitializeComponent();
            AlustaKontrollit();
        }
        private void AlustaKontrollit()
        {
            //Täytetään comboboxi listan alkioilla
            List<string> joukkuueet = new List<string>();
            joukkuueet.Add("Ilves");
            joukkuueet.Add("Jyp");
            joukkuueet.Add("Kärpät");
            cbTeams.ItemsSource = joukkuueet;
            //perustaa SMLiiga
            smliiga = new HockeyLeague();
            liigajoukkuuuet = smliiga.GetTeams();
        }

        private void btnGetSetting_Click(object sender, RoutedEventArgs e)
        {
            //koodi lukee App.config asetuksen username
            btnGetSetting.Content = H6DataBinding.Properties.Settings.Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            //sidotaan kokoelma stackpanelin datacontektiksi
            spLiiga.DataContext = liigajoukkuuuet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (osoitin < 4)
            {
                //siiretään osoitinta kokoelmassa yhdellä eteenpäin
                osoitin++;
                spLiiga.DataContext = liigajoukkuuuet[osoitin];
            }
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            if (osoitin > 0)
            {
                osoitin--;
                spLiiga.DataContext = liigajoukkuuuet[osoitin];
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //lisätään kokoelmaan uusi joukkue
            HockeyTeam uusi = new HockeyTeam();
            liigajoukkuuuet.Add(uusi);
            osoitin = liigajoukkuuuet.Count - 1;
            spLiiga.DataContext = liigajoukkuuuet[osoitin];

        }
    }
}
