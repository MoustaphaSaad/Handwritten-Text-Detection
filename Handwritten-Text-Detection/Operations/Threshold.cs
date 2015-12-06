using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection_Library
{
    public class Threshold: IOperation
    {
        public int Value { get; set; }

        public Threshold(int val)
        {
            Value = val;
        }

        public Image Apply(Image input)
        {
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Pixel p = input[i, j];

                    if (p.R > Value)
                        input[i, j] = Pixel.White;
                    else
                        input[i, j] = Pixel.Black;
                }
            }

            return input;
        }
    }
}
