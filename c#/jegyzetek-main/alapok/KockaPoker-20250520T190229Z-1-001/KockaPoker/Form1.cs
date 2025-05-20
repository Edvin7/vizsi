using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KockaPoker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<string> szinek = new List<string>()
            {
                "ARANY -> ROYAL FLASH","SÁRGA -> DRILL(4 EGYFORMA)","LILA -> SOR","KÉK -> FULL(3+2 EGYFORMA)","PIROS -> DRILL(3 EGYFORMA)","NARANCSSÁRGA -> 2xPÁR","ZÖLD -> PÁR","SZÍNTELEN -> SEMMI"
            };
            richTextBox1.Text = String.Join(Environment.NewLine, szinek);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            #region Dobasok
            List<int> egyesjatekos = new List<int>();
            List<int> kettesjatekos = new List<int>();
            List<int> harmasjatekos = new List<int>();
            List<int> negyesjatekos = new List<int>();
            List<int> otosjatekos = new List<int>();
            List<int> hatosjatekos = new List<int>();
            Random rszam = new Random();

            
            for (int i = 0; i < 5; i++)
            {
                egyesjatekos.Add(rszam.Next(1, 7));
            }
            for (int i = 0; i < 5; i++)
            {
                kettesjatekos.Add(rszam.Next(1, 7));
            }
            for (int i = 0; i < 5; i++)
            {
                harmasjatekos.Add(rszam.Next(1, 7));
            }
            for (int i = 0; i < 5; i++)
            {
                negyesjatekos.Add(rszam.Next(1, 7));
            }
            for (int i = 0; i < 5; i++)
            {
                otosjatekos.Add(rszam.Next(1, 7));
            }
            for (int i = 0; i < 5; i++)
            {
                hatosjatekos.Add(rszam.Next(1, 7));
            }


            #endregion

            /*
            label1.Text = String.Join(" ", egyesjatekos);
            label2.Text = String.Join(" ", kettesjatekos);
            label3.Text = String.Join(" ", harmasjatekos);
            label4.Text = String.Join(" ", negyesjatekos);
            label5.Text = String.Join(" ", otosjatekos);
            label6.Text = String.Join(" ", hatosjatekos);
            */

            #region Dobás képek 
            //H:\2023-24\C#\20240201_NagyGabor\
            pictureBox1.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + egyesjatekos[0] + ".jpg");
            pictureBox2.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + egyesjatekos[1] + ".jpg");
            pictureBox3.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + egyesjatekos[2] + ".jpg");
            pictureBox4.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + egyesjatekos[3] + ".jpg");
            pictureBox5.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + egyesjatekos[4] + ".jpg"); 



            pictureBox10.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + kettesjatekos[0] + ".jpg");
            pictureBox9.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + kettesjatekos[1] + ".jpg");
            pictureBox8.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + kettesjatekos[2] + ".jpg");
            pictureBox7.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + kettesjatekos[3] + ".jpg");
            pictureBox6.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + kettesjatekos[4] + ".jpg");


            pictureBox15.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + harmasjatekos[0] + ".jpg");
            pictureBox14.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + harmasjatekos[1] + ".jpg");
            pictureBox13.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + harmasjatekos[2] + ".jpg");
            pictureBox12.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + harmasjatekos[3] + ".jpg");
            pictureBox11.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + harmasjatekos[4] + ".jpg");


            pictureBox20.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + negyesjatekos[0] + ".jpg");
            pictureBox19.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + negyesjatekos[1] + ".jpg");
            pictureBox18.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + negyesjatekos[2] + ".jpg");
            pictureBox17.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + negyesjatekos[3] + ".jpg");
            pictureBox16.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + negyesjatekos[4] + ".jpg");


            pictureBox25.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + otosjatekos[0] + ".jpg");
            pictureBox24.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + otosjatekos[1] + ".jpg");
            pictureBox23.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + otosjatekos[2] + ".jpg");
            pictureBox22.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + otosjatekos[3] + ".jpg");
            pictureBox21.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + otosjatekos[4] + ".jpg");


            pictureBox30.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + hatosjatekos[0] + ".jpg");
            pictureBox29.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + hatosjatekos[1] + ".jpg");
            pictureBox28.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + hatosjatekos[2] + ".jpg");
            pictureBox27.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + hatosjatekos[3] + ".jpg");
            pictureBox26.Image = Image.FromFile(@"D:\SUSU\12.I\20240201_NagyGabor\_" + hatosjatekos[4] + ".jpg");
            #endregion


            #region Egyesjátékos

            #region Szamolások
            int egy = 0;
            int ketto = 0;
            int harom = 0;
            int negy = 0;
            int ot = 0;
            int hat = 0;
            
            for (int i = 0; i < egyesjatekos.Count; i++)
            {
                if (egyesjatekos[i] == 1)
                {
                    egy++;
                }
                if (egyesjatekos[i] == 2)
                {
                    ketto++;
                }
                if (egyesjatekos[i] == 3)
                {
                    harom++;
                }
                if (egyesjatekos[i] == 4)
                {
                    negy++;
                }
                if (egyesjatekos[i] == 5)
                {
                    ot++;
                }
                if (egyesjatekos[i] == 6)
                {
                    hat++;
                }
            }
            

            int ossz=0;
            if (egy == 2) 
            {
                ossz++;
            };
            if (ketto == 2) 
            {
                ossz++; 
            };
            if (harom == 2) 
            {
                ossz++; 
            };
            if (negy == 2) 
            {
                ossz++; 
            };
            if (ot == 2) 
            {
                ossz++; 
            };
            if (hat == 2) 
            {
                ossz++; 
            };
            #endregion

            //5egyforma
            if (egy == 5 || ketto == 5 || harom == 5 || negy == 5 || ot == 5 || hat == 5)
            {
                label1.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy == 4 || ketto == 4 || harom == 4 || negy == 4 || ot == 4 || hat == 4)
            {
                label1.BackColor = System.Drawing.Color.Yellow;
            }

            

            //3 egyforma + 2 egyforma
            if ((egy == 3 || ketto == 3 || harom == 3 || negy == 3 || ot == 3 || hat == 3)&&
                (egy == 2 || ketto == 2 || harom == 2 || negy == 2 || ot == 2 || hat == 2))
            {
                label1.BackColor = System.Drawing.Color.Blue;
            }

           //3 egyforma
            if(egy ==3||ketto ==3 || harom ==3||negy ==3||ot==3||hat == 3)
            {
                label1.BackColor = System.Drawing.Color.Red;
            }

           //2db 2egyforma
            if (ossz ==2)
            {
                label1.BackColor = System.Drawing.Color.Orange;
            }
 
            //2egyforma
            if (ossz == 1)
            {
                label1.BackColor = System.Drawing.Color.Green;
            }
            #endregion


            #region Kettesjátékos
            

            #region Szamolások
            int egy2 = 0;
            int ketto2 = 0;
            int harom2 = 0;
            int negy2 = 0;
            int ot2 = 0;
            int hat2 = 0;

            for (int i = 0; i < kettesjatekos.Count; i++)
            {
                if (kettesjatekos[i] == 1)
                {
                    egy2++;
                }
                if (kettesjatekos[i] == 2)
                {
                    ketto2++;
                }
                if (kettesjatekos[i] == 3)
                {
                    harom2++;
                }
                if (kettesjatekos[i] == 4)
                {
                    negy2++;
                }
                if (kettesjatekos[i] == 5)
                {
                    ot2++;
                }
                if (kettesjatekos[i] == 6)
                {
                    hat2++;
                }
            }


            int ossz2 = 0;
            if (egy2 == 2)
            {
                ossz2++;
            };
            if (ketto2 == 2)
            {
                ossz2++;
            };
            if (harom2 == 2)
            {
                ossz2++;
            };
            if (negy2 == 2)
            {
                ossz2++;
            };
            if (ot2 == 2)
            {
                ossz2++;
            };
            if (hat2 == 2)
            {
                ossz2++;
            };
            #endregion


            //5egyforma
            if (egy2 == 5 || ketto2 == 5 || harom2 == 5 || negy2 == 5 || ot2 == 5 || hat2 == 5)
            {
                label2.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy2 == 4 || ketto2 == 4 || harom2 == 4 || negy2 == 4 || ot2 == 4 || hat2 == 4)
            {
                label2.BackColor = System.Drawing.Color.Yellow;
            }

            

            //3 egyforma + 2 egyforma
            if ((egy2 == 3 || ketto2 == 3 || harom2 == 3 || negy2 == 3 || ot2 == 3 || hat2 == 3) &&
                (egy2 == 2 || ketto2 == 2 || harom2 == 2 || negy2 == 2 || ot2 == 2 || hat2 == 2))
            {
                label2.BackColor = System.Drawing.Color.Blue;
            }

            //3 egyforma
            if (egy2 == 3 || ketto2 == 3 || harom2 == 3 || negy2 == 3 || ot2 == 3 || hat2 == 3)
            {
                label2.BackColor = System.Drawing.Color.Red;
            }

            //2db 2egyforma
            if (ossz2 == 2)
            {
                label2.BackColor = System.Drawing.Color.Orange;
            }

            //2egyforma
            if (ossz2 == 1)
            {
                label2.BackColor = System.Drawing.Color.Green;
            }
            #endregion


            #region Hármasjátékos


            #region Szamolások
            int egy3 = 0;
            int ketto3 = 0;
            int harom3 = 0;
            int negy3 = 0;
            int ot3 = 0;
            int hat3 = 0;

            for (int i = 0; i < harmasjatekos.Count; i++)
            {
                if (harmasjatekos[i] == 1)
                {
                    egy3++;
                }
                if (harmasjatekos[i] == 2)
                {
                    ketto3++;
                }
                if (harmasjatekos[i] == 3)
                {
                    harom3++;
                }
                if (harmasjatekos[i] == 4)
                {
                    negy3++;
                }
                if (harmasjatekos[i] == 5)
                {
                    ot3++;
                }
                if (harmasjatekos[i] == 6)
                {
                    hat3++;
                }
            }


            int ossz3 = 0;
            if (egy3 == 2)
            {
                ossz3++;
            };
            if (ketto3 == 2)
            {
                ossz3++;
            };
            if (harom3 == 2)
            {
                ossz3++;
            };
            if (negy3 == 2)
            {
                ossz3++;
            };
            if (ot3 == 2)
            {
                ossz3++;
            };
            if (hat3 == 2)
            {
                ossz3++;
            };
            #endregion


            //5egyforma
            if (egy3 == 5 || ketto3 == 5 || harom3 == 5 || negy3 == 5 || ot3 == 5 || hat3 == 5)
            {
                label3.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy3 == 4 || ketto3 == 4 || harom3 == 4 || negy3 == 4 || ot3 == 4 || hat3 == 4)
            {
                label3.BackColor = System.Drawing.Color.Yellow;
            }

            

            //3 egyforma + 2 egyforma
            if ((egy3 == 3 || ketto3 == 3 || harom3 == 3 || negy3 == 3 || ot3 == 3 || hat3 == 3) &&
                (egy3 == 2 || ketto3 == 2 || harom3 == 2 || negy3 == 2 || ot3 == 2 || hat3 == 2))
            {
                label3.BackColor = System.Drawing.Color.Blue;
            }

            //3 egyforma
            if (egy3 == 3 || ketto3 == 3 || harom3 == 3 || negy3 == 3 || ot3 == 3 || hat3 == 3)
            {
                label3.BackColor = System.Drawing.Color.Red;
            }

            //2db 2egyforma
            if (ossz3 == 2)
            {
                label3.BackColor = System.Drawing.Color.Orange;
            }

            //2egyforma
            if (ossz3 == 1)
            {
                label3.BackColor = System.Drawing.Color.Green;
            }
            #endregion


            #region Négyesjátékos


            #region Szamolások
            int egy4 = 0;
            int ketto4 = 0;
            int harom4 = 0;
            int negy4 = 0;
            int ot4 = 0;
            int hat4 = 0;

            for (int i = 0; i < negyesjatekos.Count; i++)
            {
                if (negyesjatekos[i] == 1)
                {
                    egy4++;
                }
                if (negyesjatekos[i] == 2)
                {
                    ketto4++;
                }
                if (negyesjatekos[i] == 3)
                {
                    harom4++;
                }
                if (negyesjatekos[i] == 4)
                {
                    negy4++;
                }
                if (negyesjatekos[i] == 5)
                {
                    ot4++;
                }
                if (negyesjatekos[i] == 6)
                {
                    hat4++;
                }
            }


            int ossz4 = 0;
            if (egy4 == 2)
            {
                ossz4++;
            };
            if (ketto4 == 2)
            {
                ossz4++;
            };
            if (harom4 == 2)
            {
                ossz4++;
            };
            if (negy4 == 2)
            {
                ossz4++;
            };
            if (ot4 == 2)
            {
                ossz4++;
            };
            if (hat4 == 2)
            {
                ossz4++;
            };
            #endregion


            //5egyforma
            if (egy4 == 5 || ketto4 == 5 || harom4 == 5 || negy4 == 5 || ot4 == 5 || hat4 == 5)
            {
                label4.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy4 == 4 || ketto4 == 4 || harom4 == 4 || negy4 == 4 || ot4 == 4 || hat4 == 4)
            {
                label4.BackColor = System.Drawing.Color.Yellow;
            }



            //3 egyforma + 2 egyforma
            if ((egy4 == 3 || ketto4 == 3 || harom4 == 3 || negy4 == 3 || ot4 == 3 || hat4 == 3) &&
                (egy4 == 2 || ketto4 == 2 || harom4 == 2 || negy4 == 2 || ot4 == 2 || hat4 == 2))
            {
                label4.BackColor = System.Drawing.Color.Blue;
            }

            //3 egyforma
            if (egy4 == 3 || ketto4 == 3 || harom4 == 3 || negy4 == 3 || ot4 == 3 || hat4 == 3)
            {
                label4.BackColor = System.Drawing.Color.Red;
            }

            //2db 2egyforma
            if (ossz4 == 2)
            {
                label4.BackColor = System.Drawing.Color.Orange;
            }

            //2egyforma
            if (ossz4 == 1)
            {
                label4.BackColor = System.Drawing.Color.Green;
            }

            #endregion


            #region Ötösjátékos

            #region Szamolások
            int egy5 = 0;
            int ketto5 = 0;
            int harom5 = 0;
            int negy5 = 0;
            int ot5 = 0;
            int hat5 = 0;

            for (int i = 0; i < otosjatekos.Count; i++)
            {
                if (otosjatekos[i] == 1)
                {
                    egy5++;
                }
                if (otosjatekos[i] == 2)
                {
                    ketto5++;
                }
                if (otosjatekos[i] == 3)
                {
                    harom5++;
                }
                if (otosjatekos[i] == 4)
                {
                    negy5++;
                }
                if (otosjatekos[i] == 5)
                {
                    ot5++;
                }
                if (otosjatekos[i] == 6)
                {
                    hat5++;
                }
            }


            int ossz5 = 0;
            if (egy5 == 2)
            {
                ossz5++;
            };
            if (ketto5 == 2)
            {
                ossz5++;
            };
            if (harom5 == 2)
            {
                ossz5++;
            };
            if (negy5 == 2)
            {
                ossz5++;
            };
            if (ot5 == 2)
            {
                ossz5++;
            };
            if (hat5 == 2)
            {
                ossz5++;
            };
            #endregion


            //5egyforma
            if (egy5 == 5 || ketto5 == 5 || harom5 == 5 || negy5 == 5 || ot5 == 5 || hat5 == 5)
            {
                label5.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy5 == 4 || ketto5 == 4 || harom5 == 4 || negy5 == 4 || ot5 == 4 || hat5 == 4)
            {
                label5.BackColor = System.Drawing.Color.Yellow;
            }



            //3 egyforma + 2 egyforma
            if ((egy5 == 3 || ketto5 == 3 || harom5 == 3 || negy5 == 3 || ot5 == 3 || hat5 == 3) &&
                (egy5 == 2 || ketto5 == 2 || harom5 == 2 || negy5 == 2 || ot5 == 2 || hat5 == 2))
            {
                label5.BackColor = System.Drawing.Color.Blue;
            }

            //3 egyforma
            if (egy5 == 3 || ketto5 == 3 || harom5 == 3 || negy5 == 3 || ot5 == 3 || hat5 == 3)
            {
                label5.BackColor = System.Drawing.Color.Red;
            }

            //2db 2egyforma
            if (ossz5 == 2)
            {
                label5.BackColor = System.Drawing.Color.Orange;
            }

            //2egyforma
            if (ossz5 == 1)
            {
                label5.BackColor = System.Drawing.Color.Green;
            }
            #endregion


            #region Hatosjátékos

            #region Szamolások
            int egy6 = 0;
            int ketto6 = 0;
            int harom6 = 0;
            int negy6 = 0;
            int ot6 = 0;
            int hat6 = 0;

            for (int i = 0; i < hatosjatekos.Count; i++)
            {
                if (hatosjatekos[i] == 1)
                {
                    egy6++;
                }
                if (hatosjatekos[i] == 2)
                {
                    ketto6++;
                }
                if (hatosjatekos[i] == 3)
                {
                    harom6++;
                }
                if (hatosjatekos[i] == 4)
                {
                    negy6++;
                }
                if (hatosjatekos[i] == 5)
                {
                    ot6++;
                }
                if (hatosjatekos[i] == 6)
                {
                    hat6++;
                }
            }


            int ossz6 = 0;
            if (egy6 == 2)
            {
                ossz6++;
            };
            if (ketto6 == 2)
            {
                ossz6++;
            };
            if (harom6 == 2)
            {
                ossz6++;
            };
            if (negy6 == 2)
            {
                ossz6++;
            };
            if (ot6 == 2)
            {
                ossz6++;
            };
            if (hat6 == 2)
            {
                ossz6++;
            };
            #endregion


            //5egyforma
            if (egy6 == 5 || ketto6 == 5 || harom6 == 5 || negy6 == 5 || ot6 == 5 || hat6 == 5)
            {
                label6.BackColor = System.Drawing.Color.Gold;
            }

            //4 egyforma
            if (egy6 == 4 || ketto6 == 4 || harom6 == 4 || negy6 == 4 || ot6 == 4 || hat6 == 4)
            {
                label6.BackColor = System.Drawing.Color.Yellow;
            }



            //3 egyforma + 2 egyforma
            if ((egy6 == 3 || ketto6 == 3 || harom6 == 3 || negy6 == 3 || ot6 == 3 || hat6 == 3) &&
                (egy6 == 2 || ketto6 == 2 || harom6 == 2 || negy6 == 2 || ot6 == 2 || hat6 == 2))
            {
                label6.BackColor = System.Drawing.Color.Blue;
            }

            //3 egyforma
            if (egy6 == 3 || ketto6 == 3 || harom6 == 3 || negy6 == 3 || ot6 == 3 || hat6 == 3)
            {
                label6.BackColor = System.Drawing.Color.Red;
            }

            //2db 2egyforma
            if (ossz6 == 2)
            {
                label6.BackColor = System.Drawing.Color.Orange;
            }

            //2egyforma
            if (ossz6 == 1)
            {
                label6.BackColor = System.Drawing.Color.Green;
            }
            #endregion
        }
    }
}
