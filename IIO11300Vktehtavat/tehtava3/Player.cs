using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtava3
{
    class Player
    {
        #region PROPERTIES
        private string firstname;
        private string lastname;
        private string fullname;
        private string name;
        private string team;
        private int price;

        public string Firstname
        {
            set { firstname = value; }
            get { return firstname; }
        }

        public string Lastname
        {
            set { lastname = value; }
            get { return lastname; }
        }

        public string Fullname
        {
            get { return fullname = this.firstname + " " + this.lastname; }
        }

        public string Name
        {
            get { return fullname = this.firstname + " " + this.lastname + ", " + this.team; }
        }

        public string Team
        {
            set { team = value; }
            get { return team; }
        }

        public int Price
        {
            set { price = value; }
            get { return price; }
        }
        #endregion
        #region CONSTRUCTORS
        public Player()
        {
            firstname = "";
            lastname = "";
            fullname = firstname + " " + lastname;
            name = firstname + " " + lastname + "," + team;
            team = "";
            price = 0;
        }
        #endregion
        #region METHODS
        public static void SavePlayers(List<Player> pelaajat)
        {
            try
            {
                string filename = "C:\\Users\\Hanna\\Documents\\koodiA\\pelaajat.txt";
                StreamWriter sw = File.AppendText(filename);

                foreach (var item in pelaajat)
                {
                    sw.WriteLine(item.Name);
                    sw.WriteLine(item.Price);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
