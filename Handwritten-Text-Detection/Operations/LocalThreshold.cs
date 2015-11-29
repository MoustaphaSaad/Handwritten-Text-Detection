using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwritten_Text_Detection.Operations
{
    struct Rect
    {
        public int X, Y, Width, Height;

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
    public class LocalThreshold: IOperation
    {
        public int X_Slices { get; set; }
        public int Y_Slices { get; set; }

        public LocalThreshold(int x_Slices, int y_Slices)
        {
            X_Slices = x_Slices;
            Y_Slices = y_Slices;
        }

        public Image Apply(Image input)
        {
            int slice_width = input.Width/X_Slices;
            int slice_height = input.Height/Y_Slices;

            Image[,] slices = new Image[X_Slices,Y_Slices];
            Rect[,] regions = new Rect[X_Slices, Y_Slices];

            for (int i = 0; i < X_Slices; i++)
            {
                for (int j = 0; j < Y_Slices; j++)
                {
                    bool border = false;
                    if (j == Y_Slices - 1)
                        border = true;
                    if (i == X_Slices - 1)
                        border = true;

                    int cutting_width = 0;
                    int cutting_height = 0;

                    int XStart = 0, YStart = 0, XEnd = 0, YEnd = 0;

                    if (border)
                    {
                        XStart = i * slice_width;
                        YStart = j * slice_height;
                        XEnd = (i + 1) * slice_width;
                        YEnd = (j + 1) * slice_height;

                        if (j == Y_Slices - 1)
                        {
                            cutting_height = input.Height - ((Y_Slices - 1)*slice_height);
                            YEnd = input.Height;

                        }
                        if (i == X_Slices - 1)
                        {
                            cutting_width = input.Width - ((X_Slices - 1) * slice_width);
                            XEnd = input.Width;
                        }
                    }
                    else
                    {
                        cutting_height = slice_height;
                        cutting_width = slice_width;

                        XStart = i*slice_width;
                        YStart = j*slice_height;
                        XEnd = (i + 1)*slice_width;
                        YEnd = (j + 1)*slice_height;
                    }

                    slices[i,j] = new Image(XEnd - XStart,YEnd-YStart,input.Channels);
                    regions[i,j] = new Rect(XStart, YStart, XEnd, YEnd);
                    int si = 0, sj = 0;
                    for (int x = XStart; x < XEnd; x++)
                    {
                        for (int y = YStart; y < YEnd; y++)
                        {
                            slices[i, j][si, sj] = input[x, y];
                            sj++;
                        }
                        si++;
                        sj = 0;
                    }
                }
            }

            double rT = Utils.NormalRand(75, 25);
            IOperation operation = new AutoThreshold((int)rT,25);

            for (int i = 0; i < slices.GetLength(0); i++)
            {
                for (int j = 0; j < slices.GetLength(1); j++)
                {
                    slices[i, j] = operation.Apply(slices[i, j]);
                }
            }

            Image result = new Image(input.Width, input.Height, input.Channels);

            //int res_i = 0, res_j = 0;
            for (int i = 0; i < slices.GetLength(0); i++)
            {
                for (int j = 0; j < slices.GetLength(1); j++)
                {
                    Image slice = slices[i, j];
                    Rect r = regions[i, j];
                    //res_i = r.X;
                    //res_j = r.Y;

                    for (int si = 0, res_i = r.X; si < slice.Width && res_i < r.Width; si++, res_i++)
                    {
                        for (int sj = 0, res_j = r.Y; sj < slice.Height && res_j < r.Height; sj++, res_j++)
                        {
                            Pixel p = slice[si, sj];
                            result[res_i, res_j] = p;
                        }
                    }
                }
            }
            return result;
        }
    }
}
