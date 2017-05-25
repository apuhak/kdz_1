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

        }
    }
    }

