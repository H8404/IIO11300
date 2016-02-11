using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H4Tyontekijat_Console
{
    class Program
    {
        static void CalculateSalarySumFromXML(string filu)
        {
            try
            {
                //Tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    //luetaan XML-tiedosto XMLDocument olioon
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(filu);
                    //Haetaan kaikkien vakituisten työntekijöitten palkka-elementit XPathilla
                    XmlNodeList xml = xmldoc.SelectNodes("/tyontekijat/tyontekija[tyosuhde='vakituinen']/palkka");
                    int sum = 0;
                    //loopitetaan nodelista läpi
                    for (int i = 0; i < xml.Count; i++)
                    {
                        sum += Convert.ToInt32(xml.Item(i).InnerText);
                    }
                    Console.WriteLine(string.Format("Vakituisisa on {0} ja heidän palkat yhteensä {1} yhteensä ", xml.Count,sum));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        static void ReadWorkersFromXML(string filu)
        {
            try
            {
                //Tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    //luetaan XML-tiedosto XMLDocument olioon
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(filu);
                    //Haetaan kaikki työntekijä elementit XPathilla
                    XmlNodeList xml = xmldoc.SelectNodes("/tyontekijat/tyontekija");
                    XmlNode xn; //Edustaa yksittäistä noodia
                    XmlNodeList xml2;
                    //loopitetaan nodelista läpi
                    for (int i = 0; i < xml.Count; i++)
                    {
                        //näytetään käyttäjälle noodien sisältö
                        xn = xml.Item(i);
                        Console.WriteLine(xml.Item(i).InnerText);
                        xml2 = xn.ChildNodes;
                        for (int j = 0; j < xml2.Count; j++)
                        {
                            Console.WriteLine(xml2.Item(j).InnerText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //MAIN
        static void Main(string[] args)
        {
            try
            {
                ReadWorkersFromXML("D:\\H8404\\Työntekijät2016.xml");
                CalculateSalarySumFromXML("D:\\H8404\\Työntekijät2016.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
