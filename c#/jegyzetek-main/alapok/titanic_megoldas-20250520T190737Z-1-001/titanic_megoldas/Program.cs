using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace titanic_megoldas
{
    class adat
    {
        public string kategorianev;
        public int tulelo;
        public int eltunt;

        public adat(string sor)
        {
            string[] szet = sor.Split(';');
            this.kategorianev = szet[0];
            this.tulelo = int.Parse(szet[1]);
            this.eltunt = int.Parse(szet[2]);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1.feladat 
            List<adat> adatok = new List<adat>();
            StreamReader olvas = new StreamReader("titanic.txt");
            int length = 0;
            while (!olvas.EndOfStream)
            {
                adatok.Add(new adat(olvas.ReadLine()));
                length++;
            }
            olvas.Close();
            #endregion

            #region 2.feladat
            Console.WriteLine("2.feladat: {0} db", adatok.Count);
            #endregion

            #region 3.feladat
            int ossz = 0;
            int os = 0;
            for (int i = 0; i < length; i++)
            {
                ossz += adatok[i].tulelo;
                os += adatok[i].eltunt;
            }
            int osszes = ossz + os;
            Console.WriteLine("3.feladat: {0} fő", osszes);
            #endregion

            #region 4 - 5.feladat
            Console.Write("4.feladat: Keresendő szó:");
            string kulcsszo = Console.ReadLine();
            List<adat>kiválogatott = new List<adat>();
            for (int i = 0; i < length; i++)
            {
                
                if (adatok[i].kategorianev.Contains(kulcsszo))
                {
                    kiválogatott.Add(adatok[i]);    
                }
            }
            if (kiválogatott.Count ==0)
            {
                Console.WriteLine("\tNincs találat");
            }
            else
            {
                Console.WriteLine("\tVan találat\n5.feladat:");
                for (int i = 0; i < kiválogatott.Count; i++)
                {
                    Console.WriteLine($"\t{kiválogatott[i].kategorianev} {kiválogatott[i].tulelo + kiválogatott[i].eltunt} fő");
                }
            }


            #endregion

            #region 6.feladat
            Console.WriteLine("6.feladat:");
            int utasok = 0;
            for (int i = 0; i < length; i++)
            {
                utasok = adatok[i].tulelo + adatok[i].eltunt;
                if (adatok[i].eltunt / ((double)adatok[i].tulelo + (double)adatok[i].eltunt) > 0.6)
                {
                    Console.WriteLine($"\t{adatok[i].kategorianev}");
                }
            }
            #endregion

            #region 7.feladat
            int max = 0;
            for (int i = 0; i < length; i++)
            {
                if (adatok[i].eltunt > max)
                {
                    max = adatok[i].eltunt;
                }
            }

            string leg = "";
            for (int i = 0; i < length; i++)
            {
                if (max == adatok[i].eltunt)
                {
                    leg = adatok[i].kategorianev;
                }
            }
            Console.WriteLine("7.feladat: {0}", leg);
            #endregion

            Console.ReadKey();
        }
    }
}
