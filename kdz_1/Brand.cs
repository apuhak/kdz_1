using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kdz_1
{
    class Brand
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
            Name = name;
            Description = description;
        }
    }
}
