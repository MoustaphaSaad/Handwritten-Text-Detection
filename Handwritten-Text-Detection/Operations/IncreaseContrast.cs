using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAsset;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Handwritten_Text_Detection_Library.Operations
{
    public class IncreaseContrast: IOperation
    {
        private MatlabAsset m_assets;

        public IncreaseContrast()
        {
            m_assets = new MatlabAsset();
        }

        public Image Apply(Image img)
        {
            MWNumericArray ks = img.ToMatlabArray();
            MWArray result = m_assets.IncreaseContrast(ks);
            img.FromMatlabArray(result);
            return img;
        }
    }
}
