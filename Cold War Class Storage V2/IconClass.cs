using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cold_War_Class_Storage_V2
{
    public class IconClass
    {
        public String Name;
        public Image Image;

        public IconClass(String name, Image image)
        {
            Name = name.ToUpper();
            Image = image;
        }
        public SelectControl getSelectControl()
        {
            return new SelectControl(this);
        }
        public TextImageControl GetTextImageControl()
        {
            return new TextImageControl(this);
        }
    }
}
