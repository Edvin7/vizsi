using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csevegesek
{
    

    public partial class Form1 : Form
    {
        List<beszelgetes> adatok = new List<beszelgetes>();
        
        string[] tagok = new string[1000];

        #region osztaly
        class beszelgetes
        {
            public DateTime kezdet;
            public DateTime veg;
            public string kezdemenyez;
            public string fogado;
            public beszelgetes(string sor)
            {
                string[] szet = sor.Split(';');
                kezdet = DateTime.ParseExact(szet[0], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
                veg = DateTime.ParseExact(szet[1], "yy.MM.dd-HH:mm:ss", CultureInfo.InvariantCulture);
                kezdemenyez = szet[2];
                fogado = szet[3];
            }

        }
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region beszelgetes
            StreamReader olvas = new StreamReader("csevegesek.txt");
            olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                adatok.Add(new beszelgetes(olvas.ReadLine()));

            }
            olvas.Close();
            int length = adatok.Count;
            #endregion

            #region tagok
            string[] tagok = new string[21];
            StreamReader olvas2 = new StreamReader("tagok.txt");
            int length2 = 0;
            while (!olvas2.EndOfStream)
            {
                tagok[length2] = olvas2.ReadLine();
                length2++;
            }
            olvas.Close();
            #endregion

            #region 4.feladat
            feladat4.Text = "4.feladat: Tagok száma: " + length2 + " - Beszélgetésk: " + length + " db";
            #endregion

            #region 5.feladat
            TimeSpan max = adatok[0].veg - adatok[0].kezdet;
            int a = 0;
            string fog = "";
            string kezd = "";
            DateTime idokezd = DateTime.Now;
            DateTime idovege = DateTime.Now;
            for (int i = 0; i < length; i++)
            {
                if (adatok[i].veg - adatok[i].kezdet > max)
                {
                    max = adatok[i].veg - adatok[i].kezdet;
                    a++;
                }

            }
            for (int i = 0; i < length; i++)
            {
                if (max == adatok[i].veg - adatok[i].kezdet)
                {
                    fog = adatok[i].fogado;
                    kezd = adatok[i].kezdemenyez;
                    idokezd = adatok[i].kezdet;
                    idovege = adatok[i].veg;
                }
            }
            feladat5.Text = "5.feladat: Leghosszabb beszélgetés adatai" + 
                Environment.NewLine + "Kezdeményező: " + kezd + 
                Environment.NewLine + "Fogadó: " + fog + 
                Environment.NewLine + "Kezdete: " + idokezd +   
                Environment.NewLine + "Vége: " + idovege +
                Environment.NewLine + "Hossz: " + max;
            #endregion

            #region 7.feladat

            #endregion

            comboBox1.Items.AddRange(tagok);
            comboBox2.Items.AddRange(tagok);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            #region 6.feladat
            string nev = feladat6a.Text;
            TimeSpan ossz = adatok[0].veg - adatok[0].veg;
            for (int i = 0; i < adatok.Count; i++)
            {

                if (adatok[i].kezdemenyez == nev)
                {
                    TimeSpan temp = adatok[i].veg - adatok[i].kezdet;
                    ossz += temp;
                }
                if (adatok[i].fogado == nev)
                {
                    TimeSpan temp2 = adatok[i].veg - adatok[i].kezdet;
                    ossz += temp2;
                }


            }

            feladat6b.Text = "A beszégetések össze ideje: " + ossz;
            #endregion
        }

     
    }
}
