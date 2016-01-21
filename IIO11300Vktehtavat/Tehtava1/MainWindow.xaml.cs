/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Tero ,Esa Salmikangas
*/
using System;
using System.Collections.Generic;
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

namespace JAMK.IT.IIO11300
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                int width = Int32.Parse(txtWidht.Text);
                int height = Int32.Parse(txtHeight.Text);
                int wood = Int32.Parse(txtWidhtWood.Text);

                //Ikkunan pinta-ala
                int windowArea = (width - 2 * wood) * (height - 2 * wood);
                txtWindow.Text = windowArea.ToString() + " mm^2";

                //Karmin pinta-ala
                int woodArea = width * height - windowArea;
                txtWood.Text = woodArea.ToString() + " mm^2";

                //Karmin piiri
                int woodP = width + width + height + height;
                txtWoodP.Text = woodP.ToString() + " mm";
                
               // EI NÄIN: BusinessLogicWindow.CalculatePerimeter(1, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }


    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
            //Käynissä olevan sovelluksen sulkeminen
      Application.Current.Shutdown();
    }

    private void btnCalculateOO_Click(object sender, RoutedEventArgs e)
        {
            //OLION avulla lasketaan pinta-ala ja piiri
            //luodaan olio
            Ikkuna ikk = new Ikkuna();
            ikk.Leveys = Double.Parse(txtWidht.Text);
            ikk.Korkeus = Double.Parse(txtHeight.Text);
            //VE1 Pinta-alan laskeminen kutsumalla metodia
            txtWindow.Text = ikk.LaskePintaAla().ToString();
            //VE2 pinta-ala on olion ominaisuus
            txtWindow.Text = ikk.PintaAla.ToString();
        }
  }


}
