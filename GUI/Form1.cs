using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handwritten_Text_Detection;
using Handwritten_Text_Detection.Operations;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Handwritten_Text_Detection.Image m_image;

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
                m_image = new Handwritten_Text_Detection.Image(openFileDialog.FileName);
            }
            pictureBox1.Image = m_image.ExportBitmap();
        }

        private void segmentTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOperation operation = new Grayscale();
            m_image = operation.Apply(m_image);

            operation = new LocalThreshold(10,10);
            m_image = operation.Apply(m_image);

            pictureBox1.Image = m_image.ExportBitmap();

            
        }
    }
}
