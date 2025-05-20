using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cseveges
{
    class beszelgetes
    {
        public DateTime kezdet;
        public DateTime veg;
        public string kezdemenyez;
        public string fogado;
        public beszelgetes(string sor)
        {
            string[] szet = sor.Split(';');
            kezdet = DateTime.ParseExact(szet[0], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            veg = DateTime.ParseExact(szet[1], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
            kezdemenyez = szet[2];
            fogado = szet[3];
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region beszelgetes
            StreamReader olvas = new StreamReader("csevegesek.txt");
            List<beszelgetes> adatok = new List<beszelgetes>();   
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                adatok.Add(new beszelgetes(olvas.ReadLine()));
               
            }
            olvas.Close();
            int length = adatok.Count;
            #endregion

            #region tagok
            string[] tagok = new string[1000];
            StreamReader olvas2 = new StreamReader("tagok.txt");
            int length2 = 0;
            while (!olvas2.EndOfStream)
            {
                tagok[length2] = olvas2.ReadLine();
                length2++;
            }
            olvas.Close();
            #endregion

            #region 4.feladat
            Console.WriteLine("4.feladat: Tagok száma: {0}  -  Beszélgetésk: {1} db", length2, length);
            #endregion

            #region 5.feladat
            TimeSpan max = adatok[0].veg - adatok[0].kezdet;
            int a = 0;
            string fog = "";
            string kezd = "";
            DateTime idokezd = DateTime.Now;
            DateTime idovege = DateTime.Now;
            for (int i = 0; i < length; i++)
            {
                if (adatok[i].veg - adatok[i].kezdet > max)
                {
                    max = adatok[i].veg - adatok[i].kezdet;
                    a++;
                }
            
            }
            for (int i = 0; i < length; i++)
            {
                if (max == adatok[i].veg - adatok[i].kezdet)
                {
                    fog = adatok[i].fogado;
                    kezd = adatok[i].kezdemenyez;
                    idokezd = adatok[i].kezdet;
                    idovege = adatok[i].veg;
                }
            }
            Console.WriteLine("5.feladat: Leghosszabb beszélgetés adatai");
            Console.WriteLine("\tKezdeményező: {0}",kezd);
            Console.WriteLine("\tFogadó:       {0}",fog);
            Console.WriteLine("\tKezdete:      {0}",idokezd);
            Console.WriteLine("\tVége          {0}",idovege);
            Console.WriteLine("\tHossz:        {0}",max);

            #endregion

            #region 6.feladat
            DateTime osszes = DateTime.Now;
            Console.Write("6.feladat: Adja meg  egy tag nevét: ");
            string keresttnev = Console.ReadLine();

            for (int i = 0; i < length; i++)
            {
                if (keresttnev == adatok[i].kezdemenyez)
                {
                    
                }
            }
            #endregion

            Console.ReadKey();
        }
    }
}
