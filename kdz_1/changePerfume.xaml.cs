using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Xml.Serialization;
using System.Drawing;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Xml;

namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для changePerfume.xaml
    /// </summary>
    public partial class changePerfume : Window
    {
        PageBrand pb;
        public changePerfume(PageBrand changep)
        {
            pb = changep;
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveNewPerfume_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in pb.lp.Perfumes)
            {
                if (item.Name == pb.listBoxPerfume.SelectedItem.ToString())
                {
                    item.Name = TextBoxPerfume.Text;
                    item.Gender = ComboBoxGender.Text;
                    item.Description = TextBoxDescription.Text;
                    item.Brand = TextBoxBrand.Text;
                    item.Kind = TextBoxKind.Text;
                    item.Year = int.Parse(TextBoxYear.Text);
                    item.WayToPic = TextBoxImage.Text;

                }
                Serialization.Serialize_p(pb.lp);
                break;
            }
            if (File.Exists("../../perfume.xml"))
            {
                pb.listBoxPerfume.Items.Clear();
                pb.lp = Serialization.Deserialize_p(pb.lp);
                foreach (var item in pb.lp.Perfumes)
                {
                    pb.listBoxPerfume.Items.Add(item.Name.ToString());
                }                    
            }
            this.Close();
        }

        private void Addpic_Click(object sender, RoutedEventArgs e)
        {
            WindowPerfume wp = new WindowPerfume();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            openFileDialog.Filter = "jpeg|*.jpg";

            var fileN = openFileDialog.FileName;
            var newPath = System.IO.Path.GetFileName(fileN);
            var curPAth = System.Reflection.Assembly.GetExecutingAssembly().Location;
            newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(curPAth) + "\\img\\", newPath);

            if (!File.Exists(newPath))
                File.Copy(fileN, newPath, true);
            TextBoxImage.Text = newPath;
            BitmapImage sharerimg;
            sharerimg = new BitmapImage(new Uri(TextBoxImage.Text));
            wp.Image.Source = sharerimg;
        }
    }
}
