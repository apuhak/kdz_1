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
using System.Xml.Serialization;
using System.IO;

namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для addBrand.xaml
    /// </summary>
    public partial class addBrand : Window
    {
        
        MainWindow wnd;
        public addBrand(MainWindow wnd1)
        {
            InitializeComponent();
            wnd = wnd1;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewBrand_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../brand.xml"))
            {
                wnd.lb = Serialization.Deserialize(wnd.lb);
            }
            else
            {
               
                wnd.lb.Brands = new List<Brand>();
            }

            Brand brand = new Brand(TextBoxBrand.Text, TextBoxDescription.Text);
           
            wnd.lb.Brands.Add(brand);

            Serialization.Serialize_b(wnd.lb);
            wnd.listBoxBrand.Items.Add(brand.Name);

            this.Close();
            
        }
    }
}
