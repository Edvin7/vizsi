using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlas
{
    class Ad
    {
        public int id;
        public int rooms;
        public string latlong;
        public int floors;
        public int area;
        public string description;
        public string freeofcharge;
        public string imageurl;
        public DateTime creatat;
        public Seller elado;
        public Category kategoria;
        public string lat;
        public string lon;
        public Ad(string sor)
        {
            string[] szet = sor.Split(';');
            id = int.Parse(szet[0]);    
            rooms = int.Parse(szet[1]);
            latlong = szet[2];
            floors = int.Parse(szet[3]);
            area = int.Parse(szet[4]);
            description = szet[5];
            freeofcharge = szet[6];
            imageurl = szet[7];
            creatat = DateTime.Parse(szet[8]);
            elado = new Seller(int.Parse(szet[9]), szet[10], szet[11]);
            kategoria = new Category(int.Parse(szet[12]), szet[13]);
            string[] db = latlong.Split(',');
            lat = db[0]; 
            lon = db[1];
        }
    }

    class Seller
    {
        public int sellerid;
        public string sellername;
        public string sellerphone; 
        public Seller (int id, string name,string phone)
        {
            sellerid = id;
            sellername = name;
            sellerphone = phone;    
        }
    }

    class Category
    {
        public int categoryid;
        public string categoryname;
        public Category(int id, string name)
        {
            categoryid = id;
            categoryname = name;
        }
    }

    internal class Program
    {
        public static List<Ad> LoadFromCsv()
        {
            List<Ad> hirdetes = new List<Ad>();
            StreamReader olvas = new StreamReader("realestates.csv");
            int length = 0;
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                hirdetes.Add(new Ad(olvas.ReadLine()));
                length++;
            }
            olvas.Close();
            return hirdetes;
        }

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = lat1 - lat2;
            double dLon = lon1 - lon2;
            return Math.Sqrt(dLat * dLat + dLon * dLon); // Egyszerű légvonal (Pitagorasz)
        }

        static void Main(string[] args)
        {
            List<Ad> hirdetesek = LoadFromCsv();
            int foldszinitlakasosszesterulet = 0;
            int db = 0;
            for (int i = 0; i < hirdetesek.Count; i++)
            {
                if (hirdetesek[i].floors ==0)
                {
                    db++;
                    foldszinitlakasosszesterulet +=hirdetesek[i].area;
                }
            }
            double atlag = foldszinitlakasosszesterulet/db;
            Console.WriteLine(atlag);

            double min = double.MaxValue;
            int sorszam = hirdetesek[0].id;
            for (int i = 0; i < hirdetesek.Count; i++)
            {
                if (hirdetesek[i].freeofcharge == "1")
                {

                    double egy = double.Parse(hirdetesek[i].lat, CultureInfo.InvariantCulture);
                    double ketto = double.Parse(hirdetesek[i].lon, CultureInfo.InvariantCulture);


                    double adottingatlan = DistanceTo(egy,ketto, 47.4164220114023, 19.066342425796986);
                    if (adottingatlan < min)
                    {
                        min = adottingatlan;
                        sorszam = i;  
                    }
                }
            }
            for (int i = 0;i < hirdetesek.Count; i++)
            {
                if (i == sorszam)
                {
                    Console.WriteLine(hirdetesek[i].elado.sellername);
                    Console.WriteLine(hirdetesek[i].elado.sellerphone);
                    Console.WriteLine(hirdetesek[i].area);
                    Console.WriteLine(hirdetesek[i].rooms);
                }
            }
            Console.ReadKey();
        }
    }
}
