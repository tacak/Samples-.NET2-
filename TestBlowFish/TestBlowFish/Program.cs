using System;
using System.Collections.Generic;
using System.Text;
using BlowFishCS;

namespace TestBlowFish
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] key = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9, 0xA, 0xB, 0xC, 0xD, 0xE, 0xF, 0x10};
            BlowFish bf = new BlowFish(key);

            byte[] data = new byte[] { 0x1, 0x2, 0x3, 0x2, 0x1, 0x2, 0x3, 0x8 };
            byte[] encdata;

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("{0:X2} ", data[i]);
            }
            Console.WriteLine();
            
            encdata = bf.Encrypt_ECB(data);

            for (int i = 0; i < encdata.Length; i++)
            {
                Console.Write("{0:X2} ", encdata[i]);
            }
            Console.WriteLine();
        }
    }
}
