using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace kdz_1
{
    [Serializable]
    public class ListOfPerfumes
    {
        
        public List<Perfume> Perfumes { get; set; }
        public ListOfPerfumes(List<Perfume> perfumes)
        {
            Perfumes = perfumes;
        }
        public ListOfPerfumes()
        {

        }
    }
}
