using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toGether
{
    internal class Program
    {
        static double feladat1(double[] x)
        {
            double legnagyobbkulombseg = Math.Abs( x[1] - x[0]);
            for (int i = 2; i < x.Length; i++)
            {
                if (Math.Abs(x[i] - x[i-1]) > legnagyobbkulombseg)
                {
                    legnagyobbkulombseg = Math.Abs(x[i] - x[i - 1]); 
                }
            }
            return legnagyobbkulombseg;
        }

        static double feladat2(double[] x)
        {
            double legkisebbkulombseg = Math.Abs(x[1] - x[0]);
            for (int i = 0; i < x.Length-1; i++)
            {
                for (int j = i + 1; j < x.Length; j++)
                {
                    if (Math.Abs(x[i] - x[j]) < legkisebbkulombseg)
                    {
                        legkisebbkulombseg = Math.Abs(x[i] - x[j]);
                    }
                }   
                
            }
            return legkisebbkulombseg;
        }

        static int feladat3(int x)
        {
            int db = 0;
            while (x%2==0) 
            { 
                x= x/2;
                db++;
            }

            return db;
        }

        static int[] feladat4(int x)
        {
            int[] ermek = { 200, 100, 50, 20, 10, 5, 2, 1 };
            int[] hanyerme = new int[ermek.Length];
            int ii = 0;
            while (x!=0)
            {
                hanyerme[ii] = x / ermek[ii];
                x = x % ermek[ii];
                ii++;
            }

            return hanyerme;


        }



        static bool feladat5(int x)
        {

            int fib1 = 1;
            int fib2 = 1;
            
            if (x!= fib2 && x !=fib1 && fib2<x) 
            {
                int csere = fib1 + fib2;
                fib1 = fib2;    
                fib2 = csere;    
            }


            return fib2 == x;

        }


        static string  feladat6(int x)
        {
            string kettes = "";

            while (x!=0)
            {
                kettes = (x % 2).ToString() + kettes;
                x = x / 2;  
            }
            return kettes;  
        }


        static void feladat7()
        {
            Console.WriteLine("kerek egy hexaszámot:");
            string hexaszam = Console.ReadLine();

            Dictionary<string, int> hexertekek = new Dictionary<string, int>()
            {
                {"0",0},
                {"1",1},
                {"2",2},
                {"3",3},
                {"4",4},
                {"5",5},
                {"6",6},
                {"7",7},
                {"8",8},
                {"9",9},
                {"A",10},
                {"B",11},
                {"C",12},
                {"D",13},
                {"E",14},
                {"F",15},
            };
            int hexnum = 0;
            for (int i = 0; i < length; i++)
            {

            }
        }



        static void Main(string[] args)
        {
            #region 1.feladat
            double[] valostomb = {1,64,95, 16.4, 1.98,200, 5000,2000.4 };
            double tesztlegnagyobbkulombseg = 4800;
            double tesztlegkisebb = 0.98;
            int egeszszam = 233, tesztprim = 0;
            int osszeg = 6958;
            List<int> cimletek = feladat4(osszeg).ToList();
            int hatosfel = 256;
            



            




            Console.WriteLine("1.feladat: {0}",feladat1(valostomb)==tesztlegnagyobbkulombseg);
            Console.WriteLine("2.feladat: {0}", feladat2(valostomb) == tesztlegkisebb);
            Console.WriteLine("3.feladat: {0}", feladat3(egeszszam) == tesztprim);
            Console.WriteLine("6.feladat: {0}", feladat6(hatosfel) == Convert.ToString(hatosfel, 2));





            #endregion

            Console.ReadKey();  
        }
    }
}
