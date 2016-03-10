using System;
using System.Data.SqlClient;

namespace H7ADONETConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //1 LUODAAN YHTEYS
                string connStr = H7ADONETConsole.Properties.Settings.Default.Tietokanta;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //2 LUODAAN KOMENTO JA SUORITETAAN SE
                    SqlCommand cmd = new SqlCommand("SELECT asioid, lastname, firstname, date FROM presences WHERE asioid = 'H8404'", conn);
                    //3 KÄYDÄÄÄN TULOS=READER-OLIO LÄPI
                    SqlDataReader rdr = cmd.ExecuteReader();
                    Console.WriteLine("Yhteys tietokantaan avattu");
                    //KÄYDÄÄN rdr LÄPI
                    if (rdr.HasRows)
                    {
                        int lkm = 0;
                        while (rdr.Read())
                        {
                            //TULOS NÄKYVIIN
                            Console.WriteLine("Läsnäolosi {0} {1} {2} {3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                            lkm++;
                        }
                        Console.WriteLine("Tulostettu {0} läsnäoloa", lkm);
                    }
                    //MUISTA MYÖS SULKEA YHTEYS
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokanta yhteys suljettu onnistuneesti");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                Console.ReadKey();
            }
        }
    }
}
