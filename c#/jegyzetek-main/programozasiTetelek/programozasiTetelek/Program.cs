using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programozasiTetelek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] t = { 8, 9, 5, 4, 1, 9, 7, 3, 5, 4, 2, 6 };
            int n = 5;

            #region Összegzés tétel
            Console.WriteLine("Összegzés");
            int osszeg = 0;
            for (int i = 0; i < n; i++)
                osszeg = osszeg + t[i];
            Console.WriteLine("\tÖsszeg: " + osszeg);
            #endregion

            #region Megszámolás tétel
            Console.WriteLine("\nMegszámolás");
            int c = 0;
            for (int i = 0; i < t.Length; i++)
                if (t[i] < 5)
                    c++;

            Console.WriteLine("\t5-nél kisebb számok darabszáma: {0}", c);
            #endregion

            #region Eldöntés tétel
            Console.WriteLine("\nEldöntés 1");
            int ker = 5;
            bool van = false;
            for (int i = 0; i < t.Length; i++)
                if (t[i] == ker)
                    van = true;

            Console.WriteLine("\tIgaz-e, hogy van 5-ös a tömbben?: {0}", van);

            Console.WriteLine("\nEldöntés 2");
            int a = 0;
            while (a < t.Length && t[a] != ker)
                a++;

            if (a < n)
                Console.WriteLine("\tBenne van ");
            else
                Console.WriteLine("\tNincs benne");
            #endregion

            #region Kiválasztás tétel
            Console.WriteLine("\nKiválasztás");
            int b = 0;
            while (t[b] != ker)
                b++;

            Console.WriteLine("\tAz 5-ös indexe: {0}", b);
            #endregion

            #region Keresés tétel
            Console.WriteLine("\nKeresés");
            int z = 0;
            while (z < t.Length && t[z] != ker)
                z++;

            if (z < n)
                Console.WriteLine("\tIndexe: {0}", z);
            else
                Console.WriteLine("\tNincs benne");
            #endregion

            #region Kiválogatás tétel
            Console.WriteLine("\nKiválogatás");
            int[] f = new int[t.Length];

            int j = 0;
            for (int i = 0; i < t.Length; i++)
                if (t[i] < 5)  
                {
                    f[j] = t[i];
                    j++;
                }

            Console.Write("\tEredeti: ");
            for (int i = 0; i < t.Length; i++)
                Console.Write("{0} ", t[i]);
            Console.WriteLine();

            Console.Write("\tKiválogatott: ");
            for (int i = 0; i < j; i++)
                Console.Write("{0} ", f[i]);
            Console.WriteLine();
            #endregion

            #region Szétválogatás tétel
            Console.WriteLine("\nSzétválogatás");
            int[] m = new int[t.Length];
            int[] mm = new int[t.Length];

            int jj = 0;
            int k = 0;
            for (int i = 0; i < t.Length; i++)
                if (t[i] < 5)  //Az 5-nél kisebb számokat válogatjuk
                {
                    m[jj] = t[i];
                    jj++;
                }
                else
                {
                    mm[k] = t[i];
                    k++;
                }

            Console.Write("\tEredeti: ");
            for (int i = 0; i < t.Length; i++)
                Console.Write("{0} ", t[i]);
            Console.WriteLine();

            Console.Write("\tKiválogatott b: ");
            for (int i = 0; i < jj; i++)
                Console.Write("{0} ", m[i]);
            Console.WriteLine();

            Console.Write("\tKiválogatott c: ");
            for (int i = 0; i < k; i++)
                Console.Write("{0} ", mm[i]);
            Console.WriteLine();
            #endregion

            #region Maximum kiválasztás tétel
            Console.WriteLine("\nMaximum kiválasztás");
            int max;

            max = t[0];
            for (int i = 0; i < t.Length; i++)
                if (t[i] > max)
                    max = t[i];

            Console.WriteLine("\tA legnagyobb elem: {0}", max);
            #endregion

            #region Minimum kiválasztás tétel
            Console.WriteLine("\nMinimum kiválasztás");
            int min;

            min = t[0];
            for (int i = 1; i < t.Length; i++)
                if (t[i] < min)
                    min = t[i];

            Console.WriteLine("\tA legnagyobb elem: {0}", min);

            #endregion

            #region Buborék rendezés tétel
            Console.WriteLine("\nBuborék rendezés");
            for (int i = t.Length - 1; i > 0; i--)
                for (int l = 0; l < i; l++)
                    if (t[l] > t[l + 1])
                    {
                        int tmp = t[l + 1];
                        t[l + 1] = t[l];
                        t[l] = tmp;
                    }

            Console.Write("\t");
            for (int i = 0; i < t.Length; i++)
                Console.Write("{0} ", t[i]);
            Console.WriteLine();
            #endregion

            Console.ReadKey();
        }
    }
}
