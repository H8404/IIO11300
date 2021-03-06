﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace Tehtava6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string country="";
        XmlDataProvider provider = new XmlDataProvider();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnWine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               country = cbWine.SelectedValue.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            XDocument X = XDocument.Load("D:\\Viinit1.xml");
            var filter = X.Element("viinikellari").Elements("wine").Where(E => E.Element("maa").Value == country);;
            var result = filter.ToList();
            dgWine.ItemsSource = result;

            
        }


        private void btnAllWine_Click(object sender, RoutedEventArgs e)
        {
            LoadXMLData();
            Binding binding = new Binding();
            binding.Source = provider;
            binding.XPath = "/viinikellari/wine";
            dgWine.SetBinding(DataGrid.ItemsSourceProperty, binding);

        }

        private void LoadXMLData()
        {
            string filePath = "D:\\Viinit1.xml";

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(filePath);
            provider.Document = doc;
            provider.XPath = "/viinikellari/wine";
        }

    }
}
