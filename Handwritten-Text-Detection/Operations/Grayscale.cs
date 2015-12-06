using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection_Library
{
    public class Grayscale: IOperation
    {
        public Grayscale()
        {
            
        }

        public Image Apply(Image input)
        {
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Pixel p = input[i, j];
                    int value = (p.R + p.G + p.B)/3;

                    input[i, j] = new Pixel(value,value,value);
                }
            }

            return input;
        }
    }
}
