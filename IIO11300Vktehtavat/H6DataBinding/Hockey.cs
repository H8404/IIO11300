﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H6DataBinding
{
    public class HockeyPlayer
    {

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
        public override string ToString()
        {
            return Name + "@" + City;
        }
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
