using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{
    public static class TestHockeyBench
    {
        public static List<HockeyPlayer> Get3Players()
        {
            List<HockeyPlayer> players = new List<HockeyPlayer>();
            players.Add(new HockeyPlayer("Teemu Selänne", "8"));
            players.Add(new HockeyPlayer("Jarkko immonen", "26"));
            players.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return players;
        }
    }
    public class HockeyPlayer: INotifyPropertyChanged
    {
        #region PROPERTIES
        private string name;
        public String Name
        {
            set
            {
                name = value;
                Notify("Name");
            }
            get
            {
                return name;
            }
        }
        private string number;
        public String Number
        {
            set
            {
                number = value;
                Notify("Number");
            }
            get
            {
                return number;
            }
           
        }
        public string NameAndNumber
        {
            set
            {
                Notify("NameAndNumber");
            }
            get
            {
                return name + "#" + number;
            }
        }


        #endregion
        #region CONSTRUCTORS
        public HockeyPlayer()
        {

        }

        public HockeyPlayer(string name, string number)
        {
            this.name = name;
            this.number = number;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion



    }
    public class HockeyTeam
    {
        #region PROPERTIES
        //HUOM! public fiels ei kelpaa XAMLin bindauksessa, pitää olla property
        public string Name { get; set; }
        public string City { get; set; }
        #endregion
        #region CONSTRUCTORS
        public HockeyTeam()
        {
            Name = "";
            City = "None";
        }
        public HockeyTeam(string teamName, string city)
        {
            Name = teamName;
            City = city;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return Name + "@" + City;
        }
        #endregion
    }
    public class HockeyLeague
    {
        List<HockeyTeam> teams = new List<HockeyTeam>();
        public HockeyLeague()
        {
            teams.Add(new HockeyTeam("Ilves", "Tampere"));
            teams.Add(new HockeyTeam("JYP", "Jyväskylä"));
            teams.Add(new HockeyTeam("Kärpät", "Oulu"));
            teams.Add(new HockeyTeam("HIFK", "Helsinki"));
            teams.Add(new HockeyTeam("Kalpa", "Kuopio"));
        }
        //Metodi joka palauttaa liigan joukkuuet
        public List<HockeyTeam> GetTeams()
        {
            return teams;
        }
    }
}
