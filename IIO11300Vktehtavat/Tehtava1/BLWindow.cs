using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class Ikkuna
    {
        #region Muuttujat
        private double korkeus;
        private double leveys;
        // private double pintaala;
        #endregion
        #region Ominaisuudet (properties)
        //oli suunnittelun aikana on päätetty että pinta-ala ja hinta ovat read-only ominaisuuksia
        public double PintaAla
        {
            get
            {
                return korkeus * leveys;
            }
        }
        public float Hinta
        {
            get
            {
                return LaskeHinta();
            }
        }
        public double Korkeus
        {
            get
            {
                return korkeus;
            }
            set
            {
                //tässä kohdassa voisi tarvittaessa tehdä tarkistuksia
                korkeus = value;
            }
        }
       
        public double Leveys
        {
            get { return leveys; }
            set { leveys = value; }
        }

        #endregion
        #region Konstruktorit

        #endregion
        #region Metodit
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
        private float LaskeHinta()
        {
            // hinta lasketaan työn ja materiaalimenekin ja katteen avulla
            float kate = 100;
            float tyo = 200;
            float materiaali;
            materiaali = 100 * (float)(leveys * korkeus / 1000000);
            return (kate + tyo + materiaali);
        }
        #endregion

    }
    public class IkkunaVE0
    {
        //joskus tehdään näin
       public double korkeus;
       public double leveys;
        public double LaskePintaALa()
        {
            return korkeus * leveys;
        }
    }
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double width, double height)
        {
            throw new System.NotImplementedException();
        }
    }
}
