using System;
using System.Collections.Generic;
using System.IO;
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

namespace tehtava3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> players;
        public MainWindow()
        {
            InitializeComponent();
            players = new List<Player>();
        }

        private void btnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            Player player = new Player();
            player.Firstname = txtFirstname.Text;
            player.Lastname = txtLastname.Text;
            player.Price = Int32.Parse(txtCost.Text);
            ComboBoxItem typeItem = (ComboBoxItem)comboTeam.SelectedItem;
            player.Team = typeItem.Content.ToString();
            listPlayer.Items.Add(player);
            players.Add(player);
            tbMessages.Text = "pelaaja luotu";
            
        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (listPlayer.SelectedItem != null)
            {
                Player curPlayer = (Player)listPlayer.SelectedItem;
                curPlayer.Firstname = txtFirstname.Text;
                curPlayer.Lastname = txtLastname.Text;
                curPlayer.Price = Int32.Parse(txtCost.Text);
                ComboBoxItem typeItem = (ComboBoxItem)comboTeam.SelectedItem;
                curPlayer.Team = typeItem.Content.ToString();
                listPlayer.SelectedItem = curPlayer;
                tbMessages.Text = "Pelaajan tiedot muutettu";

            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            
           listPlayer.Items.Remove(listPlayer.SelectedItem);
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtCost.Text = "";
            tbMessages.Text = "Pelaaja poisteetu";
        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e)
        {
            Player.SavePlayers(players);
            tbMessages.Text = "Pelaajat tallennettu tiedostoon";
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void listPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPlayer.SelectedItem != null)
            {
                Player curPlayer = (Player)listPlayer.SelectedItem;
                txtFirstname.Text = curPlayer.Firstname.ToString();
                txtLastname.Text = curPlayer.Lastname.ToString();
                txtCost.Text = curPlayer.Price.ToString();
                string curteam = curPlayer.Team.ToString();
                comboTeam.SelectedValue = curPlayer.Team;
            }
        }
    }
}
