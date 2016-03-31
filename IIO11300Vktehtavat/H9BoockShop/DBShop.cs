using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace H9BoockShop
{
    public class DBShop
    {
        public static DataTable GetTestData()
        {
            //luodaan testausta varten oikeanlainen datatable
            DataTable dt = new DataTable();
            //Sarakkeiden määrittely
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));
            //Rivit eli tietueet
            dt.Rows.Add(11, "Pekka", "out", "Fi", 1950);
            dt.Rows.Add(12, "jepjepjep", "Joku", "Belgia", 1946);
            return dt;
        }
        public static DataTable GetBooks(string connStr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT id, name, author, country, year FROM books";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Books");
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int UpdateBook(string connStr, int id, string name, string author, string country,int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //käytetään sql-kyselyn parametrejä
                    string sql = string.Format("UPDATE books SET name=@Nimi,author=@Kirjailija ,country='{3}',year={4} WHERE id={0}",id,name,author,country,year);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlParameter sp;
                    sp = new SqlParameter("Nimi", SqlDbType.NVarChar);
                    sp.Value = name;
                    cmd.Parameters.Add(sp);
                    sp = new SqlParameter("Kirjailija", SqlDbType.NVarChar);
                    sp.Value = author;
                    cmd.Parameters.Add(sp);
                    //kysely kantaan
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static int InsertBook(string connStr, string name, string author, string country, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //käytetään sql-kyselyn parametrejä
                    string sql = string.Format("INSERT INTO books (name, author, country, year) VALUES (@Nimi, @Kirjailija, @Maa, @Vuosi)");
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Nimi", name);
                    cmd.Parameters.AddWithValue("@Kirjailija", author);
                    cmd.Parameters.AddWithValue("@Maa", country);
                    cmd.Parameters.AddWithValue("@Vuosi", year);
                    //kysely kantaan
                    int lkm = cmd.ExecuteNonQuery();
                    conn.Close();
                    return lkm;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       /* public static int DeleteBook(string connStr,int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM books WHERE id={0}", id),conn);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/
    }
}
