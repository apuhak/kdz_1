﻿using System;
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
using System.Windows.Media.Animation;
using System.Xml.Serialization;
using System.IO;

namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int lbchanged = 0;
        public ListOfBrands lb = new ListOfBrands();       
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("../../brand.xml"))
            {
                lb = Serialization.Deserialize(lb);
                foreach (var item in lb.Brands)
                {
                    listBoxBrand.Items.Add(item.Name.ToString());
                }
            }
            

        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            addBrand ad = new addBrand(this);
            ad.Show();
        }

        private void editBrandbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new PageBrand();
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("PagePurfume.xaml", UriKind.Relative);
            //this.Close();
            //window.Show();

        }

        private void Openbtn_Click(object sender, RoutedEventArgs e)
        {
            PageBrand pb = new PageBrand();
            this.Content = new PageBrand();

            if (lbchanged == 1)
            {
                foreach (var item in lb.Brands)
                {
                    if (listBoxBrand.SelectedItem.ToString() == item.Name)
                    {
                        // pb.LabelName.Content = item.Name;                        
                        pb.nameTextBlock.Text = item.Name;
                        pb.descriptionTextBlock.Text = item.Description;
                        //item.Name == listBoxBrand.SelectedItem.ToString()
                    }
                }
            }
            else
            {

            }

        }

        private void listBoxBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbchanged = 1;
        }
    }
}
