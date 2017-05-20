using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewROI;
using HalconDotNet;
using System.Drawing.Imaging;

namespace ImagingSourceTest
{
    public partial class Form1 : Form
    {
        public HWndCtrl viewController;
        public ROIController roiController;
        public Form1()
        {
            InitializeComponent();
            roiController = new ROIController();
            viewController = new HWndCtrl(this.hWindowControl1);
            viewController.useROIController(roiController);
            viewController.setViewState(HWndCtrl.MODE_VIEW_MOVE);
        }
        /// <summary>
        /// Form1_Load
        ///
        /// If no device has been selected in the properties window of IC Imaging
        /// Control, the device settings dialog of IC Imaging Control is show at
        /// start of this sample. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!icImagingControl1.DeviceValid)
            {
                icImagingControl1.ShowDeviceSettingsDialog();

                if (!icImagingControl1.DeviceValid)
                {
                    MessageBox.Show("No device was selected.", "Grabbing an Image",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Let IC Imaging Control fill the complete form.
                    //icImagingControl1.Dock = DockStyle.Fill;
                    // Allow scaling.
                    icImagingControl1.LiveDisplayDefault = false;

                    icImagingControl1.LiveDisplayHeight = icImagingControl1.Height;
                    icImagingControl1.LiveDisplayWidth = icImagingControl1.Width;

                }
            }


        
            //cmdStartLive.Enabled = icImagingControl1.DeviceValid;
            //cmdStopLive.Enabled = icImagingControl1.DeviceValid;
            //cmdSaveBitmap.Enabled = icImagingControl1.DeviceValid;

        }
        /// <summary>
        /// cmdStartLive_Click
        ///
        /// Start the live video. A valid video capture device should have been
        /// selected previsously in the properties window of IC Imaging Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStartLive_Click(object sender, EventArgs e)
        {
            icImagingControl1.LiveStart();

        }
        /// <summary>
        /// cmdStopLive_Click
        ///
        /// Stop the live video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStopLive_Click(object sender, EventArgs e)
        {
            if (icImagingControl1.LiveVideoRunning == true)
                icImagingControl1.LiveStop();
        }

        /// <summary>
        /// cmdSaveBitmap_Click
        ///
        /// Snap an image from the live video stream and show the file save
        /// dialog. After a file name has been selected, the image is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveBitmap_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1;
            icImagingControl1.MemorySnapImage();
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                icImagingControl1.MemorySaveImage(saveFileDialog1.FileName);
            }
        }
        private delegate void DeviceLostDelegate();

        private void DeviceLost()
        {
            icImagingControl1.Device = "";
            MessageBox.Show("Device Lost!");
            //cmdLive.Text = "Start Live";
            //cmdLive.Enabled = false;
            //cmdProperties.Enabled = false;
        }
        private void icImagingControl1_DeviceLost(object sender, EventArgs e)
        {
            BeginInvoke(new DeviceLostDelegate(ref DeviceLost));
        }

        private void GetHimage_Click(object sender, EventArgs e)
        {
            HObject ho_Image = null, ho_Regions = null;
            
            HOperatorSet.GenEmptyObj(out ho_Regions);
            if (icImagingControl1.LiveVideoRunning == true)
                icImagingControl1.LiveStop();
            //Bitmap btm = new Bitmap(icImagingControl1.ImageActiveBuffer.Bitmap);
            Bitmap btm = (Bitmap)icImagingControl1.ImageActiveBuffer.Bitmap.Clone();
            //viewController.addIconicVar(ImageConventer.ConvertBitmapToHalconImage(btm));
            ho_Image = Bitmap2HImage_24(btm);            
            HOperatorSet.Threshold(ho_Image,out ho_Regions, 129,170);
            viewController.addIconicVar(ho_Image);
            viewController.addIconicVar(ho_Regions);
            viewController.repaint();
            btm.Dispose();
            GC.Collect();
            
        }
        HImage Bitmap2HImage_8(Bitmap bImage)
        {
            Bitmap bImage8;
            BitmapData bmData = null;
            Rectangle rect;
            IntPtr pBitmap;
            IntPtr pPixels;
            HImage hImage = new HImage();


            rect = new Rectangle(0, 0, bImage.Width, bImage.Height);
            bImage8 = new Bitmap(bImage.Width, bImage.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bImage8);
            g.DrawImage(bImage, rect);
            g.Dispose();


            bmData = bImage8.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            pBitmap = bmData.Scan0;
            pPixels = pBitmap;


            hImage.GenImage1("byte", bImage.Width, bImage.Height, pPixels);


            bImage8.UnlockBits(bmData);


            return hImage;
        }
        HImage Bitmap2HImage_24(Bitmap bImage)
        {
            Bitmap bImage24;
            BitmapData bmData = null;
            Rectangle rect;
            IntPtr pBitmap;
            IntPtr pPixels;
            HImage hImage = new HImage();


            rect = new Rectangle(0, 0, bImage.Width, bImage.Height);
            bImage24 = new Bitmap(bImage.Width, bImage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bImage24);
            g.DrawImage(bImage, rect);
            g.Dispose();


            bmData = bImage24.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            pBitmap = bmData.Scan0;
            pPixels = pBitmap;


            hImage.GenImageInterleaved(pPixels, "bgr", bImage.Width, bImage.Height, -1, "byte", 0, 0, 0, 0, -1, 0);


            bImage24.UnlockBits(bmData);


            return hImage;
        }
        //Bitmap bmp = new Bitmap("C:\\Projects\\1.bmp");
        //IntPtr pval = IntPtr.Zero;
        //BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
        //pval=  bd.Scan0;
        //HImage img = new HImage("byte", bmp.Width, bmp.Height, pval);

    }
}
