using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace kdz_1
{
    class Serialization
    {
        public static string file_perfume = ".../.../perfume.xml";
        public static string file_brand = ".../.../brand.xml";
        public static XmlSerializer xs_perfume = new XmlSerializer(typeof(ListOfPerfumes));
        public static XmlSerializer xs_brand = new XmlSerializer(typeof(ListOfBrands));

        public static void Serialize_b(ListOfBrands lb)
        {
            using (FileStream fs = new FileStream(file_brand, FileMode.Create))
            {
                xs_brand.Serialize(fs, lb);
            }
        }

        public static ListOfBrands Deserialize(ListOfBrands lb)
        {
            ListOfBrands data = new ListOfBrands();
            using (FileStream fs = new FileStream(file_brand, FileMode.Open))
            {
                data = (ListOfBrands)xs_brand.Deserialize(fs);
            }
            return data;
        }


        public static void Serialize_b(ListOfPerfumes lp)
        {
            using (FileStream fs = new FileStream(file_perfume, FileMode.Create))
            {
                xs_brand.Serialize(fs, lp);
            }
        }

        public static ListOfPerfumes Deserialize(ListOfPerfumes lp)
        {
            ListOfPerfumes data = new ListOfPerfumes();
            using (FileStream fs = new FileStream(file_brand, FileMode.Open))
            {
                data = (ListOfPerfumes)xs_perfume.Deserialize(fs);
            }
            return data;
        }




    }
}
