using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class szemelyek
    {
        public string nev;
       
        public szemelyek(string sor)
        {
            string[] szet = sor.Split('.');
            nev = szet[0];
            
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            //BingoJatekos kártyák = new BingoJatekos("Andi.txt");

            #region nevek be
            szemelyek[] szemelyek = new szemelyek[100];
            StreamReader olvas = new StreamReader("nevek.text");
            int length = 0;
            while (!olvas.EndOfStream)
            {
                szemelyek[length] = new szemelyek(olvas.ReadLine());
                length++;
            }
            olvas.Close();
            Console.WriteLine( );
            #endregion

            #region kártyák
            string[][] kártyák = File.ReadAllLines("Andi.txt")
               .Select(l => l.Split(';').Select(i => (i)).ToArray())
               .ToArray();

            #endregion


            Console.WriteLine("1.feladat: Kész");
            Console.WriteLine("2.feladat: Kész");
            Console.WriteLine("3.feladat: Kész");
            Console.WriteLine($"4.feladat: {length} db játékos van");


            #region szamgeneralas
            Console.WriteLine("\n");
            int vege = 25;
            List<string> genraltszamok = new List<string>();
            Random rnd = new Random();
            for (int i = 0; i < vege; i++)
            {
                

                int Szam = rnd.Next(1,76);
                genraltszamok.Add(Convert.ToString( Szam));    
            }
            for (int i = 0; i < genraltszamok.Count; i++)
            {
                if (genraltszamok[i] == genraltszamok[12])
                {
                   
                    genraltszamok[i] = "X";
                }
            }
            for (int i = 0; i < genraltszamok.Count; i++)
            {
                Console.WriteLine(i+1 + " -> "+genraltszamok[i]);
            }
            #endregion


            #region szemelykastyai
            string bigo1 = kártyák[0][0]+ kártyák[0][1]+ kártyák[0][2]+ kártyák[0][3]+ kártyák[0][4];
            string bigo2 = kártyák[1][0] + kártyák[1][1] + kártyák[1][2] + kártyák[1][3] + kártyák[1][4];
            string bigo3 = kártyák[2][0] + kártyák[2][1] + kártyák[2][2] + kártyák[2][3] + kártyák[2][4];
            string bigo4 = kártyák[3][0] + kártyák[3][1] + kártyák[3][2] + kártyák[3][3] + kártyák[3][4];
            string bigo5 = kártyák[4][0] + kártyák[4][1] + kártyák[4][2] + kártyák[4][3] + kártyák[4][4];
            string bigo6 = kártyák[0][0] + kártyák[1][0] + kártyák[2][0] + kártyák[3][0] + kártyák[4][0];
            string bigo7 = kártyák[0][1] + kártyák[1][1] + kártyák[2][1] + kártyák[3][1] + kártyák[4][1];
            string bigo8 = kártyák[0][2] + kártyák[1][2] + kártyák[2][2] + kártyák[3][2] + kártyák[4][2];
            string bigo9 = kártyák[0][3] + kártyák[1][3] + kártyák[2][3] + kártyák[3][3] + kártyák[4][3];
            string bigo10 = kártyák[0][4] + kártyák[1][4] + kártyák[2][4] + kártyák[3][4] + kártyák[4][4];
            string bigo11 = kártyák[0][0] + kártyák[1][1] + kártyák[2][2] + kártyák[3][3] + kártyák[4][4];
            string bigo12 = kártyák[4][0] + kártyák[3][1] + kártyák[2][2] + kártyák[1][3] + kártyák[0][4];
            #endregion

            #region generaltkartyak
            string bingo1 = genraltszamok[0] + genraltszamok[1] + genraltszamok[2] + genraltszamok[3] + genraltszamok[4];
            string bingo2 = genraltszamok[5] + genraltszamok[6] + genraltszamok[7] + genraltszamok[8] + genraltszamok[9];
            string bingo3 = genraltszamok[10] + genraltszamok[11] + genraltszamok[12] + genraltszamok[13] + genraltszamok[14];
            string bingo4 = genraltszamok[15] + genraltszamok[16] + genraltszamok[17] + genraltszamok[18] + genraltszamok[19];
            string bingo5 = genraltszamok[20] + genraltszamok[21] + genraltszamok[22] + genraltszamok[23] + genraltszamok[24];
            string bingo6 = genraltszamok[0] + genraltszamok[5] + genraltszamok[10] + genraltszamok[15] + genraltszamok[20];
            string bingo7 = genraltszamok[1] + genraltszamok[6] + genraltszamok[11] + genraltszamok[16] + genraltszamok[21];
            string bingo8 = genraltszamok[2] + genraltszamok[7] + genraltszamok[12] + genraltszamok[17] + genraltszamok[22];
            string bingo9 = genraltszamok[3] + genraltszamok[8] + genraltszamok[13] + genraltszamok[18] + genraltszamok[23];
            string bingo10 = genraltszamok[4] + genraltszamok[9] + genraltszamok[14] + genraltszamok[19] + genraltszamok[4];
            string bingo11 = genraltszamok[0] + genraltszamok[6] + genraltszamok[12] + genraltszamok[18] + genraltszamok[24];
            string bingo12 = genraltszamok[20] + genraltszamok[16] + genraltszamok[12] + genraltszamok[8] + genraltszamok[4];
            #endregion



            for (int i = 0; i < length; i++)
            {
                if (bigo1 == bingo1 ||
                    bigo2 == bingo2 ||
                    bigo3 == bingo3 ||
                    bigo4 == bingo4 ||
                    bigo5 == bingo5 ||
                    bigo6 == bingo6 ||
                    bigo7 == bingo7 ||
                    bigo8 == bingo8 ||
                    bigo9 == bingo9 ||
                    bigo10 == bingo10 ||
                    bigo11 == bingo11 ||
                    bigo12 == bingo12)
                {
                    Console.WriteLine("BINGÓ");
                    break;
                }
            }


            Console.ReadKey();  
        }
    }
}
