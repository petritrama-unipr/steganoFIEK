using System;
using System.Drawing;
using System.Text;

namespace Steganography_FIEK.stegano_classes
{
    class stegano_LSB
    {
        public static Bitmap hideText_imageLSB(string secretText, Bitmap bmpImage)
        {
            int r, g, b;

            int charIndex = 0;

            string secretTextBits = stegano_helper.stringToBits(secretText);
            secretTextBits += "00000000";

            for (int i = 0; i < bmpImage.Height; i++)
            {
                for (int j = 0; j < bmpImage.Width; j++)
                {
                    Color pixel = bmpImage.GetPixel(j, i);

                    r = pixel.R - pixel.R % 2;
                    g = pixel.G - pixel.G % 2;
                    b = pixel.B - pixel.B % 2;

                    if (charIndex < secretTextBits.Length)
                    {
                        r += secretTextBits[charIndex] % 2;
                        charIndex++;
                    }

                    if (charIndex < secretTextBits.Length)
                    {
                        g += secretTextBits[charIndex] % 2;
                        charIndex++;
                    }

                    if (charIndex < secretTextBits.Length)
                    {
                        b += secretTextBits[charIndex] % 2;
                        charIndex++;
                    }

                    bmpImage.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
                int a = 1;
            }

            return bmpImage;
        }

        public static string extractText_imageLSB(Bitmap bmpImage)
        {
            StringBuilder extractedText = new StringBuilder();
            int r, g, b;
            int zeros = 0;
            for (int i = 0; i < bmpImage.Height; i++)
            {
                for (int j = 0; j < bmpImage.Width; j++)
                {
                    Color pixel = bmpImage.GetPixel(j, i);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;

                    string rr = Convert.ToString(r, 2).PadLeft(8, '0');
                    extractedText.Append(rr[7]);
                    zeros = (rr[7] == '0') ? (zeros + 1) : (0);

                    string gg = Convert.ToString(g, 2).PadLeft(8, '0');
                    zeros = (gg[7] == '0') ? (zeros + 1) : (0);
                    extractedText.Append(gg[7]);

                    string bb = Convert.ToString(b, 2).PadLeft(8, '0');
                    zeros = (bb[7] == '0') ? (zeros + 1) : (0);
                    
                    extractedText.Append(bb[7]);
                }
            }

            return stegano_helper.bitsToString(extractedText.ToString()).Replace('\0', ' ').Trim();
        }
    }
}
