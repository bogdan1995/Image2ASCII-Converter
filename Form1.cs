using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Image2ASCII
{
    public partial class Form1 : Form
    {
        Bitmap newBitmap;
        Image file;
        bool opened = false;
        int width, height;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int [,,] colorMatrix = getColorMatrix(width: width, height: height, image: newBitmap);
        }

        public void openFile()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                file = Image.FromFile(openFileDialog1.FileName);
                newBitmap = new Bitmap(openFileDialog1.FileName);
                opened = true;
                label3.Visible = true;
                pictureBox1.Image = file;
                width = file.Width;
                height = file.Height;
            }
        }
        public int[,,] getColorMatrix (int width, int height, Bitmap image)
        {
            int[,,] colorMatrix = new int[3, width, height];

            System.IO.StreamWriter textFile = new System.IO.StreamWriter(@"C:\Users\Bogdan\YandexDisk\Development\Listings\[ITVDN]\C#\test.txt");

            for (int y = 0; y < height; ++y)
            {
                for (int x= 0; x < width; ++x)
                {
                    Color color = image.GetPixel(x, y);
                    colorMatrix[0, y, x] = color.R;
                    colorMatrix[1, y, x] = color.G;
                    colorMatrix[2, y, x] = color.B;

                    textFile.Write(colorMatrix[0, y, x] + ' ');
                    textFile.Write(colorMatrix[1, y, x] + ' ');
                    textFile.WriteLine(colorMatrix[2, y, x]);

                }
            }


                return colorMatrix;
        }
    }
}
