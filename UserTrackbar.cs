using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADE_Editer
{
    public partial class UserTrackbar : UserControl
    {
        [Browsable(true)]
        public int Minimum
        {
            get { return trackBar.Minimum; }
            set { trackBar.Minimum = value; }
        }

        [Browsable(true)]
        public int Maximum
        {
            get { return trackBar.Maximum; }
            set { trackBar.Maximum = value; }
        }

        
        public int Value
        {
            get
            {
                return trackBar.Value;            
            }
            set
            {
                if( value < Minimum)
                {
                    value = Minimum;
                }                
                else if( value > Maximum)
                {
                    value = Maximum;
                }

                trackBar.Value = value;
                textBox.Text = value.ToString();
            }
        
        }



        public UserTrackbar()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //こちらは確実に呼び出す
            int n = 0;

            try
            {
                n = int.Parse(textBox.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if (n < trackBar.Minimum) { return; }
            if (n > trackBar.Maximum) { return; }

            trackBar.Value = n;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            textBox.Text = trackBar.Value.ToString();
        }
    }
}
