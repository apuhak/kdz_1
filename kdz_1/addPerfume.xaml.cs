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
    /// Логика взаимодействия для addPerfume.xaml
    /// </summary>
    public partial class addPerfume : Window
    {
        MainWindow wnd;
        PageBrand pb;
        public addPerfume(PageBrand adp)
        {
            pb = adp;
            
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewPerfume_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("../../perfume.xml"))
            {
                pb.lp = Serialization.Deserialize_p(pb.lp);
            }
            else
            {

                pb.lp.Perfumes = new List<Perfume>();
            }

            Perfume perfume = new Perfume(TextBoxPerfume.Text, ComboBoxGender.Text, TextBoxDescription.Text, TextBoxKind.Text, int.Parse(TextBoxYear.Text), TextBoxImage.Text, TextBoxBrand.Text);
            if (TextBoxBrand.Text == pb.nameTextBlock.Text)
            {
                pb.lp.Perfumes.Add(perfume);           

                Serialization.Serialize_p(pb.lp);
                pb.listBoxPerfume.Items.Add(perfume.Name);
                this.Close();
            }
            else
            {
                MessageBox.Show("Такого Бренда не существует!");
            }
            


            
        }
    }
}
