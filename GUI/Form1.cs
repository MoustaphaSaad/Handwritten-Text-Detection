using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handwritten_Text_Detection_Library;
using Handwritten_Text_Detection_Library.Operations;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Handwritten_Text_Detection_Library.Image m_image;

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                m_image = new Handwritten_Text_Detection_Library.Image(openFileDialog.FileName);
                pictureBox1.Image = m_image.ExportBitmap();
            }
        }

        private void segmentTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOperation operation = new Grayscale();
            m_image = operation.Apply(m_image);

            operation = new IncreaseContrast();
            m_image = operation.Apply(m_image);

            operation = new LocalThreshold(10,10);
            m_image = operation.Apply(m_image);

            pictureBox1.Image = m_image.ExportBitmap();
        }

        private void connectedComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectedComponent operation = new ConnectedComponent();
            operation.Apply(m_image);
            var ne = operation.Elements;
            Array.Sort<CCElement>(ne, (x,y)=> x.Area.CompareTo(y.Area));
            double noise_limit = 25;
            int ix = (int) Math.Floor(ne.Length/2.0);
            double median = ne[ix].Area;
            while (median <= noise_limit)
            {
                var offset = ne.Length - ix;
                offset = (int) (Math.Floor(offset/2.0));
                median = ne[ix + offset].Area;
                ix += offset;
            }
            double limit = median * 0.85;
            List<CCElement> ll = new List<CCElement>();
            for (int i = 0; i < ne.Length; i++)
            {
                if (Math.Abs(ne[i].Area - median) <= limit && ne[i].Area > noise_limit)
                {
                    ll.Add(ne[i]);
                }
            }
            MessageBox.Show(ll.Count.ToString());
        }
    }
}
