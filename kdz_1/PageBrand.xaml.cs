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
using System.Xml.Serialization;
using System.IO;


namespace kdz_1
{
    /// <summary>
    /// Логика взаимодействия для PageBrand.xaml
    /// </summary>
    public partial class PageBrand : Page
    {
        MainWindow wnd;
        public ListOfPerfumes lp = new ListOfPerfumes();
        public PageBrand(MainWindow pb)
        {
            wnd = pb;
            InitializeComponent();
            
                if (wnd.lbchanged == 1)
                {
                    foreach (var item in wnd.lb.Brands)
                    {
                        if (wnd.listBoxBrand.SelectedItem.ToString() == item.Name)
                        {
                            this.nameTextBlock.Text = item.Name.ToString();
                            this.descriptionTextBlock.Text = item.Description;
                            if (File.Exists(".../.../perfume.xml"))
                            {

                                lp = Serialization.Deserialize_p(lp);
                                foreach (var item_p in lp.Perfumes)
                                {
                                    if (item_p.Brand == item.Name)
                                    {
                                        Serialization.Serialize_p(lp);
                                        listBoxPerfume.Items.Add(item_p.Name);

                                    }

                                }
                            }
                        }
                    }
                }
                else
                {

                }                      
        }
            private void addperfumebtn_Click(object sender, RoutedEventArgs e)
            {
                addPerfume adp = new addPerfume(this);
                adp.Show();
            }

        private void editPerfume_Click(object sender, RoutedEventArgs e)
        {
            changePerfume changep = new changePerfume(this);
            

            foreach (var item in lp.Perfumes)
            {
                if (listBoxPerfume.SelectedItem.ToString() == item.Name)
                {
                    changep.Show();
                    changep.TextBoxPerfume.Text = item.Name;
                    changep.ComboBoxGender.Text = item.Gender;
                    changep.TextBoxDescription.Text = item.Description;
                    changep.TextBoxBrand.Text = item.Brand;
                    changep.TextBoxKind.Text = item.Kind;
                    changep.TextBoxYear.Text = item.Year.ToString();
                    changep.TextBoxImage.Text = item.WayToPicture;

                }
            }

            

        }

        private void deletePerfume_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lp.Perfumes)
            {
                if (listBoxPerfume.SelectedItem.ToString() == item.Name)
                {
                    lp.Perfumes.Remove(item);
                    Serialization.Serialize_p(lp);
                    listBoxPerfume.Items.Remove(listBoxPerfume.SelectedItem);
                    break;
                }
            }



            
        }

        private void OpenPerfume_Click(object sender, RoutedEventArgs e)
        {
            WindowPerfume wp = new WindowPerfume();
            wp.Show();

            foreach (var item in lp.Perfumes)
            {
                if (listBoxPerfume.SelectedItem.ToString() == item.Name)
                {                    
                    wp.TextBlockName.Text = item.Name;
                    wp.TextBlockGender.Text = item.Gender;
                    wp.TextBlockDescription.Text = item.Description;
                    wp.TextBlockBrand.Text = item.Brand;
                    wp.TextblockKind.Text = item.Kind;
                    wp.TextBlockYear.Text = item.Year.ToString();                   

                }
            }
        }
    }
    }

