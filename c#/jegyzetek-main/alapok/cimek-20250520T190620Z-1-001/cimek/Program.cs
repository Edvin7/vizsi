using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cimek
{
    class ipek{
        public string ip;

        public ipek( string sor2)
        {
            this.ip = sor2;
        }
    }
    internal class Program
    {
      
        static void Main(string[] args)
        {
            #region /////////////// 1.feladat ///////////////
            List<ipek> ipcimek = new List<ipek>();
            StreamReader sr = new StreamReader("ip.txt");
            {
                while (!sr.EndOfStream)
                {
                    ipcimek.Add(new ipek(sr.ReadLine()));
                }

            }
            int length = ipcimek.Count;
            #endregion

            #region /////////////// 2.feladat ///////////////
            Console.WriteLine("2.feladat:\nAz állományban {0} darab adatsor van.", length);
            #endregion

            #region /////////////// 3.feladat ///////////////
            int legal = 0;
            for (int i = 1; i < length; i++)
            {
                if (ipcimek[legal].ip.CompareTo(ipcimek[i].ip) == 1)
                {
                    legal = i;
                }
            }
            Console.WriteLine("3. feladat\nA legalacsonyabb tárolt IP-cím:\n{0}", ipcimek[legal].ip);
            #endregion

            #region /////////////// 4.feladat ///////////////
            int nincskiosztva = 0;
            int kiosztottglobalis = 0;
            int kiosztotthelyi = 0;

            for (int i = 0; i < length; i++)
            {
                if (ipcimek[i].ip.Contains("2001:0db8"))
                {
                    nincskiosztva++;

                }
                if (ipcimek[i].ip.Contains("2001:0e"))
                {
                    kiosztottglobalis++;

                }
                if (ipcimek[i].ip.Contains("fc") || ipcimek[i].ip.Contains("fd"))
                {
                    kiosztotthelyi++;

                }
            }

            Console.WriteLine("3.feladat:\nDokumentációs cím: {0} darab\nGlobális egyedi cím: {1} darab\nHelyi egyedi cím: {2} darab", nincskiosztva,kiosztottglobalis,kiosztotthelyi);
            #endregion

            #region /////////////// 5.feladat ///////////////
            StreamWriter ir = new StreamWriter("sok.txt");
            int db = 0;
            for (int i = 0; i < length; i++)
            {
                string cimek = ipcimek[i].ip;
                for (int j = 0; j < cimek.Length; j++)
                {
                    if (cimek[j] == '0')
                    {
                        db++;
                    }
                    if (db >= 18)
                    {
                        ir.WriteLine(cimek);
                    }
                }
                
            }
            ir.Close();
            #endregion

            #region /////////////// 6.feladat ///////////////
            Console.WriteLine("6. feladat:");
            Console.Write("Kérek egy sorszámot: ");
            int sorszam = int.Parse(Console.ReadLine());
            
            #region reszekrebontas
            int sorszamTemp = sorszam - 1;
            string egy = "";
            string ketto = ""; 
            string harom = ""; 
            string negy = ""; 
            string ot = "";
            string hat = "";
            string het = "";
            string nyolc = "";

            for (int i = 0; i < length; i++)
            {
                if (ipcimek[i].ip == ipcimek[sorszamTemp].ip)
                {
                    Console.WriteLine(ipcimek[i].ip);
                
                    string[] szet = ipcimek[i].ip.Split(':');
                    egy = szet[0];
                    ketto = szet[1];
                    harom = szet[2];
                    negy = szet[3];
                    ot = szet[4];
                    hat = szet[5];
                    het = szet[6];
                    nyolc = szet[7];
                }
            }
            #endregion

            #region rovidites
            string kettoTemp = "";
            string haromTemp = "";
            string negyTemp = "";
            string otTemp = "";
            string hatTemp = "";
            string hetTemp = "";

            
            if (ketto == "0000")
            {
                kettoTemp = "0";
            }
            else
            {
                kettoTemp = ketto;
            }

            if (harom == "0000")
            {
                haromTemp = "0";
            }
            else
            {
                haromTemp = harom;
            }

            if (negy == "0000")
            {
                negyTemp = "0";
            }
            else
            {
                negyTemp = negy;
            }

            if (ot == "0000")
            {
                otTemp = "0";
            }
            else
            {
                otTemp = ot;

            }

            if (hat == "0000")
            {
                hatTemp = "0";
            }
            else
            {
                hatTemp = hat;
            }

            if (het == "0000")
            {
                hetTemp = "0";
            }
            else
            {
                hetTemp = het;
            }
            #endregion

            Console.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}",egy,kettoTemp,haromTemp,negyTemp,otTemp,hatTemp,hetTemp,nyolc);
            #endregion


            #region /////////////// 7.feladat ///////////////

            #endregion
            Console.ReadKey();
        }
    }
}
