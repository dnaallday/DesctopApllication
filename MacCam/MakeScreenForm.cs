using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.Util;


namespace MacCam
{
    public partial class MakeScreenForm : Form
    {
        private Image<Bgr, byte> image = null;

        private string fileName = string.Empty;

        public MakeScreenForm(Image<Bgr, byte> image)
        {
            this.image = image;
            
            InitializeComponent();
        }

        private void MakeScreenForm_Load(object sender, EventArgs e)
        {
            fileName = $"Foto_{System.IO.Path.GetRandomFileName()}.jpg";

            pictureBox1.Image = image.Bitmap;                        
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.Save(fileName, ImageFormat.Jpeg);

                if (File.Exists(fileName))
                {
                    Close();
                }
                else 
                {
                    throw new Exception("Фото не сохранено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
