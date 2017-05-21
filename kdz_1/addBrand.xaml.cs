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

namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для addBrand.xaml
    /// </summary>
    public partial class addBrand : Window
    {
        
        public addBrand()
        {
            InitializeComponent();
            
        }


            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
            this.Close();
            }

        private void SaveNewBrand_Click(object sender, RoutedEventArgs e)
        {
            
            Brand brand = new Brand(TextBoxBrand.Text, TextBoxDescription.Text);
            List<Brand> lb = new List<Brand>();

            lb.Add(brand);
            //Serialization.Serialize();
            foreach (Brand b in lb)
            {
                
            }
        }
    }
    }
