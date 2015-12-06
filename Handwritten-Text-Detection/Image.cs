using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;

namespace Handwritten_Text_Detection_Library
{
    public struct Pixel
    {
        public byte R, G, B, A;

        public Pixel(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            A = 255;
        }

        public Pixel(int r, int g, int b, int a)
        {
            R = (byte) r;
            G = (byte) g;
            B = (byte) b;
            A = (byte) a;
        }

        public static Pixel White
        {
            get
            {
                Pixel p = new Pixel();
                p.R = 255;
                p.G = 255;
                p.B = 255;
                p.A = 255;
                return p;
            }
        }

        public static Pixel Black
        {
            get
            {
                Pixel p = new Pixel();
                p.R = 0;
                p.G = 0;
                p.B = 0;
                p.A = 255;
                return p;
            }
        }

        public static Pixel FromColor(Color c)
        {
            Pixel res = new Pixel();
            res.R = c.R;
            res.G = c.G;
            res.B = c.B;
            res.A = c.A;
            return res;
        }

        public static bool IsWhite(Pixel p)
        {
            if (p.R == 255 && p.G == 255 && p.B == 255)
                return true;
            else
                return false;
        }

        public static bool IsBlack(Pixel p)
        {
            if (p.R == 0 && p.G == 0 && p.B == 0)
                return true;
            else
                return false;
        }
    }

    public class Image
    {
        private byte[] m_buffer;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public int Channels { get; private set; }

        public Pixel this[int x, int y]
        {
            get { return GetPixel(x, y); }
            set { SetPixel(x, y, value); }
        }

        public Image(string path)
        {
            //load image
            Bitmap img = new Bitmap(path);

            Width = img.Width;
            Height = img.Height;
            Channels = 4;

            m_buffer = new byte[Width*Height*Channels];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    SetPixel(i, j, Pixel.FromColor(c));
                }
            }

        }

        public Image(int width, int height, int channels)
        {
            //create a new pixel
            Width = width;
            Height = height;
            Channels = channels;

            m_buffer = new byte[Width*Height*Channels];
        }

        public Pixel GetPixel(int x, int y)
        {
            Pixel res = new Pixel();

            int index = (y*Width) + x;
            index *= Channels;

            if (Channels == 1)
            {
                res.R = m_buffer[index];
            }else if (Channels == 2)
            {
                res.R = m_buffer[index];
                res.G = m_buffer[index+1];
                
            }else if (Channels == 3)
            {
                res.R = m_buffer[index];
                res.G = m_buffer[index + 1];
                res.B = m_buffer[index + 2];
            }else if (Channels == 4)
            {
                res.R = m_buffer[index];
                res.G = m_buffer[index + 1];
                res.B = m_buffer[index + 2];
                res.A = m_buffer[index + 3];
            }
            return res;
        }

        public void SetPixel(int x, int y, Pixel p)
        {
            int index = (y * Width) + x;
            index *= Channels;

            if (Channels == 1)
            {
                m_buffer[index] = p.R;
            }
            else if (Channels == 2)
            {
                m_buffer[index] = p.R;
                m_buffer[index+1] = p.G;
            }
            else if (Channels == 3)
            {
                m_buffer[index] = p.R;
                m_buffer[index + 1] = p.G;
                m_buffer[index + 2] = p.B;
            }
            else if (Channels == 4)
            {
                m_buffer[index] = p.R;
                m_buffer[index + 1] = p.G;
                m_buffer[index + 2] = p.B;
                m_buffer[index + 3] = p.A;
            }
        }

        public Bitmap ExportBitmap()
        {
            Bitmap res = new Bitmap(Width,Height,PixelFormat.Format32bppArgb);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Pixel p = GetPixel(i, j);
                    res.SetPixel(i,j,Color.FromArgb(p.A,p.R,p.G,p.B));
                }
            }
            return res;
        }

        public MWNumericArray ToMatlabArray()
        {
            MWNumericArray result = null;
            byte[, ,] data = new byte[3, Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Pixel p = GetPixel(j, i);
                    data[0, i, j] = p.R;
                    data[1, i, j] = p.G;
                    data[2, i, j] = p.B;
                }
            }
            result = new MWNumericArray(MWArrayComplexity.Real, MWNumericType.UInt8,3, Height, Width);
            result = data;
            return result;
        }

        public void FromMatlabArray(MWArray data)
        {
            var k = data.ToArray();
            for (int i = 0; i < k.GetLength(0); i++)
            {
                for (int j = 0; j < k.GetLength(1); j++)
                {
                    object a = k.GetValue(i,j);
                    byte b = (byte) a;
                    Pixel p = new Pixel((int)b,(int)b,(int)b,255);
                    SetPixel(j,i,p);
                }
            }
        }
    }
}
