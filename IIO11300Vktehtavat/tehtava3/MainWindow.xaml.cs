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
            
        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player.SavePlayers(players);
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void listPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player curPlayer = listPlayer.SelectedItem as Player;
             curPlayer = new Player();
            txtFirstname.Text = curPlayer.Firstname;
            txtLastname.Text = curPlayer.Lastname;
            txtCost.Text = curPlayer.Price.ToString();
            listPlayer.SelectedValue = curPlayer.Team;
        }
    }
}
