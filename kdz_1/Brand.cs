using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kdz_1
{
    [Serializable]
    public class Brand
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = Name; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = Description; }
        }

        public Brand(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public Brand()
        {

        }


    }
}
