using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;


namespace KIDS_CheckIn_System
{
    public partial class frmTakePicture : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        public frmTakePicture()
        {
            InitializeComponent();
        }

        private void frmTakePicture_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
            {
                cboDevices.Items.Add(device.Name);
            }

            cboDevices.SelectedIndex = 0;

            videoDevice = new VideoCaptureDevice(videoDevices[cboDevices.SelectedIndex].MonikerString);

            videoDevice.NewFrame += videoDevice_NewFrame;
            videoDevice.Start();
        }

        void videoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Image v = (Image)eventArgs.Frame.Clone();

            pbImage.Image = v;

        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (videoDevice.IsRunning) videoDevice.Stop();
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Tag = null;
                this.Dispose();
                this.Close();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnCapture_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (videoDevice.IsRunning) videoDevice.Stop();
                this.Tag = pbImage.Image;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
                this.Close();
            }
            catch(Exception ex)
            {

            }
        }

    }
}
