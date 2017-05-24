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
    /// Логика взаимодействия для PagePurfume.xaml
    /// </summary>
    public partial class PagePurfume : Page
    {
        public ListOfPerfumes lp = new ListOfPerfumes();
        public PagePurfume()
        {
            InitializeComponent();
            if (File.Exists(".../.../perfume.xml"))
            {
                lp = Serialization.Deserialize(lp);
                foreach (var item in lp.Perfumes)
                {
                    listBoxPerfume.Items.Add(item);
                }
            }
            

        }
    }
}
