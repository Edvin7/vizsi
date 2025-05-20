using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kell_Kocsi2
{
    class autok
    {
        public string rendszam;
        public int utasokdb;
        public string uzemanyag;
        public int berletdij;
        public autok(string sor)
        {
            string[] szet = sor.Split(',');
            rendszam = szet[0];
            utasokdb = int.Parse(szet[1]);
            uzemanyag = szet[2];
            berletdij = int.Parse(szet[3]);

        }
    }
    class berles
    {
        public string berleskezd;
        public string berlesvege;
        public string atvetelhely;
        public string leadhely;
        public string rendszamb;

        public berles(string sor)
        {
            string[] szet = sor.Split(',');
            berleskezd = szet[0];
            berlesvege = szet[1];
            atvetelhely = szet[2];
            leadhely = szet[3];
            rendszamb = szet[4];
        }
    }
    internal class Program
    {
        static List<string> csereRendezesSzoveg(List<string> cseres)
        {
            string tmp;
            for (int i = 0; i < cseres.Count - 1; i++)
            {
                for (int j = i + 1; j < cseres.Count; j++)
                {
                    if (cseres[i].CompareTo(cseres[j]) > 0)
                    {
                        tmp = cseres[i];
                        cseres[i] = cseres[j];
                        cseres[j] = tmp;
                    }
                }
            }
            return cseres;
        }
        static void Main(string[] args)
        {
            #region autok
            autok[] autoadat = new autok[500];
            StreamReader olvas = new StreamReader("Autok.csv");
            int length = 0;
            while (!olvas.EndOfStream)
            {
                autoadat[length] = new autok(olvas.ReadLine());
                length++;
            }
            olvas.Close();
            #endregion

            #region berles
            berles[] berlesadat = new berles[500];
            StreamReader olvas2 = new StreamReader("Berles.csv");
            int length2 = 0;
            while (!olvas2.EndOfStream)
            {
                berlesadat[length2] = new berles(olvas2.ReadLine());
                length2++;
            }
            olvas2.Close();
            Console.WriteLine("Az adott ügyfélhez {0} különböző autót bérelt",length);
            Console.WriteLine("Az adott ügyfélhez {0} bérlési esemény tartozik", length2);
            #endregion

            #region 2.feladat
            List<string> autosorba = new List<string>();    
            for (int i = 0; i < length2; i++)
            {
                autosorba.Add(berlesadat[i].rendszamb);   
            }
            csereRendezesSzoveg(autosorba);

            foreach (var elem in autosorba) {
                Console.WriteLine(elem);
            }

            #endregion


            #region 3.feladat
            Console.WriteLine("kérelók egy rendszamot:");
            string rendszambe = Console.ReadLine();
           
            while (!(rendszambe.Length == 7))
            {
                Console.WriteLine("kérelók egy rendszamot:");
                rendszambe = Console.ReadLine();
            }

            
            #endregion

            Console.ReadKey();
        }   
                
            
    }
}
