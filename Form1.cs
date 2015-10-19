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
        Image2ASCII newImage2ASCII = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newImage2ASCII != null)
            {
                newImage2ASCII.createASCIIPicture();
            }
            
        }

        public void openFile()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                newImage2ASCII = new Image2ASCII(openFileDialog1.FileName);
                pictureBox1.Image = newImage2ASCII.getImage;
                label3.Visible = true;
            }
        }
        public void saveFile()
        {
            string longString = newImage2ASCII.getTextASCIIPicture();
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                StreamWriter textFile = new StreamWriter(@"" + savePath);
                textFile.Write(longString);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFile();
        }

    }
}
