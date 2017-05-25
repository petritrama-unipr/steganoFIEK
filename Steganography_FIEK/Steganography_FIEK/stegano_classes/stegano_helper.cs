using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Steganography_FIEK.stegano_classes
{
    public class stegano_helper
    {
        public static string stringToBits(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.ASCII.GetBytes(input))
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8));
            }
            return sb.ToString();
        }

        public static string bitsToString(string bits)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < bits.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(bits.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}
