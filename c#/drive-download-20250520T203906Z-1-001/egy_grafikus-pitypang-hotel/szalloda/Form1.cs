using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szalloda
{
    public partial class Form1 : Form
    {
        static List<Class1> foglalasok = new List<Class1>();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            File.Delete("bevetel.txt");

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            StreamReader sr = new StreamReader("pitypang.txt", Encoding.UTF8);
            //sr.ReadLine(); //984
            string sor = "0";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                Class1 h = new Class1(sor);
                foglalasok.Add(h);
            }

            sr.Close();

            string maxNev = "";
            int maxErkezes = 0;
            int maxEltoltott = foglalasok[1].TavozasNapja - foglalasok[1].ErkezesNapja; ;


            for (int i = 0; i < foglalasok.Count; i++)
            {
                int tempEltoltott = foglalasok[i].TavozasNapja - foglalasok[i].ErkezesNapja;
                if (tempEltoltott > maxEltoltott)
                {
                    maxEltoltott = tempEltoltott;
                    maxErkezes = foglalasok[i].ErkezesNapja;
                    maxNev = foglalasok[i].Nev;
                }

            }

            label4.Text = maxNev + " (" + maxErkezes + ") - " + maxEltoltott;




            StreamWriter sw = new StreamWriter("bevetel.txt", true, Encoding.ASCII);

            for (int i = 0; i < foglalasok.Count; i++)
            {
                
                
                
                int szobaAr = 9000;
                if (foglalasok[i].ErkezesNapja >= 121 && foglalasok[i].ErkezesNapja < 244)
                {
                    szobaAr = 10000;
                }  else if (foglalasok[i].ErkezesNapja >= 244)
                {
                    szobaAr = 8000;
                }


                int tempnapokSzama = foglalasok[i].TavozasNapja - foglalasok[i].ErkezesNapja;


                int tempOsszeg = (tempnapokSzama * szobaAr) + (tempnapokSzama * foglalasok[i].VendegekSzama * 1100);


                if (foglalasok[i].VendegekSzama != 2)
                {
                    tempOsszeg += tempnapokSzama * 2000;

                }

                
                int tempSorszam = foglalasok[i].Sorszam;

                string sorocska = tempSorszam + ";" + tempOsszeg + "\n";
                sw.Write(sorocska);

            }
            
            sw.Close();
            label1.Text = "A fájlba írás sikeres volt";
        }
    }
}
