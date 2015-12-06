using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection_Library
{
    class Utils
    {
        public static double NormalRand(double mean, double sigma)
        {
            Random random = new Random();
            double v1, v2, s;
            do
            {
                v1 = 2.0*random.NextDouble() - 1.0;
                v2 = 2.0*random.NextDouble() - 1.0;
                s = v1*v1 + v2*v2;
            } while (s >= 1.0 || s == 0);

            s = System.Math.Sqrt((-2.0 * System.Math.Log(s)) / s);

            double gg = v1*s;

            double bm = mean + gg*sigma;

            return bm;
        }
    }
}
