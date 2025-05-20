using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisztika
{
    class dobas
    {
        public string szemely;
        public string elsoszektor;
        public string masodikszektor;
        public string harmadikszektor;


        public dobas(string sor)
        {
            string[] szet = sor.Split(';');
            this.szemely = szet[0];
            this.elsoszektor = szet[1];
            this.masodikszektor = szet[2];
            this.harmadikszektor = szet[3];

        }

        internal class Program
        {
            static void Main(string[] args)
            {
                #region 1.feladat 
                dobas[] jatszma = new dobas[300];
                StreamReader olvas = new StreamReader("dobasok.txt");
                int length = 0;
                while (!olvas.EndOfStream)
                {
                    jatszma[length] = new dobas(olvas.ReadLine());
                    length++;
                }
                olvas.Close();
                Console.WriteLine("\t1.feladat: kész!");
                #endregion

                #region 2.feladat
                Console.WriteLine($"\t2.feladat: Körök száma {length}");
                #endregion


                #region 3.feladat
                int db = 0;
                for (int i = 0; i < length; i++)
                {
                    if (jatszma[i].harmadikszektor == "D25")
                    {
                        db++;
                    }
                }

                Console.WriteLine($"\t3.feladat: Bullseye: {db}");
                #endregion


                #region 4.feladat
                Console.Write($"\t4.feladat: Adja meg a szektor értékét:");
                string szektertek = Console.ReadLine();

                int elsoszemely = 0;
                int masodszemely = 0;
                for (int i = 0; i < length; i++)
                {
                    if (jatszma[i].szemely == "1" & (jatszma[i].elsoszektor == szektertek || jatszma[i].masodikszektor == szektertek || jatszma[i].harmadikszektor == szektertek))
                    {
                        elsoszemely++;
                    }
                    if (jatszma[i].szemely == "2" & (jatszma[i].elsoszektor == szektertek || jatszma[i].masodikszektor == szektertek || jatszma[i].harmadikszektor == szektertek))
                    {
                        masodszemely++;
                    }
                }

                Console.WriteLine($"\t\tAz 1 szemely {szektertek} dobásai: {elsoszemely}");
                Console.WriteLine($"\t\tAz 2 szemely {szektertek} dobásai: {masodszemely}");
                #endregion


                #region 5.feladat
                Console.WriteLine("\t5.feladat: ");
                int elsoszemelyfullos = 0;
                int masodszemelyfullos = 0;

                for (int i = 0; i < length; i++)
                {
                    if(jatszma[i].szemely == "1" & jatszma[i].elsoszektor == "T20" & jatszma[i].masodikszektor == "T20" & jatszma[i].harmadikszektor == "T20")
                    {
                        elsoszemelyfullos++;
                    }
                    if (jatszma[i].szemely == "2" & jatszma[i].elsoszektor == "T20" & jatszma[i].masodikszektor == "T20" & jatszma[i].harmadikszektor == "T20")
                    {
                        masodszemelyfullos++;
                    }
                }
                Console.WriteLine($"\t\tAz 1 szemely {elsoszemelyfullos} db 180-ast dobott");
                Console.WriteLine($"\t\tAz 2 szemely {masodszemelyfullos} db 180-ast dobott");
                #endregion










                Console.ReadKey();  
            }
        }
    }
    
}
