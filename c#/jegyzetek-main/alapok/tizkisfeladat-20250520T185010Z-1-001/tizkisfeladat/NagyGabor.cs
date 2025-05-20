using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tizkisfeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.feladat
            /*Console.Write("Hány eleme legyen a tömbnek?:");
            int N = int.Parse(Console.ReadLine());

            Random random = new Random();
            List<int> szamlist = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int szam = random.Next(1, N);
                szamlist.Add(Convert.ToInt32(szam));
                Console.Write($"{szam}, ");
            }


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; i < N; j++)
                {

                    if (szamlist[i] < szamlist[j])
                    {

                        int kulombsegek = szamlist[j] - szamlist[i];
                        Console.WriteLine(kulombsegek);
                        break;
                    }
                    if (szamlist[i] > szamlist[j])
                    {

                        int kulombsegek = szamlist[i] - szamlist[j];
                        Console.WriteLine(kulombsegek);
                        break;
                    }
                }
            }*/

            #endregion

            #region 2.feladat


            #endregion

            #region 2.feladat

            #endregion

            #region 5.feladat

            Console.Write("5.feladat:\nkérek egy egész számot: ");
            int keres = Convert.ToInt32(Console.ReadLine());
            
            List<int> fibo = new List<int>(); 
            int e = 0, r = 1, t = 0;
            
            for (int i = 2; i < 100; i++)
            {
                t = e + r;
                
                fibo.Add(t);
                e = r;
                r = t;
            }

            bool van = false;   
            for (int i = 0; i < fibo.Count; i++)
            {
                if (keres == fibo[i])
                {
                    van = true;
                    break;
                    
                }
            }
            if (van)
            {
                Console.WriteLine($"{keres} szám szerepel a fibonacci-sorozatban");
            }
            else
            {
                Console.WriteLine($"{keres} szám NEM szerepel a fibonacci-sorozatban");
            }
            #endregion

            #region 6.feladat
            /*int z;
            do
            {
                Console.Write("kérek egy egész számot: ");
                z = Convert.ToInt32(Console.ReadLine());
            } while (z < 0 || z > int.MaxValue);

            string binary = Convert.ToString(z, 2);
            Console.WriteLine(binary);*/
            #endregion

            #region 7.feladat
            /*string at;
            Console.Write("kérek egy egész számot: ");
            at = Console.ReadLine();

            long n = Int64.Parse(at, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(n);
            */

            #endregion

            #region 8.feladat
            /*int b;
            do
            {
                Console.Write("kérek egy egész számot: ");
                b = Convert.ToInt32(Console.ReadLine());
            } while (b < 0 || b > int.MaxValue);


            int c;
            do
            {
                Console.Write("kérek egy 2-9 közötti számot: ");
                c = Convert.ToInt32(Console.ReadLine());
            } while (c < 2 || c > 9);
            Console.WriteLine("sikerult");

            string binary = Convert.ToString(b, c);
            Console.WriteLine(binary);*/
            #endregion

            #region 9.feladat
            /*int a;
            do
            {
                Console.Write("kérek egy pozitív számot: ");
                a = Convert.ToInt32(Console.ReadLine());
            } while (!(a%5==0 ) || a%2==0);
            Console.WriteLine("sikerult");

            */

            #endregion

            #region 10.feladat
            /*Console.WriteLine("10.feladat:");
            for (int i = N; i < N; i--)
            {
                Console.WriteLine(szamlist[i]);
            }*/
            #endregion


            Console.ReadKey();  
        }

    }

}
