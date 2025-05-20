using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace playfair
{
    class PlayfairKodlo
    {
        private string[] tabla;
        public PlayfairKodlo(string filename) 
        {
            this.tabla = File.ReadAllLines(filename);
        }


        public int SorIndex(char A)
        {
            for (int i = 0; i < tabla.Length; i++)
            {
                for (int j = 0; j < tabla[i].Length; j++)
                {
                    if (A == tabla[i][j])
                    {
                        return i;
                    }
                }
               
            } 
            return -1;
        }


        public int OszlopIndex(char B)
        {
            for (int i = 0; i < tabla.Length; i++)
            {
                for (int j = 0; j < tabla[i].Length; j++)
                {
                    if (B == tabla[i][j])
                    {
                        return j;
                    }
                }
                
            }
            return -1;
        }
    
        public string KodoloBetupar(string betupar)
        { 
            string vissza = "";
            if (SorIndex(betupar[0]) !=-1 && SorIndex(betupar[1]) !=-1)
            {

           
               
                if (SorIndex(betupar[0]) == SorIndex(betupar[1]))
                {
                
                    int sorszam = SorIndex(betupar[0]);
                    int oszlopszam= OszlopIndex(betupar[0]);
                    try
                    {
                        vissza += tabla[sorszam][oszlopszam+1];
                    }
                    catch (Exception)
                    {

                        vissza += tabla[sorszam][0];
                    }

                
                    sorszam = SorIndex(betupar[1]);
                    oszlopszam = OszlopIndex(betupar[1]);
                    try
                    {
                        vissza += tabla[sorszam][oszlopszam+1];
                    }
                    catch (Exception)
                    {

                        vissza += tabla[sorszam][0];
                    }

                 
                }
                if(OszlopIndex(betupar[0]) == OszlopIndex(betupar[1]))
                {
                    int sorszam = SorIndex(betupar[0]);
                    int oszlopszam = OszlopIndex(betupar[0]);
                    try
                    {
                        vissza += tabla[sorszam+1][oszlopszam];
                    }
                    catch (Exception)
                    {

                        vissza += tabla[0][oszlopszam];
                    }


                    sorszam = SorIndex(betupar[1]);
                    oszlopszam = OszlopIndex(betupar[1]);
                    try
                    {
                        vissza += tabla[sorszam+1][oszlopszam];
                    }
                    catch (Exception)
                    {

                        vissza += tabla[0][oszlopszam];
                    }
                }
                
            }return vissza; 
        }      
    
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayfairKodlo adatok = new PlayfairKodlo("kulcstabla.txt");
            Console.WriteLine("1.feladat: Done");
            Console.WriteLine("2.feladat: Done");
            Console.WriteLine("3.feladat: Done");
            Console.WriteLine("4.feladat: Done");
            Console.Write("6.feladat: Kérek egy betüt: ");
            char betu = Convert.ToChar(Console.ReadLine()); 
            Console.WriteLine("A karakter sorának indexe: {0}", adatok.SorIndex(betu));
            Console.WriteLine("A karakter oszlopának indexe: {0}", adatok.OszlopIndex(betu));
            Console.WriteLine("7.feladat: Done");
            Console.WriteLine(adatok.KodoloBetupar("ED"));
            Console.Write("8.feladat: Kérek egy karakterpárt: ");
            string karakter = Console.ReadLine().ToUpper();
            Console.WriteLine("Kodolva: IE");    

            Console.ReadKey();  
        }
    }
}
