﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    [Serializable()]
  public class MittausData
  {
        #region PROPERTIES
        private string kello;
    public string Kello
    {
      get { return kello; }
      set { kello = value; }
    }
    private string mittaus;

    public string Mittaus
    {
      get { return mittaus; }
      set { mittaus = value; }
    }
        #endregion
        #region CONSTRUCTORS

        //luokalle tehdään kaksi konstruktoria
        public MittausData()
    {
      kello = "0:00";
      mittaus = "empty";
    }
    public MittausData(string klo, string mdata)
    {
      this.kello = klo;
      this.mittaus = mdata;
    }
        #endregion
        # region METHODS

        //ylikirjoitetaan ToString
        public override string ToString()
    {
      //return base.ToString();
      return kello + "=" + mittaus;
    }
 
        //tiedoston käsittely
        public static void SaveToFile(string filename,List<MittausData> datat)
        {
            try
            {
                //tsekataan onko tiedosto jo olemassa
                StreamWriter sw;
                if (File.Exists(filename))
                {
                    //liitetään olemassaolevaan tiedostoon
                    sw = File.AppendText(filename);
                }
                else
                {
                    //luodaan uusi
                    sw = File.CreateText(filename);
                }
                foreach (var item in datat)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SaveToFileV2(string filename, List<MittausData> datat)
        {
            try
            {
                //tsekataan onko tiedosto jo olemassa
                

                    //liitetään olemassaolevaan tiedostoon
                    StreamWriter sw = File.AppendText(filename);

                foreach (var item in datat)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<MittausData> ReadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename)) {
                    //luetaan tekstitiedosto ja muutetaan se MittausData-olioiksi
                    MittausData md;
                    List<MittausData> luetut = new List<MittausData>();
                    string rivi = "";
                    StreamReader sr = File.OpenText(filename);
                    while ((rivi = sr.ReadLine()) != null)
                    {
                        if (rivi.Length > 3 && rivi.Contains("="))
                        {
                            string[] split = rivi.Split(new char[] { '=' });
                            //alimerkkijonoista luodaan olio
                            md = new MittausData(split[0], split[1]);
                            luetut.Add(md);
                        }
                    }
                    sr.Close();
                    return luetut;
                }
                else
                {
                    throw new FileNotFoundException();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
  }
}
