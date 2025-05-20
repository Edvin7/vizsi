using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyszeruKonzolos
{

    class rak
    {
        public string termekkod;
        public string termeknev;
        public int termekar;
        public int keszletdb;

        public rak(string sor)
        {
            string[] szet = sor.Split(';');
            termekkod = szet[0];
            this.termeknev = szet[1];
            this.termekar = int.Parse(szet[2]);
            this.keszletdb = int.Parse(szet[3]);

        }
    }
    class rendM
    {
        public string sortipus;
        public string rendelesdatum;
        public string rendelesszama;
        public string email;

        public rendM(string sor)
        {
            string[] szet = sor.Split(';');
            this.sortipus = szet[0];
            this.rendelesdatum = szet[1];
            this.rendelesszama = szet[2];
            this.email = szet[3];

        }
    }
    class rendT
    {
        public string sortipus;
        public string rendelesszama;
        public string termekkod;
        public int mennyiseg;

        public rendT(string sor)
        {
            string[] szet = sor.Split(';');
            this.sortipus = szet[0];
            this.rendelesszama = szet[1];
            this.termekkod = szet[2];
            this.mennyiseg = int.Parse(szet[3]);

        }
    }
    internal class Program
    {
     
        static void Main(string[] args)
        {
            #region raktar beolvas
            List<rak> raktar = new List<rak>();
            StreamReader olvas = new StreamReader("raktar.csv");
            int length = 0;
            while (!olvas.EndOfStream)
            {
                raktar.Add(new rak(olvas.ReadLine()));
                length++;
            }
            olvas.Close();
            #endregion

            #region rendeles beolvas
            List<rendM> megrendeles = new List<rendM>();
            List<rendT> rendtetelek = new List<rendT>();
            string[] alap = File.ReadAllLines("rendeles.csv");
            #endregion

            #region rendezes
            for (int i = 0; i < alap.Length; i++)
            {
                if (alap[i].Contains("M"))
                {
                    megrendeles.Add(new rendM(alap[i]));
                }
                else
                {
                    rendtetelek.Add(new rendT(alap[i]));
                }
            }
            #endregion

            #region rendeles feldolgozas

            // raktarDict létrehozása for ciklussal
            Dictionary<string, rak> raktarDict = new Dictionary<string, rak>();
            for (int i = 0; i < raktar.Count; i++)
            {
                rak aktualis = raktar[i];
                raktarDict.Add(aktualis.termekkod, aktualis);
            }

            StreamWriter levelek = new StreamWriter("levelek.csv", false, Encoding.UTF8);
            Dictionary<string, int> beszerzes = new Dictionary<string, int>();

            for (int i = 0; i < megrendeles.Count; i++)
            {
                rendM rendel = megrendeles[i];

                // rendeléshez tartozó tételek kigyűjtése for ciklussal
                List<rendT> tetelek = new List<rendT>();
                for (int j = 0; j < rendtetelek.Count; j++)
                {
                    if (rendtetelek[j].rendelesszama == rendel.rendelesszama)
                    {
                        tetelek.Add(rendtetelek[j]);
                    }
                }

                bool teljesitheto = true;

                // Ellenőrzés, hogy minden tétel teljesíthető-e
                for (int k = 0; k < tetelek.Count; k++)
                {
                    rendT tetel = tetelek[k];

                    if (!raktarDict.ContainsKey(tetel.termekkod) || raktarDict[tetel.termekkod].keszletdb < tetel.mennyiseg)
                    {
                        teljesitheto = false;
                        break;
                    }
                }

                int osszAr = 0;

                if (teljesitheto)
                {
                    // készlet csökkentése és ár összegzése
                    for (int k = 0; k < tetelek.Count; k++)
                    {
                        rendT tetel = tetelek[k];
                        raktarDict[tetel.termekkod].keszletdb -= tetel.mennyiseg;
                        osszAr += raktarDict[tetel.termekkod].termekar * tetel.mennyiseg;
                    }

                    Console.WriteLine($"Teljesíthető: {rendel.rendelesszama}");
                    levelek.WriteLine($"{rendel.email};A rendelését két napon belül szállítjuk. A rendelés értéke: {osszAr} Ft");
                }
                else
                {
                    Console.WriteLine($"Várakozó: {rendel.rendelesszama}");
                    levelek.WriteLine($"{rendel.email};A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");

                    // beszerzéshez hiány számítása
                    for (int k = 0; k < tetelek.Count; k++)
                    {
                        rendT tetel = tetelek[k];
                        int hiany = tetel.mennyiseg;

                        if (raktarDict.ContainsKey(tetel.termekkod))
                        {
                            int aktualisKeszlet = raktarDict[tetel.termekkod].keszletdb;
                            hiany = Math.Max(0, tetel.mennyiseg - aktualisKeszlet);
                        }

                        if (hiany > 0)
                        {
                            if (!beszerzes.ContainsKey(tetel.termekkod))
                            {
                                beszerzes[tetel.termekkod] = 0;
                            }
                            beszerzes[tetel.termekkod] += hiany;
                        }
                    }
                }
            }

            levelek.Close();

            #endregion


            #region beszerzes kiiras
            StreamWriter beszerzesKi = new StreamWriter("beszerzes.csv", false, Encoding.UTF8);
            List<string> kulcsok = new List<string>(beszerzes.Keys);
            for (int i = 0; i < kulcsok.Count; i++)
            {
                string kulcs = kulcsok[i];
                int ertek = beszerzes[kulcs];
                beszerzesKi.WriteLine($"{kulcs};{ertek}");
            }

            beszerzesKi.Close();

            #endregion


            Console.ReadKey();
        }
    }
}
