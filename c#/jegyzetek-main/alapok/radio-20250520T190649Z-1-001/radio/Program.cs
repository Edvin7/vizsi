using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radio
{
    class vetel
    {
        public int nap;
        public int radioamator;
        public string szoveg;


        public vetel(string sor1, string sor2)
        {
            string[] szetbont = sor1.Split(' ');
            this.nap = int.Parse(szetbont[0]);
            this.radioamator = int.Parse(szetbont[1]);

            this.szoveg = sor2;
        }

    }
    internal class Program
    {
        static bool szame(string szo)
        {
            bool valasz = true;
            for (int i = 0; i < szo.Length; i++)
            {
                if (szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }

        static void Main(string[] args)
        {
            #region 1. feladat
            List<vetel> info = new List<vetel>();
            StreamReader olvas = new StreamReader("veetel.txt");

            while (!olvas.EndOfStream)
            {
                info.Add(new vetel(olvas.ReadLine(), olvas.ReadLine()));
            }

            olvas.Close();

            int length = info.Count;
            Console.WriteLine(info);
            #endregion

            #region 2. feladat

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Első üzenet: {0}", info[i].radioamator);
                break;
               
            }
            for (int i = length - 1; i >0; i--)
            {
                Console.WriteLine("Első üzenet: {0}", info[i].radioamator);
                break;

            }
            #endregion

            #region 3.feladat
            List<vetel> kiválogatott = new List<vetel>();
            for (int i = 0; i < length; i++)
            {

                if (info[i].szoveg.Contains("farkas"))
                {
                    kiválogatott.Add(info[i]);
                }
            }
            if (kiválogatott.Count == 0)
            {
                Console.WriteLine("3.feladat: Nincs találat");
            }
            else
            {
                Console.WriteLine("3.feladat: Van találat");
                for (int i = 0; i < kiválogatott.Count; i++)
                {
                    Console.WriteLine($"\t{kiválogatott[i].nap} nap, {kiválogatott[i].radioamator} radióamatőr");
                }
            }
            #endregion

            #region 4.feladat
            Console.WriteLine("4.feladat:");
            for (int i = 1; i <= 11; i++)
            {
                int db = 0;
                for (int j = 0; j < length; j++)
                {
                    if (info[j].nap == i)
                    {
                        db++;
                    }
                }
                Console.WriteLine($"\t{i}. nap, {db} rádióamatőr");
            }
            #endregion

            #region 5.feladat
            StreamWriter ir = new StreamWriter("adaas.txt");
            for (int i = 1; i <= 11; i++)
            {
                HashSet<string> uzik = new HashSet<string>();
                for (int j = 0; j < length; j++)
                {
                    if (info[j].nap == i)
                    {
                        uzik.Add(info[j].szoveg);
                    }
                }
                string keszuzenet = "";
                bool dollar = false;
                for (int s = 0; s < 90; s++)
                {
                    char betu = '#';
                    foreach(var item in uzik)
                    {
                        if (item[s] == '$' || dollar==true)
                        {
                            betu = '$';
                            dollar = true;
                            break;
                        }
                        if (item[s] != '#')
                        {
                             betu = item[s];
                            break;
                        }
                    }
                    keszuzenet += betu;
                }
               ir.WriteLine(keszuzenet);
            }



            #endregion

            #region 7.feladat
            Console.WriteLine("7.feladat:");
            Console.WriteLine("kérek egy napot: ");
            int benap = int.Parse(Console.ReadLine());
            Console.WriteLine("kérek egy id:-t ");
            int id = int.Parse(Console.ReadLine());

            int i = 0;
            while (i<length && !(info[i].nap == benap && info[i].radioamator == id))
            {
                i++;    
            }
            if (i == length)
            {
                Console.WriteLine("Nincs ilyen feljegyzés");
            }

            /*else
            {

            }*/
            #endregion



            Console.ReadKey  ();    
        }
    }
}
