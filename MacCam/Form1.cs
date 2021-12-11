using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.Util;

using DirectShowLib;

namespace MacCam
{
    public partial class Form1 : Form
    {
        private VideoCapture capture = null;

        private DsDevice[] webcams = null;

        private int selectedCameraId = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcams = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            
            capture = new VideoCapture(selectedCameraId);

            capture.ImageGrabbed += Capture_ImageGrabbed;

            capture.Start();

        }

        

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            Mat m = new Mat();

            capture.Retrieve(m);

            pictureBox1.Image = m.ToImage<Bgr, byte>().Flip(Emgu.CV.CvEnum.FlipType.Horizontal).Bitmap;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Mat m = new Mat();

            capture.Retrieve(m);

            MakeScreenForm makeScreen = new MakeScreenForm(m.ToImage<Bgr, byte>().Flip(Emgu.CV.CvEnum.FlipType.Horizontal));
            
            makeScreen.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }
    }
}
