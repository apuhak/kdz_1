using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace kdz_1
{
    [Serializable]
    public class ListOfBrands
    {

        public List<Brand> Brands;
        public ListOfBrands(List<Brand> brands)
        {
            Brands = brands;
        }
        public ListOfBrands()
        {

        }
    }
}
