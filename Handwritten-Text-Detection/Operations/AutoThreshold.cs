using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection
{
    public class AutoThreshold : IOperation
    {
        public int Init_T { get; set; }
        public int Delta_T { get; set; }

        public AutoThreshold(int init_T, int delta_T)
        {
            Init_T = init_T;
            Delta_T = delta_T;
        }

        private void CalcG1G2(Image input,int T, out int M1, out int M2)
        {
            int G1 = 0;
            int G2 = 0;
            int S1 = 0, S2 = 0;
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Pixel p = input[i, j];
                    if (p.R > T)
                    {
                        G1++;
                        S1 += p.R;
                    }
                    else
                    {
                        G2++;
                        S2 += p.R;
                    }
                }
            }

            if (G1 > 0)
                M1 = S1 / G1;
            else
                M1 = 0;

            if (G2 > 0)
                M2 = S2 / G2;
            else
                M2 = 0;
        }

        public Image Apply(Image input)
        {

            int T = Init_T;

            while (true)
            {
                int M1 = 0, M2 = 0;
                CalcG1G2(input, T, out M1, out M2);

                int nT = (M1 + M2)/2;

                if (nT == 0)
                    break;

                if (Math.Abs(nT - T) < Delta_T)
                {
                    T = nT;
                    break;
                }
                else
                {
                    T = nT;
                }
            }

            IOperation operation = new Threshold(T);
            return operation.Apply(input);
        }
    }
}
