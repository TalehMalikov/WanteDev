using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoringImageInDB
{
    public class ImageClass
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageToByte { get; set; }
    }
}
