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
                lb = Serialization.Deserialize_b(lb);
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
            changeBrand change = new changeBrand(this);

            foreach (var item in lb.Brands)
            {
                try
                {


                    if (listBoxBrand.SelectedItem.ToString() == item.Name || ListBoxSearch.SelectedItem.ToString() == listBoxBrand.SelectedItem.ToString())
                    {
                        change.Show();
                        foreach (var brand in lb.Brands)
                        {
                            if (listBoxBrand.SelectedItem.ToString() == brand.Name)
                            {

                                change.TextBoxBrand.Text = brand.Name;
                                change.TextBoxDescription.Text = brand.Description;

                            }
                        }
                    }

                }
                catch (Exception a)
                {

                    MessageBox.Show("Выберите элемент из основного списка");
                }
            }
        }

        private void Openbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new PageBrand(this);
            this.Show();
        }

        private void listBoxBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbchanged = 1;
        }

        private void deleteBrandbtn_Click(object sender, RoutedEventArgs e)
        {
            PageBrand pb = new PageBrand(this);
            foreach (var item in lb.Brands)
            {
                try
                {



                    if (listBoxBrand.SelectedItem.ToString() == item.Name || ListBoxSearch.SelectedItem.ToString() == listBoxBrand.SelectedItem.ToString())
                    {
                        lb.Brands.Remove(item);
                        if (File.Exists(".../.../perfume.xml"))
                        {
                            foreach (var item_p in pb.lp.Perfumes)
                            {
                                if (item_p.Brand == listBoxBrand.SelectedItem.ToString())
                                {
                                    pb.lp.Perfumes.Remove(item_p);
                                    Serialization.Serialize_p(pb.lp);
                                    pb.listBoxPerfume.Items.Remove(item_p);
                                }
                            }
                        }



                        Serialization.Serialize_b(lb);
                        listBoxBrand.Items.Remove(listBoxBrand.SelectedItem);
                        break;
                    }
                }

                catch (Exception)
                {

                    MessageBox.Show("Выберите элемент из основного списка");
                }
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSearch.Items.Clear();
            lb = Serialization.Deserialize_b(lb);
            if (TextBoxSearch.Text != "")
            {
                foreach (var item in lb.Brands)
                {
                    if (item.Name.Contains(TextBoxSearch.Text))
                    {
                        ListBoxSearch.Items.Add(item.Name);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите поисковый запрос");
            }
            
        }
    }
}
