using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Handwritten_Text_Detection_Library.Operations
{
    public struct CCElement
    {
        public double Center_X;
        public double Center_Y;
        public double Area;
    }

    public class ConnectedComponent : IOperation
    {
        private MAsset.MAsset m_assets;

        public CCElement[] Elements;
        public ConnectedComponent()
        {
            m_assets = new MAsset.MAsset();
            Elements = null;
        }

        public Image Apply(Image img)
        {
            MWArray arr = m_assets.ConnectedComponent(img.ToSingleMatlabArray());
            var d = arr.ToArray();
            Elements = new CCElement[d.GetLength(0)];
            for (int i = 0; i < d.GetLength(0); i++)
            {
                var ooo = d.GetValue(i, 0);
                Elements[i].Center_X = (double) ooo;

                ooo = d.GetValue(i, 1);
                Elements[i].Center_Y = (double)ooo;

                ooo = d.GetValue(i, 2);
                Elements[i].Area = (double)ooo;
            }
            return img;
        }
    }
}
