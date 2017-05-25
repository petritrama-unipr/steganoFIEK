using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Steganography_FIEK.stegano_classes
{
    class stegano_PVD
    {
        Bitmap bmpImage = null;
        int bmpImageWidth = 0;
        int bmpImageHeight = 0;
        Color[] bitmapPixelsColor;
        List<int[]> skipPixels = new List<int[]>();
        int indexPixel = 0;
        int indexPixel_new = 0;
        int indexBlock = 0;
        string secretTextBits;
        int indexSecretTextBits = 0;
        int colorRGB = 0;

        public void bitmapPixels(Bitmap bitmapImg)
        {
            bmpImageWidth = bitmapImg.Width;
            bmpImageHeight = bitmapImg.Height;
            bmpImage = bitmapImg;

            bitmapPixelsColor = new Color[bitmapImg.Width * bitmapImg.Height];
            for (int i = 0; i < bitmapImg.Height; i++)
            {
                for (int j = 0; j < bitmapImg.Width; j++)
                {
                    bitmapPixelsColor[indexPixel++] = bitmapImg.GetPixel(j, i);
                }
            }
        }

        public Object stego(Bitmap bitmapImg, String secretMsg, Boolean whatDo)
        {
            Object returnObject = null;

            bitmapPixels(bitmapImg);

            indexPixel_new = 0;
            if (whatDo)
            {
                secretTextBits = toBinaryString(secretMsg);
                int[] theInfo = hideText_imagePVD();

                int whathapend = theInfo[0];
                
                String theSecretTOLSB = theInfo[0] + "," + theInfo[1] + "," + theInfo[2];
                foreach (int[] c in skipPixels)
                {
                    theSecretTOLSB += "," + c[0] + c[1];
                }

                theSecretTOLSB = toBinaryString(theSecretTOLSB);
                StegoLSB lsbStego = new StegoLSB();
                lsbStego.stego(bitmapPixelsColor, theSecretTOLSB);
                
                if (whathapend > 0)
                {
                    indexPixel = 0;
                    for (int i = 0; i < bmpImageHeight; i++)
                    {
                        for (int j = 0; j < bmpImageWidth; j++)
                        {
                            bmpImage.SetPixel(j, i, bitmapPixelsColor[indexPixel++]);
                        }
                    }
                    returnObject = bmpImage;
                }
                else if (whathapend == -1)
                {

                }
            }
            else
            {
                String[] theSplit;
                int pixel_num_used = 0;
                int theLastStegoBitsSize = 0;
                int theLastColorStego = 0;

                try
                {
                    StegoLSB lsbStego = new StegoLSB();
                    String theSecretLSB = lsbStego.extract(bitmapPixelsColor);
                    theSplit = theSecretLSB.Split(',');
                    pixel_num_used = int.Parse(theSplit[0]);
                    theLastStegoBitsSize = int.Parse(theSplit[1]);
                    theLastColorStego = int.Parse(theSplit[2]);
                    for (int i = 3; i < theSplit.Length; i++)
                    {
                        int[] skip = new int[2];
                        skip[1] = int.Parse(theSplit[i][theSplit[i].Length - 1].ToString());
                        skip[0] = int.Parse(theSplit[i].Substring(0, theSplit[i].Length - 1));
                        skipPixels.Add(skip);
                    }
                    secretTextBits = "";
                    returnObject = extractText_imagePVD(pixel_num_used, theLastStegoBitsSize, theLastColorStego);
                }
                catch (Exception e)
                {
                    returnObject = null;
                }
            }
            return returnObject;
        }

        public Color[] getTwoBitBlock()
        {
            if (indexBlock > bitmapPixelsColor.Length)
                return null;

            Color[] block = new Color[2];
            block[0] = bitmapPixelsColor[indexBlock++];
            block[1] = bitmapPixelsColor[indexBlock++];

            return block;
        }

        public int[] grayRange(int d)
        {
            int[] gray_range = new int[2];

            if (7 >= d) { gray_range[0] = 0; gray_range[1] = 7; }
            else if (15 >= d) { gray_range[0] = 8; gray_range[1] = 15; }
            else if (31 >= d) { gray_range[0] = 16; gray_range[1] = 31; }
            else if (63 >= d) { gray_range[0] = 32; gray_range[1] = 63; }
            else if (127 >= d) { gray_range[0] = 64; gray_range[1] = 127; }
            else if (255 >= d) { gray_range[0] = 128; gray_range[1] = 255; }

            return gray_range;
        }

        public double nSubstream(int r)
        {
            return Math.Floor(Math.Log10(r) / Math.Log10(2));
        }

        public int[] readSsubstream(int s)
        {
            if (indexSecretTextBits >= secretTextBits.Length)
                return null;

            if (s >= secretTextBits.Length)
                s = secretTextBits.Length;
            else
            {
                int flag = secretTextBits.Length - indexSecretTextBits;
                if (flag < s)
                    s = flag;
            }

            int[] stream_readed = new int[s];

            int start = indexSecretTextBits;
            for (int i = start, j = 0; i < secretTextBits.Length && j < s; i++, j++)
            {
                stream_readed[j] = int.Parse(secretTextBits[i].ToString());
                indexSecretTextBits++;
            }

            return stream_readed;
        }

        public int bitsToDec(int[] secretMsgBits)
        {
            int b = 0, bit = 1;
            for (int i = secretMsgBits.Length - 1; i >= 0; i--)
            {
                b = b + secretMsgBits[i] * bit;
                bit = bit * 2;
            }
            return b;
        }

        private int[] originalPVD(int d, int d1, int p1, int p2)
        {
            int m = Math.Abs(d1 - d);

            if (p1 >= p2 && d1 > d)
            {
                p1 = (int)(p1 + Math.Ceiling((double)m / 2));
                p2 = (int)(p2 - Math.Floor((double)m / 2));
            }
            else if (p1 < p2 && d1 > d)
            {
                p1 = (int)(p1 - Math.Floor((double)m / 2));
                p2 = (int)(p2 + Math.Ceiling((double)m / 2));
            }
            else if (p1 >= p2 && d1 <= d)
            {
                p1 = (int)(p1 - Math.Ceiling((double)m / 2));
                p2 = (int)(p2 + Math.Floor((double)m / 2));
            }
            else if (p1 < p2 && d1 <= d)
            {
                p1 = (int)(p1 + Math.Ceiling((double)m / 2));
                p2 = (int)(p2 - Math.Floor((double)m / 2));
            }


            int[] Tow_Stego_Pixel = { p1, p2 };
            return Tow_Stego_Pixel;
        }

        public int[] hideText_imagePVD()
        {
            Color[] twoPixelBlock_old = getTwoBitBlock();
            int[] twoPixelBlock_new = null;
            int indexPixelUsed = 0;
            bool discardPixel = false;
            int indexRGB = 0;
            int[] p1 = new int[3], p2 = new int[3];
            int lastStegoBit = 0;
            int lastStegoColor = 0;
            bool isFinished = false;
            int[] returnedArray = new int[3];

            while(twoPixelBlock_old != null)
            {
                indexPixelUsed++;
                discardPixel = false;
                indexRGB = 0;
                int colorRGB = 0;

                while(colorRGB<3)
                {
                    discardPixel = false;
                    if(colorRGB==0)
                    {
                        indexRGB = 0;
                        p1[indexRGB] = twoPixelBlock_old[0].R;
                        p2[indexRGB] = twoPixelBlock_old[1].R;
                    }
                    else if (colorRGB == 1)
                    {
                        indexRGB = 1;
                        p1[indexRGB] = twoPixelBlock_old[0].G;
                        p2[indexRGB] = twoPixelBlock_old[1].G;
                    }
                    else if (colorRGB == 2)
                    {
                        indexRGB = 2;
                        p1[indexRGB] = twoPixelBlock_old[0].B;
                        p2[indexRGB] = twoPixelBlock_old[1].B;
                    }

                    int d = Math.Abs(p1[indexRGB] - p2[indexRGB]);
                    int[] optimalRange = grayRange(d);
                    int w = optimalRange[1] - optimalRange[0] + 1;
                    int t = (int) Math.Floor(Math.Log10(w) / Math.Log10(2));

                    if (colorRGB == 0 && t > 5)
                    {
                        int[] pixel_tmp = { indexPixelUsed, 0 };
                        skipPixels.Add(pixel_tmp);
                        colorRGB++;
                        continue;
                    }
                    else if (colorRGB == 1 && t > 3)
                    {
                        int[] pixel_tmp = { indexPixelUsed, 1 };
                        skipPixels.Add(pixel_tmp);
                        colorRGB++;
                        continue;
                    }

                    int[] sBits = readSsubstream(t);
                    if(sBits!=null && sBits.Length < 3)
                    {
                        lastStegoBit = sBits.Length;
                    }

                    isFinished = false;
                    if(sBits == null)
                    {
                        if (indexRGB == 0)
                        {
                            lastStegoColor = 2;
                            indexPixelUsed--;
                        }
                        else if (indexRGB == 1)
                            lastStegoColor = 0;
                        else if (indexRGB == 2)
                            lastStegoColor = 1;

                        isFinished = true;
                    }

                    if(!isFinished)
                    {
                        int b = bitsToDec(sBits);
                        int d1 = optimalRange[0] + b;

                        twoPixelBlock_new = originalPVD(d, d1, p1[indexRGB], p2[indexRGB]);
                        if (twoPixelBlock_new[0] > 255 || twoPixelBlock_new[1] > 255 || twoPixelBlock_new[0] < 0 || twoPixelBlock_new[1] < 0)
                        {
                            if(sBits[0]==1)
                            {
                                sBits[0] = 0;
                                discardPixel = true;
                                b = bitsToDec(sBits);
                                d1 = optimalRange[0] + b;
                            }

                            twoPixelBlock_new = originalPVD(d, d1, p1[indexRGB], p2[indexRGB]);
                            if (twoPixelBlock_new[0] > 255 || twoPixelBlock_new[1] > 255 || twoPixelBlock_new[0] < 0 || twoPixelBlock_new[1] < 0)
                            {
                                int m = Math.Abs(d1 - d);
                                if (twoPixelBlock_new[1] >= twoPixelBlock_new[0] && twoPixelBlock_new[1] > 255)
                                {
                                    twoPixelBlock_new[0] = p1[indexRGB] - m;
                                    twoPixelBlock_new[1] = p2[indexRGB];
                                }
                                else if (twoPixelBlock_new[1] < twoPixelBlock_new[0] && twoPixelBlock_new[0] > 255)
                                {
                                    twoPixelBlock_new[0] = p1[indexRGB];
                                    twoPixelBlock_new[1] = p2[indexRGB] - m;
                                }
                                else if (twoPixelBlock_new[1] >= twoPixelBlock_new[0] && twoPixelBlock_new[0] < 0)
                                {
                                    twoPixelBlock_new[0] = p1[indexRGB];
                                    twoPixelBlock_new[1] = p2[indexRGB] + m;
                                }
                                else if (twoPixelBlock_new[1] < twoPixelBlock_new[0] && twoPixelBlock_new[1] < 0)
                                {
                                    twoPixelBlock_new[0] = p1[indexRGB] + m;
                                    twoPixelBlock_new[1] = p2[indexRGB];
                                }
                            }
                        }

                        string newPixelTemp1 = Convert.ToString(twoPixelBlock_new[0], 2);
                        string newPixelTemp2 = Convert.ToString(twoPixelBlock_new[1], 2);
                        if(discardPixel==false)
                        {
                            if (newPixelTemp1[newPixelTemp1.Length - 1] == '0' && newPixelTemp2[newPixelTemp2.Length - 1] == '0')
                                twoPixelBlock_new[1]++;
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '0' && newPixelTemp2[newPixelTemp2.Length - 1] == '1')
                            {
                                if (twoPixelBlock_new[1] < 255 && twoPixelBlock_new[0] >= 0) twoPixelBlock_new[1] += 1;
                                else if (twoPixelBlock_new[0] > 0 && twoPixelBlock_new[1] == 255)
                                {
                                    twoPixelBlock_new[0] -= 2;
                                    twoPixelBlock_new[1] -= 1;
                                }
                                else if (twoPixelBlock_new[0] == 0 && twoPixelBlock_new[1] == 255)
                                    twoPixelBlock_new[1] = twoPixelBlock_new[1];
                            }
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '1' && newPixelTemp2[newPixelTemp2.Length - 1] == '0')
                                twoPixelBlock_new[0]--;
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '1' && newPixelTemp2[newPixelTemp2.Length - 1] == '1')
                                twoPixelBlock_new[0]--;
                        }
                        else
                        {
                            if (newPixelTemp1[newPixelTemp1.Length - 1] == '0' && newPixelTemp2[newPixelTemp2.Length - 1] == '0')
                                twoPixelBlock_new[0]++;
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '0' && newPixelTemp2[newPixelTemp2.Length - 1] == '1')
                                twoPixelBlock_new[0]++;
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '1' && newPixelTemp2[newPixelTemp2.Length - 1] == '0')
                            {
                                if (twoPixelBlock_new[1] > 0 && twoPixelBlock_new[0] <= 255)
                                    twoPixelBlock_new[1]--;
                                else if (twoPixelBlock_new[0] < 255 && twoPixelBlock_new[1] == 0)
                                {
                                    twoPixelBlock_new[0] += 2;
                                    twoPixelBlock_new[1] += 1;
                                }
                            }
                            else if (newPixelTemp1[newPixelTemp1.Length - 1] == '1' && newPixelTemp2[newPixelTemp2.Length - 1] == '1')
                                twoPixelBlock_new[1]--;
                        }
                    }

                    p1[indexRGB] = twoPixelBlock_new[0];
                    p2[indexRGB] = twoPixelBlock_new[1];

                    if (isFinished) break;

                    colorRGB++;
                }

                bitmapPixelsColor[indexPixel_new++] = Color.FromArgb(p1[0], p1[1], p1[2]);
                bitmapPixelsColor[indexPixel_new++] = Color.FromArgb(p2[0], p2[1], p2[2]);

                returnedArray[0] = indexPixelUsed;
                returnedArray[1] = lastStegoBit;
                returnedArray[2] = lastStegoColor;

                if (isFinished)
                    return returnedArray;

                twoPixelBlock_old = getTwoBitBlock();
            }
            
            returnedArray[0] = -1;
            returnedArray[1] = lastStegoBit;
            returnedArray[2] = lastStegoColor;

            return returnedArray;
        }

        public string extractText_imagePVD(int pixelUsed, int lastStegoBit, int lastStegoColor)
        {
            indexPixel = 0;
            Color[] twoPixelBlock_old = getTwoBitBlock();
            int[] p1 = new int[3], p2 = new int[3];
            int indexRGB = 0;

            while ((indexPixel < pixelUsed) && (twoPixelBlock_old != null))
            {
                indexPixel++;
                indexRGB = 0;
                colorRGB = 0;
                while (colorRGB < 3)
                {
                    if (colorRGB == 0)
                    {
                        indexRGB = 0;
                        p1[indexRGB] = twoPixelBlock_old[0].R;
                        p2[indexRGB] = twoPixelBlock_old[1].R;
                    }
                    else if (colorRGB == 1)
                    {
                        indexRGB = 1;
                        p1[indexRGB] = twoPixelBlock_old[0].G;
                        p2[indexRGB] = twoPixelBlock_old[1].G;
                    }
                    else if (colorRGB == 2)
                    {
                        indexRGB = 2;
                        p1[indexRGB] = twoPixelBlock_old[0].B;
                        p2[indexRGB] = twoPixelBlock_old[1].B;
                    }

                    string p1_LSB = Convert.ToString(p1[indexRGB], 2);
                    int p1_temp = p1[indexRGB];
                    if (p1_LSB[p1_LSB.Length - 1] == '0')
                        p1_temp++;
                    else
                        p1_temp--;
                    
                    int d = Math.Abs(p1_temp - p2[indexRGB]);
                    int[] optimalRange = grayRange(d);
                    int w = optimalRange[1] - optimalRange[0] + 1;
                    int t = (int)Math.Floor(Math.Log10(w) / Math.Log10(2));

                    int[] mustskipPixel = { -1, -1 };

                    if (skipPixels.Count != 0)
                        mustskipPixel = skipPixels.First<int[]>();

                    if (colorRGB == 0 && t > 5)
                    {
                        skipPixels.RemoveAt(0);
                        colorRGB++;
                        continue;
                    }
                    else if (colorRGB == 1 && t > 3)
                    {
                        skipPixels.RemoveAt(0);
                        colorRGB++;
                        continue;
                    }
                    else if (mustskipPixel[0] == indexPixel && mustskipPixel[1] == colorRGB)
                    {
                        skipPixels.RemoveAt(0);
                        colorRGB++;
                        continue;
                    }

                    int b = Math.Abs(optimalRange[0] - d);

                    string str_temp = new string('0', t);
                    char[] Bbin = str_temp.ToCharArray();

                    String newBin = Convert.ToString(b, 2);
                    for (int i = t - 1, j = newBin.Length - 1; i >= 0; i--, j--)
                    {
                        if (j >= 0)
                            Bbin[i] = newBin[j];
                    }
                    newBin = "";
                    String withChange = "";
                    for (int i = 0; i < Bbin.Length; i++)
                    {
                        newBin += Bbin[i];
                        withChange += Bbin[i];
                    }

                    if(p1_LSB[p1_LSB.Length-1]=='1')
                    {
                        char MSB = '1';
                        withChange = newBin.Substring(1);
                        withChange = MSB + withChange;
                    }

                    if(indexPixel == pixelUsed && lastStegoColor == indexRGB)
                    {
                        if (lastStegoBit != 0)
                            withChange = withChange.Substring(withChange.Length - lastStegoBit);

                        secretTextBits += withChange;
                        break;
                    }
                    else
                    {
                        secretTextBits += withChange;
                    }

                    colorRGB++;
                }

                twoPixelBlock_old = getTwoBitBlock();
            }

            return secretTextBits;
        }


        public String toBinaryString(String s)
        {
            char[] cArray = s.ToCharArray();

            StringBuilder sb = new StringBuilder();

            foreach (char c in cArray)
            {
                String cBinaryString = Convert.ToString(c, 2);

                if (cBinaryString.Length != 8)
                {
                    String tempStr = new String('0', 8);
                    char[] bin_Of_b = tempStr.ToCharArray();

                    for (int i = 8 - 1, j = cBinaryString.Length - 1; i >= 0; i--, j--)
                    {
                        if (j >= 0)
                            bin_Of_b[i] = cBinaryString[j];
                    }
                    cBinaryString = "";
                    for (int i = 0; i < bin_Of_b.Length; i++)
                    {
                        cBinaryString += bin_Of_b[i];
                    }
                }

                sb.Append(cBinaryString);
            }

            return sb.ToString();
        }
    }
}
