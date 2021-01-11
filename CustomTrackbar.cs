using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADE_Editer
{
    public partial class CustomTrackbar : System.Windows.Forms.TrackBar
    {
        public CustomTrackbar()
        {
            InitializeComponent();
        }

        Font fnt = new Font("MS UI Gothic", 10);

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.DrawString(this.Value.ToString() , fnt , Brushes.Black,-20,0);
        }
    }
}
