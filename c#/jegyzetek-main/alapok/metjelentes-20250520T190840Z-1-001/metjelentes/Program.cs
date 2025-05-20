using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Web;
using System.ComponentModel.Design;

namespace metjelentes
{
    class adat
    {
        public string telepules;
        public string ido;
        public string szel;
        public int homerseklet;
        public adat(string sor)
        {
            string[] szet = sor.Split(' ');
            telepules = szet[0];
            ido = szet[1];
            szel = szet[2];
            homerseklet = int.Parse(szet[3]);
        }

    }


    internal class Program
    {
        static void idop(string ido)
        {
            string idopont;
            idopont = ido.Substring(0, 2) + ":"+ ido.Substring(2, 2);
            Console.WriteLine("Idopont: {0}",idopont);     
        }

        

        static void Main(string[] args)
        {
            #region /////////////// 1.feladat ///////////////
            adat[] jelentesek = new adat[500];
            StreamReader olvas = new StreamReader("tavirathu13.txt");
            int length = 0;
            while (!olvas.EndOfStream)
            {
                jelentesek[length] = new adat(olvas.ReadLine());
                length++;
            }
            olvas.Close();
            #endregion

            #region /////////////// 2.feladat ///////////////
            Console.WriteLine("2.feladat");
            Console.Write("Kérek egy városkódot: ");
            string vkod = Console.ReadLine();
            

            int ii = length - 1;
            while (ii >= 0 && jelentesek[ii].telepules != vkod)
            {
                ii--;
                
            }
            if (ii == -1)
            {
                Console.WriteLine("nincs ilyen adat");
            }
            else
            {
                idop(jelentesek[ii].ido); 
            }
            Console.WriteLine();
            #endregion

            #region /////////////// 3.feladat ///////////////
            Console.WriteLine("3.feladat");
            int min = 0;
            int max = 0;
            

            for (int i = 0; i < length; i++)
            {
                if (jelentesek[i].homerseklet > jelentesek[max].homerseklet)
                {
                    max = i;
                }
                if (jelentesek[i].homerseklet < jelentesek[min].homerseklet)
                {
                    min = i;
                }
            }
            Console.WriteLine("A legalacsonyabb hőmérséklet: {0} {1} {2} fok.", 
                jelentesek[min].telepules,
                jelentesek[min].ido.Substring(0, 2),
                jelentesek[min].ido.Substring(2, 2),
                jelentesek[min].homerseklet);

            Console.WriteLine("A legmagasabb hőmérséklet: {0} {1} {2} fok.", 
                jelentesek[max].telepules,
                jelentesek[max].ido.Substring(0,2),
                jelentesek[max].ido.Substring(2, 2),
                jelentesek[max].homerseklet);

            #endregion

            #region /////////////// 4.feladat ///////////////
            Console.WriteLine("4.feladat");
            bool van = false;

            for (int i = 0; i < length; i++)
            {
                if (jelentesek[i].szel == "00000")
                {
                    Console.WriteLine("{0} {1}:{2}",
                        jelentesek[i].telepules,
                        jelentesek[i].ido.Substring(0, 2),
                        jelentesek[i].ido.Substring(2, 2));
                    van = true;
                }
                else
                {
                    van = false;
                }
            }

            if (van = false)
            {
                Console.WriteLine("Nem volt szélcsend a mérések idején.");
            }
            #endregion

            #region /////////////// 5.feladat ///////////////
            Console.WriteLine("5.feladat");
            HashSet<string> varos = new HashSet<string>();
            for (int i = 0; i < length; i++)
            {
                varos.Add(jelentesek[i].telepules);
            }
            foreach (string varosNev in varos)
            {
                int osszHomerseklet = 0;
                int meresDarab = 0;
                HashSet<string> orak = new HashSet<string>();
                int legalacsonyabb = int.MaxValue;
                int legmagasabb = int.MinValue;
                for (int i = 0; i < length; i++)
                {
                    if (jelentesek[i].telepules == varosNev &&
                                                        (jelentesek[i].ido.Substring(0, 2) == "01" ||
                                                        jelentesek[i].ido.Substring(0, 2) == "07" ||
                                                        jelentesek[i].ido.Substring(0, 2) == "13" ||
                                                        jelentesek[i].ido.Substring(0, 2) == "19")
                        )
                    {
                        osszHomerseklet += jelentesek[i].homerseklet;
                        meresDarab++;
                        orak.Add(jelentesek[i].ido.Substring(0, 2));
                    }
                    if (jelentesek[i].telepules == varosNev && jelentesek[i].homerseklet < legalacsonyabb)
                    {
                        legalacsonyabb = jelentesek[i].homerseklet;
                    }
                    if (jelentesek[i].telepules == varosNev && jelentesek[i].homerseklet > legmagasabb)
                    {
                        legmagasabb = jelentesek[i].homerseklet;
                    }
                }
                if (orak.Count == 4)
                {
                    Console.WriteLine("{0} Középhőmérséklete: {1:#}; Hőmérséklet-ingadozás: {2}",
                        varosNev,
                        (double)osszHomerseklet / (double)meresDarab,
                        legmagasabb - legalacsonyabb);
                }
                else
                {
                    Console.WriteLine("{0} NA; Hőmérséklet-ingadozás: {1}",
                        varosNev,
                        legmagasabb - legalacsonyabb);
                }
            }

            #endregion

            #region /////////////// 6.feladat ///////////////
            Console.WriteLine("6.feladat");
            foreach (var varosNev in varos)
            {
                string fileName = varosNev + ".txt";
                StreamWriter ir = new StreamWriter(fileName);
                ir.WriteLine(varosNev);
                for (int i = 0; i < length; i++)
                {
                    if (jelentesek[i].telepules == varosNev)
                    {
                        ir.Write("{0}:{1} ", jelentesek[i].ido.Substring(0, 2), jelentesek[i].ido.Substring(2, 2));
                        for (int j = 0; j < int.Parse(jelentesek[i].szel.Substring(3, 2)); j++)
                        {
                            ir.Write("#");
                        }
                        ir.WriteLine();
                    }
                }
                ir.Close();
            }
            Console.WriteLine("File OK");
            #endregion
            Console.ReadKey();
        }

        
    }
}