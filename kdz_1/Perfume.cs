using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kdz_1
{
    class Perfume
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _kind;

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        private string _year;

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _wayToPictue;

        public string WayToPicture
        {
            get { return _wayToPictue; }
            set { _wayToPictue = value; }
        }

        //private void ImageExampleForm_Paint(object sender, PaintEventArgs e)
        //{
        //    // Create image.
        //    Image newImage = Image.FromFile("SampImag.jpg");

        //    // Create Point for upper-left corner of image.
        //    Point ulCorner = new Point(100, 100);

        //    // Draw image to screen.
        //    e.Graphics.DrawImage(newImage, ulCorner);
        //}

    }
}
