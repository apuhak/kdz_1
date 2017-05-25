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
using System.Windows.Shapes;
using System.IO;

namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для changeBrand.xaml
    /// </summary>
    public partial class changeBrand : Window
    {
        MainWindow wnd;
        public changeBrand(MainWindow changewnd)
        {
            wnd = changewnd;

            InitializeComponent();
        }

        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewBrand_Click(object sender, RoutedEventArgs e)
        {
            PageBrand pb = new PageBrand(wnd);
            foreach (var item in wnd.lb.Brands)
            {

                if (wnd.listBoxBrand.SelectedItem.ToString() == item.Name)
                {
                    item.Name = TextBoxBrand.Text;
                    item.Description = TextBoxDescription.Text;

                    if (File.Exists(".../.../perfume.xml"))
                    {
                        pb.lp = Serialization.Deserialize_p(pb.lp);
                        foreach (var item_p in pb.lp.Perfumes)
                        {
                            if (item_p.Brand == wnd.listBoxBrand.SelectedItem.ToString())
                            {
                                item_p.Brand = TextBoxBrand.Text;
                            }
                            Serialization.Serialize_p(pb.lp);
                            
                        }
                    }
                    //foreach (var item_p in pb.lp.Perfumes)
                    //{
                    //    if (item_p.Brand == wnd.listBoxBrand.SelectedItem.ToString())
                    //    {
                    //        item_p.Brand = TextBoxBrand.Text;
                    //    }
                    //}
                    Serialization.Serialize_b(wnd.lb);                 
                    break;
                }
            }
            if (File.Exists("../../brand.xml"))
            {
                wnd.listBoxBrand.Items.Clear();
                wnd.lb = Serialization.Deserialize_b(wnd.lb);
                foreach (var item in wnd.lb.Brands)
                {
                    wnd.listBoxBrand.Items.Add(item.Name.ToString());
                }
            }           
            this.Close();
        }
    }
}
