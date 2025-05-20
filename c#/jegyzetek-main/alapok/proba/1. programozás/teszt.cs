using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    class Ingatlan
    {
        public int Id;
        public string Leiras;
        public int Szobak;
        public int Terulet;
        public int Emelet;
        public bool Tehermentes;
        public double Szelesseg;
        public double Hosszusag;
    }

    static void Main()
    {
        // 1. Adatok betöltése
        List<Ingatlan> ingatlanok = new List<Ingatlan>();
        string[] sorok = File.ReadAllLines("realestates.csv");

        // Fejléc átugrása (első sor)
        for (int i = 1; i < sorok.Length; i++)
        {
            string[] adatok = sorok[i].Split(';');
            
            Ingatlan uj = new Ingatlan();
            uj.Id = int.Parse(adatok[0]);
            uj.Leiras = adatok[1];
            uj.Szobak = int.Parse(adatok[2]);
            uj.Terulet = int.Parse(adatok[3]);
            uj.Emelet = int.Parse(adatok[4]);
            uj.Tehermentes = adatok[10] == "1";
            
            // Koordináták feldolgozása
            string[] koordinatak = adatok[12].Split(',');
            uj.Szelesseg = double.Parse(koordinatak[0]);
            uj.Hosszusag = double.Parse(koordinatak[1]);
            
            ingatlanok.Add(uj);
        }

        // 2. Földszinti ingatlanok átlagos területe
        int osszeg = 0;
        int db = 0;
        
        foreach (var ingatlan in ingatlanok)
        {
            if (ingatlan.Emelet == 0) // földszinti
            {
                osszeg += ingatlan.Terulet;
                db++;
            }
        }
        
        double atlag = (double)osszeg / db;
        Console.WriteLine($"2. feladat: Földszinti ingatlanok átlagos alapterülete: {atlag:F2} m2");

        // 3. Legközelebbi tehermentes ingatlan
        double ovodaSzelesseg = 47.4164220114023;
        double ovodaHosszusag = 19.066342425796986;
        
        Ingatlan legkozelebbi = null;
        double minTavolsag = double.MaxValue;
        
        foreach (var ingatlan in ingatlanok)
        {
            if (ingatlan.Tehermentes)
            {
                // Pitagorasz-tétel
                double szelKulonbseg = ingatlan.Szelesseg - ovodaSzelesseg;
                double hoszKulonbseg = ingatlan.Hosszusag - ovodaHosszusag;
                double tavolsag = Math.Sqrt(szelKulonbseg * szelKulonbseg + hoszKulonbseg * hoszKulonbseg);
                
                if (tavolsag < minTavolsag)
                {
                    minTavolsag = tavolsag;
                    legkozelebbi = ingatlan;
                }
            }
        }
        
        Console.WriteLine("3. feladat: Legközelebbi tehermentes ingatlan:");
        if (legkozelebbi != null)
        {
            Console.WriteLine($"\tLeírás: {legkozelebbi.Leiras}");
            Console.WriteLine($"\tTerület: {legkozelebbi.Terulet} m2");
            Console.WriteLine($"\tSzobák száma: {legkozelebbi.Szobak}");
        }
    }
}