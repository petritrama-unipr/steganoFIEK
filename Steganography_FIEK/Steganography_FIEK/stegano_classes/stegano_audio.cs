using System;
using System.Collections.Generic;
using System.Text;
using WaveStegano;

namespace Steganography_FIEK.stegano_classes
{
    class stegano_audio
    {
        public static WaveAudio hideText_audio(string message, WaveAudio wavAudio)
        {
            List<short> leftStream = wavAudio.GetLeftStream();
            List<short> rightStream = wavAudio.GetRightStream();

            byte[] messageByte = Encoding.ASCII.GetBytes(message);

            int messageBlock = (int)Math.Ceiling((double)messageByte.Length / (leftStream.Count * 2));
            int iBuffer = 0;

            leftStream[0] = (short)(messageByte.Length / short.MaxValue);
            rightStream[0] = (short)(messageByte.Length % short.MaxValue);

            for (int i = 0; i < leftStream.Count; i++)
            {
                if (i < leftStream.Count)
                {
                    if (iBuffer < messageByte.Length && i % 8 > 7 - messageBlock && i % 8 <= 7)
                    {
                        leftStream.Insert(i, (short)messageByte[iBuffer++]);
                    }
                }

                if (i < rightStream.Count)
                {
                    if (iBuffer < messageByte.Length && i % 8 > 7 - messageBlock && i % 8 <= 7)
                    {
                        rightStream.Insert(i, (short)messageByte[iBuffer++]);
                    }
                }
            }

            wavAudio.UpdateStreams(leftStream, rightStream);
            return wavAudio;
        }


        public static string extractText_audio(WaveAudio wavAudio)
        {
            List<short> leftStream = wavAudio.GetLeftStream();
            List<short> rightStream = wavAudio.GetRightStream();

            int leftStreamLength = leftStream[0];
            int rightStreamLength = rightStream[0];

            int messageLength = short.MaxValue * leftStreamLength + rightStreamLength;
            int messageBlock = (int)Math.Ceiling((double)messageLength / (leftStream.Count * 2));
            int iBuffer = 0;

            byte[] messageByte = new byte[messageLength];

            for (int i = 0; i < leftStream.Count; i++)
            {
                if (iBuffer < messageLength && i % 8 > 7 - messageBlock && i % 8 <= 7)
                {
                    messageByte[iBuffer++] = (byte)leftStream[i];
                    if (iBuffer < messageLength)
                        messageByte[iBuffer++] = (byte)rightStream[i];
                }
            }

            return Encoding.ASCII.GetString(messageByte).Replace('\0', ' ').Trim();
        }
    }
}
