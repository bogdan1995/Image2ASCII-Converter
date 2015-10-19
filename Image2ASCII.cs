using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image2ASCII
{
    class Image2ASCII
    {
        private string TextASCIIPicture = "";

        private const int maxBrightness = 255;

        private string ImagefileName;

        private Image image = null;

        public Image getImage
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        public Image2ASCII(string fileName)
        {
            getImage = Image.FromFile(fileName);
            ImagefileName = fileName;
        }
        public void createASCIIPicture () 
        {
            Image file = getImage;
            Bitmap newBitmap = new Bitmap(ImagefileName);
            int width = file.Width;
            int height = file.Height;

            string dictionary = " .-wGHM#&%";


            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    Color color = newBitmap.GetPixel(x, y);

                    double brightness = getBrightness(color);

                    double idx = brightness / maxBrightness * (dictionary.Length - 1);

                    double pxl = dictionary[dictionary.Length - (int)Math.Round(idx) - 1];

                    TextASCIIPicture += pxl.ToString();
                }
                TextASCIIPicture += '\n';
            }

        }

        public string getTextASCIIPicture ()
        {
            return TextASCIIPicture;
            
        }

        private double getBrightness (Color color)
        {
            return Math.Sqrt(
                color.R * color.R * .241 +
                color.G * color.G * .691 +
                color.B * color.B * .068
            );
        }
    }
}
