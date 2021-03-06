﻿namespace ImagingSourceTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.icImagingControl1 = new TIS.Imaging.ICImagingControl();
            this.cmdStartLive = new System.Windows.Forms.Button();
            this.cmdStopLive = new System.Windows.Forms.Button();
            this.cmdSaveBitmap = new System.Windows.Forms.Button();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.GetHimage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // icImagingControl1
            // 
            this.icImagingControl1.BackColor = System.Drawing.Color.White;
            this.icImagingControl1.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icImagingControl1.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icImagingControl1.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icImagingControl1.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icImagingControl1.Location = new System.Drawing.Point(12, 12);
            this.icImagingControl1.Name = "icImagingControl1";
            this.icImagingControl1.Size = new System.Drawing.Size(330, 249);
            this.icImagingControl1.TabIndex = 0;
            this.icImagingControl1.DeviceLost += new System.EventHandler<TIS.Imaging.ICImagingControl.DeviceLostEventArgs>(this.icImagingControl1_DeviceLost);
            // 
            // cmdStartLive
            // 
            this.cmdStartLive.Location = new System.Drawing.Point(12, 267);
            this.cmdStartLive.Name = "cmdStartLive";
            this.cmdStartLive.Size = new System.Drawing.Size(99, 27);
            this.cmdStartLive.TabIndex = 1;
            this.cmdStartLive.Text = "Start Live";
            this.cmdStartLive.UseVisualStyleBackColor = true;
            this.cmdStartLive.Click += new System.EventHandler(this.cmdStartLive_Click);
            // 
            // cmdStopLive
            // 
            this.cmdStopLive.Location = new System.Drawing.Point(12, 302);
            this.cmdStopLive.Name = "cmdStopLive";
            this.cmdStopLive.Size = new System.Drawing.Size(99, 27);
            this.cmdStopLive.TabIndex = 2;
            this.cmdStopLive.Text = "Stop Live";
            this.cmdStopLive.UseVisualStyleBackColor = true;
            this.cmdStopLive.Click += new System.EventHandler(this.cmdStopLive_Click);
            // 
            // cmdSaveBitmap
            // 
            this.cmdSaveBitmap.Location = new System.Drawing.Point(12, 337);
            this.cmdSaveBitmap.Name = "cmdSaveBitmap";
            this.cmdSaveBitmap.Size = new System.Drawing.Size(99, 27);
            this.cmdSaveBitmap.TabIndex = 3;
            this.cmdSaveBitmap.Text = "Save Bitmap";
            this.cmdSaveBitmap.UseVisualStyleBackColor = true;
            this.cmdSaveBitmap.Click += new System.EventHandler(this.cmdSaveBitmap_Click);
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(362, 12);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(334, 249);
            this.hWindowControl1.TabIndex = 4;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(334, 249);
            // 
            // GetHimage
            // 
            this.GetHimage.Location = new System.Drawing.Point(362, 267);
            this.GetHimage.Name = "GetHimage";
            this.GetHimage.Size = new System.Drawing.Size(99, 27);
            this.GetHimage.TabIndex = 5;
            this.GetHimage.Text = "Get Image";
            this.GetHimage.UseVisualStyleBackColor = true;
            this.GetHimage.Click += new System.EventHandler(this.GetHimage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 456);
            this.Controls.Add(this.GetHimage);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.cmdSaveBitmap);
            this.Controls.Add(this.cmdStopLive);
            this.Controls.Add(this.cmdStartLive);
            this.Controls.Add(this.icImagingControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TIS.Imaging.ICImagingControl icImagingControl1;
        private System.Windows.Forms.Button cmdStartLive;
        private System.Windows.Forms.Button cmdStopLive;
        private System.Windows.Forms.Button cmdSaveBitmap;
        private HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button GetHimage;
    }
}

