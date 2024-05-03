using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MRZReader
{
    public partial class ZoomPreview : Form
    {
        public ZoomPreview()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public ZoomPreview(Image image)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            pbPreview.Image = image;
        }

        /// <summary>
        /// 1 = AutoSize, 2 = CenterImage, 3 = Normal, 4 = StretchImage, 5 = Zoom
        /// </summary>
        public void SetSizeMode(int type)
        {
            switch (type)
            {
                case 1: pbPreview.SizeMode = PictureBoxSizeMode.AutoSize;
                        break;
                case 2: pbPreview.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                case 3: pbPreview.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                case 4: pbPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                case 5: pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
            }
        }
    }
}
