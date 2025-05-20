using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eepitmenyado
{
    class adosav
    {
        public int A;
        public int B;
        public int C;
    }
    class adat
    {
        public string adoszam;
        public string utcanev;
        public string hazszam;
        public string adoosztaly;
        public float alapterulet;

        public adat(string sor)
        {
            string[] szet = sor.Split(' ');
            this.adoszam = szet[0];
            this.utcanev = szet[1];
            this.hazszam = szet[2];
            this.adoosztaly = szet[3];
            this.alapterulet = float.Parse(szet[4]);
        }
    }
    internal class Program
    {
        static adosav adok = new adosav();
        static int ado(float osszeg, string adoosztaly)
        {
            
            float adooszeg = 0;
            if (adoosztaly == "A")
            {
                 adooszeg = osszeg * adok.A;
            }
            if (adoosztaly == "B")
            {
                 adooszeg = osszeg * adok.B;
            }
            if (adoosztaly == "C")
            {
                 adooszeg = osszeg * adok.C;
            }
            if(adooszeg < 10000)
            {
                 return 0;
            }
            return (int)adooszeg;

        }
        static void Main(string[] args)
        {
            #region 1.feladat 
            List<adat> fizetendo = new List<adat>();
            string[] sorok = File.ReadAllLines("utca.txt");

           
            string[] a = sorok[0].Split(' ');
            adok.A = int.Parse(a[0]);
            adok.B = int.Parse(a[1]);
            adok.C = int.Parse(a[2]);

            for (int i = 0; i < sorok.Length - 1; i++)
            {
                adat utcak = new adat(sorok[i + 1]);
                fizetendo.Add(utcak);
            }

            #endregion

            #region 2.feladat
            Console.WriteLine("2.feladat: {0} telek szerepel", fizetendo.Count);
            #endregion

            #region 3.feladat
            Console.Write("3.feladat: Keresendő szemely(adószáma) :");
            string adoszamm = Console.ReadLine();

            List<adat> kiválogatott = new List<adat>();
            for (int i = 0; i < fizetendo.Count; i++)
            {

                if (fizetendo[i].adoszam == adoszamm)
                {
                    kiválogatott.Add(fizetendo[i]);
                }
            }
            if (kiválogatott.Count == 0)
            {
                Console.WriteLine("\tNem szerepel az adatállományban");
            }
            else
            {
                for (int i = 0; i < kiválogatott.Count; i++)
                {
                    Console.WriteLine($"\t{kiválogatott[i].utcanev} utca {kiválogatott[i].hazszam}");
                }
            }

            /*
            bool nincs = true 
            for (int i = 0; i < fizetendo.Count; i++)
            {

                if (fizetendo[i].adoszam == adoszamm)
                {
                    Console.WriteLine($"\t{kiválogatott[i].utcanev} utca {kiválogatott[i].hazszam}");
                    nincs = false;
                }
            }
            if (nincs)
            {
                Console.WriteLine($"\Nem szerepel az adatállományban"); 
            }*/
            #endregion

            #region 4-5.feladat
            int Adb = 0;
            int Bdb = 0;
            int Cdb = 0;

            int Aosszes = 0;
            int Bosszes = 0;
            int Cosszes = 0;
            for (int i = 0; i < fizetendo.Count; i++)
            {
                if (fizetendo[i].adoosztaly == "A")
                {
                    Adb++;
                    Aosszes += ado(fizetendo[i].alapterulet, fizetendo[i].adoosztaly);
                }
                if (fizetendo[i].adoosztaly == "B")
                {
                    Bdb++;
                    Bosszes += ado(fizetendo[i].alapterulet, fizetendo[i].adoosztaly);
                }
                if (fizetendo[i].adoosztaly == "C")
                {
                    Cdb++;
                    Cosszes += ado(fizetendo[i].alapterulet, fizetendo[i].adoosztaly);
                }
            }
            Console.WriteLine("4-5.feladt:");
            Console.WriteLine($"\tA sávba {Adb} teleke esik, az adó {Aosszes} Ft");
            Console.WriteLine($"\tB sávba {Bdb} teleke esik, az adó {Bosszes} Ft");
            Console.WriteLine($"\tC sávba {Cdb} teleke esik, az adó {Cosszes} Ft");
            #endregion

            #region 6.feladat
            Console.WriteLine("6.feladat:");
            for (int i = 0; i < fizetendo.Count - 1; i++)
            {
                if (i == 0 || fizetendo[i].utcanev != fizetendo[i - 1].utcanev)
                {
                    bool egy = true;
                    for (int k = i + 1; k < fizetendo.Count && fizetendo[i].utcanev == fizetendo[k].utcanev && egy; k++)
                    {
                        if (fizetendo[i].adoosztaly != fizetendo[k].adoosztaly)
                        {
                            Console.WriteLine($"\t{fizetendo[i].utcanev}");
                            egy = false;
                        }
                    }
                }
            }
            #endregion

            #region 7.feladat
            Console.Write("7.feladat: ");
            string fileName = "fizetendo.txt";
            StreamWriter ir = new StreamWriter(fileName);
            HashSet<string> tulajok = new HashSet<string>();
            for (int i = 0; i < fizetendo.Count; i++)
            {
                tulajok.Add(fizetendo[i].adoszam);
            }
            foreach (string tulaj in tulajok)
            {
                int adoja = 0;
                for (int i = 0; i < tulajok.Count; i++)
                {

                    if (fizetendo[i].adoszam == tulaj)
                    {
                        adoja += ado(fizetendo[i].alapterulet, fizetendo[i].adoosztaly);
                    } 
                }
                ir.WriteLine($"{tulaj} {adoja}");
            }
            ir.Close();
            Console.WriteLine("File OK");
            #endregion

            Console.ReadKey();
        }
    }
}
 