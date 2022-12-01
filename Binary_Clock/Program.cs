using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Binary_Clock
{
    class Program
    {
        static public string[,] timp = new string[4, 6];
        static public int h, m, s;
        static void Main(string[] args)
        {
            timp[0, 0] = " ";
            timp[1, 0] = " ";
            timp[0, 2] = " ";
            timp[0, 4] = " ";

            while (!Console.KeyAvailable)
            {
                DateTime time = DateTime.Now;
                h = time.Hour;
                m = time.Minute;
                s = time.Second;

                ConvertSeconds();
                ConvertMinutes();
                ConvertHours();
                ShowBinaryClock();

                Console.WriteLine($"{h}:{m}:{s}");
                Thread.Sleep(1000);

                Console.Clear();
            }
        }

        private static void ShowBinaryClock()
        {
            for(int i = 0; i < 4; i++)
                {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(timp[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ConvertHours()
        {
            int st, dr;
            st = h / 10;
            dr = h % 10;
            int bin;
            st = ConvertToBinary(st);
            for (int i = 2; i < 4; i++)
            {
                bin = st / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 0] = Convert.ToString(bin);
            }
            dr = ConvertToBinary(dr);
            for (int i = 0; i < 4; i++)
            {
                bin = dr / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 1] = Convert.ToString(bin);
            }
        }

        private static void ConvertMinutes()
        {
            int st, dr;
            st = m / 10;
            dr = m % 10;
            int bin;
            st = ConvertToBinary(st);
            for (int i = 1; i < 4; i++)
            {
                bin = st / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 2] = Convert.ToString(bin);
            }
            dr = ConvertToBinary(dr);
            for (int i = 0; i < 4; i++)
            {
                bin = dr / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 3] = Convert.ToString(bin);
            }
        }

        private static void ConvertSeconds()
        {
            int st, dr;
            st = s / 10;
            dr = s % 10;
            int bin;
            st = ConvertToBinary(st);
            for (int i = 1; i < 4; i++)
            {
                bin = st / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 4] = Convert.ToString(bin);
            }
            dr = ConvertToBinary(dr);
            for (int i = 0; i < 4; i++)
            {
                bin = dr / (int)Math.Pow(10, 3 - i) % 10;
                timp[i, 5] = Convert.ToString(bin);
            }
        }

        private static int ConvertToBinary(int n)
        {
            switch (n)
            {
                case 0: n = 0; break;
                case 1: n = 1; break;
                case 2: n = 10; break;
                case 3: n = 11; break;
                case 4: n = 100; break;
                case 5: n = 101; break;
                case 6: n = 110; break;
                case 7: n = 111; break;
                case 8: n = 1000; break;
                case 9: n = 1001; break;
            }
            return n;
        }
    }
}
